using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Holy_locket.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISpecialityService _specialityService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
       

        public AppointmentService(IMapper mapper, IUnitOfWork unitOfWork, ISpecialityService specialityService, IDoctorService doctorService, IPatientService patientService)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
            _specialityService = specialityService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public async Task<List<List<string>>> GetTimeSlots(int doctorId)
        {


            var appointments = _mapper.Map<List<AppointmentDTO>>(await _appointmentRepository.Get());
            var timeSlots = new List<List<string>>();
            List<string> times = new List<string>() {"12:00-12:30","12:30-13:00","13:00-13:30","13:30-14:00","14:00-14:30","14:30-15:00", "15:00-15:30",
                                                    "15:30-16:00", "16:00-16:30", "16:30-17:00", "17:00-17:30", "17:30-18:00"};
            int counter = 0;
            DateTime temp = DateTime.Today;
            const int DAYS_COUNT = 7;

            for (int i = 0; i < DAYS_COUNT; i++)
            {
                var tempList = new List<string>();
                for (int j = 0; j < times.Count; j++)
                {
                    if (DateTime.Parse(times[j].Split("-")[0]).TimeOfDay > DateTime.Now.TimeOfDay || i != 0)
                    {
                        tempList.Add(times[j]);
                        if (j == times.Count - 1)
                            timeSlots.Add(tempList);
                    }
                    else
                    {
                        if (j == times.Count - 1)
                            timeSlots.Add(new List<string>());
                    }
                    
                }
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
            for (int i = 0; i < DAYS_COUNT; i++)
            {
                if (timeSlots[i].Count == 0) timeSlots[i].Add("Немає вільних слотів");
                
            }
            return timeSlots;
        }

        public async Task<AppointmentInfoDTO> MapInfo(AppointmentInfoDTO info)
        {
            var doctor = await _doctorService.GetDoctorById(info.DoctorId);
            var speciality = await _specialityService.GetSpecialityById(doctor.SpecialityId);
            info.SpecialityName = speciality.Name;
            info.DoctorName = doctor.FirstName;
            info.DoctorSecondName = doctor.SecondName;
            DateTime date = DateTime.ParseExact(info.Date, "dd/MM/yyyy", null);
            DateTime currentDateTime = DateTime.Now;
            if (currentDateTime.Date > date || (currentDateTime.Date == date && CheckTime(info.Time) >= 0))
            {
                info.Irrelevant = true;
            }
            return info;
        }
        static int CheckTime(string timeRangeString)
        {
            string[] parts = timeRangeString.Split('-');
            try
            {
                var endTime = DateTime.ParseExact(parts[1], "HH:mm", null);
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                return currentTime.CompareTo(endTime.TimeOfDay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task AddAppointment(AppointmentDTO appointment)
        {
            await _appointmentRepository.Create(_mapper.Map<Appointment>(appointment)).ConfigureAwait(false);
        }

        public async Task DeleteAppointment(int id)
        {
            await _appointmentRepository.Delete(id).ConfigureAwait(false);
        }

        public async Task<ICollection<AppointmentDTO>> GetAllAppointments()
        {
            var appointment = await _appointmentRepository.Get().ConfigureAwait(false);
            return _mapper.Map<ICollection<AppointmentDTO>>(appointment);
        }

        public async Task<AppointmentDTO> GetAppointmentById(int id)
        {
            var appointment = await _appointmentRepository.GetById(id).ConfigureAwait(false);
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task<ICollection<AppointmentInfoDTO>> GetAppointmentInfo(int id)
        {
            Expression<Func<Appointment, bool>> filter = x => x.PatientId == id;
            var appointments = _mapper.Map<ICollection<AppointmentInfoDTO>>(await _appointmentRepository.Get(filter));
            List<AppointmentInfoDTO> info = new List<AppointmentInfoDTO>();

            foreach (var appointment in appointments)
            {
                info.Add(await MapInfo(appointment));
            }
            info.Reverse();
            return info;
        }

        public async Task UpdateAppointment(AppointmentDTO appointment)
        {
            await _appointmentRepository.Update(_mapper.Map<Appointment>(appointment)).ConfigureAwait(false);
        }
        public async Task SoftDeleteAppointment(int id)
        {
            await _appointmentRepository.SoftDelete(id).ConfigureAwait(false);
        }
        public void Dispose()
        {
        }
    }
}
