using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        private readonly IConfiguration _config;
        public TimeSlotsService(IMapper mapper, IUnitOfWork unitOfWork, ISpecialityService specialityService, IDoctorService doctorService, IPatientService patientService, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
            _timesForDayRepository = _unitOfWork.GetRepository<TimesForDay>();
            _timeSlotRepository = _unitOfWork.GetRepository<TimeSlot>();
            _config = config;
        }
        public async Task<List<List<string>>> GetTimeSlots(int doctorId)
        {
            try
            {
                var appointments = _mapper.Map<List<AppointmentDTO>>(await _appointmentRepository.Get().ConfigureAwait(false));
                var timesForDays = _mapper.Map<List<TimesForDayDTO>>((await _timesForDayRepository.Get().ConfigureAwait(false)).Where(x => x.DoctorId == doctorId && x.Inactive == false).ToList());
                var times = new List<List<string>>();
                foreach (var item in DayOfWeekRightOrder(timesForDays))
                {
                    var list = await GetTimeSlotsForDay(item).ConfigureAwait(false);
                    times.Add(list);
                }
                var timeSlots = FilterTimeSlots(times);
                RemoveAppointmentsFromTimeSlots(appointments, doctorId, timeSlots);
                SetNoAvailableSlotsMessage(timeSlots);
                return timeSlots;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<List<string>>> GetDoctorTimeSlots(string token)
        {
            try
            {
                var result = await AuthService.GetFromToken(token).ConfigureAwait(false);
                if (result?.Id != 0 && result?.Role == 2 && await AuthService.CheckToken(_config, token).ConfigureAwait(false))
                {
                    var appointments = _mapper.Map<List<AppointmentDTO>>(await _appointmentRepository.Get().ConfigureAwait(false));
                    var timesForDays = _mapper.Map<List<TimesForDayDTO>>((await _timesForDayRepository.Get().ConfigureAwait(false)).Where(x => x.DoctorId == result.Id && x.Inactive == false).ToList());
                    var timeSlots = GenerateTimeSlots(appointments, result.Id);
                    SetNoAvailableDoctorSlotsMessage(timeSlots);
                    return timeSlots;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private List<TimesForDayDTO> DayOfWeekRightOrder(List<TimesForDayDTO> timesForDays)
        {
            int day = (int)DateTime.Now.DayOfWeek;
            List<TimesForDayDTO> result = timesForDays.GetRange(day, timesForDays.Count() - day);
            result.AddRange(timesForDays.GetRange(0, day));
            return result;
        }
        private async Task<List<TimesForDayDTO>> NextWeek(List<TimesForDayDTO> timesForDays)
        {
            int day = (int)DateTime.Now.DayOfWeek;
            List<TimesForDayDTO> result = timesForDays.GetRange(day, day + 7);
            if (day == 6)
            {
                List<TimesForDayDTO> inactivate = timesForDays.GetRange(0, day);
                foreach (var item in inactivate)
                {
                    item.Inactive = true;
                    await _timesForDayRepository.Update(_mapper.Map<TimesForDay>(item)).ConfigureAwait(false);
                }

            }
            return result;
        }
        private async Task<List<string>> GetTimeSlotsForDay(TimesForDayDTO item)
        {
            var ts = _mapper.Map<List<TimeSlotDTO>>(await _timeSlotRepository.Get().ConfigureAwait(false));
            return ts
                .Where(x => x.TimesForDayId == item.Id)
                .Select(a => a.Time).ToList();
        }
        private List<List<string>> FilterTimeSlots(List<List<string>> times)
        {
            var timeSlots = new List<List<string>>();
            for (int i = 0; i < 7; i++)
            {
                var tempList = times[i]
                    .Where(time => (DateTime.Parse(time.Split("-")[0]).TimeOfDay > DateTime.Now.TimeOfDay || i != 0) && time != null)
                    .ToList();
                timeSlots.Add(tempList);
            }
            return timeSlots;
        }
        private void RemoveAppointmentsFromTimeSlots(List<AppointmentDTO> appointments, int doctorId, List<List<string>> timeSlots)
        {
            int counter = 0;
            DateTime temp = DateTime.Today;
            foreach (var item in appointments)
            {
                if (DateTime.Parse(item.Date) >= DateTime.Today.Date && (item.Inactive == false || ((DateTime.Parse(item.Date).Date - DateTime.Now.Date).Days < 1)) && doctorId == item.DoctorId)
                {
                    counter = (DateTime.Parse(item.Date) - DateTime.Today).Days;
                    timeSlots[counter].Remove(item.Time);
                    temp = DateTime.Parse(item.Date);
                }
            }
        }
        private List<List<string>> GenerateTimeSlots(List<AppointmentDTO> appointments, int doctorId)
        {
            List<List<string>> timeSlots = new List<List<string>>();
            for (int i = 0; i < 7; i++)
            {
                DateTime currentDate = DateTime.Today.AddDays(i);
                List<string> slotsForDay = appointments
                    .Where(a => DateTime.Parse(a.Date).Date == currentDate && a.DoctorId == doctorId && a.Inactive == false && (i!=0 || DateTime.Parse(a.Time.Split("-")[0]).TimeOfDay > DateTime.Now.TimeOfDay))
                    .OrderBy(a => a.Time)
                    .Select(a => a.Time)
                    .ToList();

                timeSlots.Add(slotsForDay);
            }
            return timeSlots;
        }
        private void SetNoAvailableSlotsMessage(List<List<string>> timeSlots)
        {
            for (int i = 0; i < timeSlots.Count; i++)
            {
                if (timeSlots[i].Count == 0) timeSlots[i].Add("Немає вільних слотів");
            }
        }
        private void SetNoAvailableDoctorSlotsMessage(List<List<string>> timeSlots)
        {
            for (int i = 0; i < timeSlots.Count; i++)
            {
                if (timeSlots[i].Count == 0) timeSlots[i].Add("Немає зайнятих слотів");
            }
        }
        public async Task PostTimeSlots(List<List<string>> times, string token)
        {
            var result = await AuthService.GetFromToken(token).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 2 && await AuthService.CheckToken(_config, token).ConfigureAwait(false))
            {
                var timesForDays = new List<TimesForDay>();
                int counter = 0;
                foreach (var item in times)
                {
                    var timesForDay = new TimesForDay()
                    {
                        DoctorId = result.Id,
                    };

                    await _timesForDayRepository.Create(timesForDay).ConfigureAwait(false);
                    var time = (await _timesForDayRepository.Get()).Where(x => x.DoctorId == result.Id).ToList()[counter];

                    var slotsList = new List<TimeSlot>();

                    for (int j = 0; j < item.Count; j++)
                    {
                        await _timeSlotRepository.Create(new TimeSlot()
                        {
                            Time = item[j],
                            TimesForDayId = time.Id,
                        });
                    }
                    counter++;
                }
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
