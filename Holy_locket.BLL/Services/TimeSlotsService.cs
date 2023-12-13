using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class TimeSlotsService : ITimeSlotsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<TimesForDay> _timesForDayRepository;
        private readonly IRepository<TimeSlot> _timeSlotRepository;
        public TimeSlotsService(IMapper mapper, IUnitOfWork unitOfWork, ISpecialityService specialityService, IDoctorService doctorService, IPatientService patientService)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
            _timesForDayRepository = _unitOfWork.GetRepository<TimesForDay>();
            _timeSlotRepository = _unitOfWork.GetRepository<TimeSlot>();
        }
        public async Task<List<List<string>>> GetTimeSlots(int doctorId)
        {
            var appointments = _mapper.Map<List<AppointmentDTO>>(await _appointmentRepository.Get());
            var timesForDays = (await _timesForDayRepository.Get()).Where(x => x.DoctorId == doctorId).ToList();
            int day = (int)DateTime.Now.DayOfWeek;
            List<TimesForDay> result = timesForDays.GetRange(day, timesForDays.Count() - day);
            result.AddRange(timesForDays.GetRange(0, day));

            var times = new List<List<string>>();
            foreach (var item in timesForDays)
            {
                var ts = _mapper.Map<List<TimeSlotDTO>>(await _timeSlotRepository.Get());
                var list = ts
                    .Where(x => x.TimesForDayId == item.Id)
                    .Select(a => a.Time).ToList();
                times.Add(list);
            }
            var timeSlots = new List<List<string>>();
            //List<string> times = new List<string>() {"12:00-12:30","12:30-13:00","13:00-13:30","13:30-14:00","14:00-14:30","14:30-15:00", "15:00-15:30",
            //                                        "15:30-16:00", "16:00-16:30", "16:30-17:00", "17:00-17:30", "17:30-18:00"};
            int counter = 0;
            DateTime temp = DateTime.Today;
            for (int i = 0; i < 7; i++)
            {
                var tempList = new List<string>();
                foreach (var time in times[i])
                {
                    if ((DateTime.Parse(time.Split("-")[0]).TimeOfDay > DateTime.Now.TimeOfDay || i !=0) && time != null)
                    {
                        tempList.Add(time);
                    }
                }
                timeSlots.Add(tempList);
            }
            foreach (var item in appointments)
            {
                if (DateTime.Parse(item.Date) >= DateTime.Today.Date && (item.Inactive == false || (DateTime.Parse(item.Date) - DateTime.Today).Hours < 24))
                {
                    counter = (DateTime.Parse(item.Date) - DateTime.Today).Days;
                    timeSlots[counter].Remove(item.Time);
                    temp = DateTime.Parse(item.Date);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (timeSlots[i].Count == 0) timeSlots[i].Add("Немає вільних слотів");

            }
            return timeSlots;
        }

        public async Task PostTimeSlots(List<List<string>> times, int doctorId)
        {
            var timesForDays = new List<TimesForDay>();
            int counter = 0;
            foreach (var item in times) 
            {
                var timesForDay = new TimesForDay()
                {
                    DoctorId = doctorId,
                };
                await _timesForDayRepository.Create(timesForDay);
                var time = (await _timesForDayRepository.Get()).Where(x => x.DoctorId == doctorId).ToList()[counter];

                var slotsList = new List<TimeSlot>();
                for (int j = 0; j < item.Count; j++) 
                {
                    await _timeSlotRepository.Create(new TimeSlot() 
                    {
                        Time = item[j],
                        TimesForDayId = time.Id,
                    }
                    );
                }
                counter++;
            }
        }
        public async Task DeleteTimeSlots(int doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTimeSlots(List<List<string>> times, int doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
