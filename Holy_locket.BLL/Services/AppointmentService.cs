using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Holy_locket.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private readonly SpecialityService specialityService;
        private readonly PatientService patientService;
        private readonly DoctorService doctorService;
        private readonly IRepository<Appointment> _repository;
        private readonly IConfiguration config;
        
        public AppointmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
            specialityService = new SpecialityService(_unitOfWork, _mapper);
            patientService = new PatientService(_unitOfWork, _mapper, config);
            doctorService = new DoctorService(_unitOfWork, _mapper);
            _repository = unitOfWork.GetRepository<Appointment>();
        }

        public async Task<List<List<AppointmentDTO>>> GetTimeSlots()
        {
            var appointments = await _appointmentRepository.Get();
            var timeSlots = new List<List<AppointmentDTO>>();
            List<string> dates = new List<string>() {"12:00-12:30","12:30-13:00","14:00-14:30","14:30-15:00", "15:00-15:30", 
                                                    "15:30-16:00", "16:00-16:30", "16:30-17:00", "76:00 - 17:30", "17:30 - 18:00" };

            foreach (var appointment in appointments)
            {
                if (DateTime.Parse(appointment.Date) >= DateTime.Today)
                {

                }
            }

            return null;
        }

        public async Task<AppointmentInfoDTO> MapInfo(AppointmentInfoDTO info)
        {
            var doctor = await doctorService.GetDoctorById(info.DoctorId);
            var speciality = await specialityService.GetSpecialityById(doctor.SpecialityId);
            info.SpecialityName = speciality.Name;
            info.DoctorName = doctor.FirstName;
            info.DoctorSecondName = doctor.SecondName;
            return info;
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
            var appointments = _mapper.Map<ICollection<AppointmentInfoDTO>>(await _repository.Get(filter));
            List<AppointmentInfoDTO> info = new List<AppointmentInfoDTO>();

            foreach (var appointment in appointments)
            {
                info.Add(await MapInfo(appointment));
            }

            return info;
        }

        public async Task UpdateAppointment(AppointmentDTO appointment)
        {
            await _appointmentRepository.Update(_mapper.Map<Appointment>(appointment)).ConfigureAwait(false);
        }

        public void Dispose()
        {
        }
    }
}
