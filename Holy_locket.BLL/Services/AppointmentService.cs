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
        private readonly IConfiguration _config;

        public AppointmentService(IMapper mapper, IUnitOfWork unitOfWork, ISpecialityService specialityService, IDoctorService doctorService, IPatientService patientService, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
            _specialityService = specialityService;
            _patientService = patientService;
            _doctorService = doctorService;
            _config = config;
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
            if (currentDateTime.Date > date || (currentDateTime.Date == date && DateTime.Now > DateTime.ParseExact($"{info.Date} {info.Time}", "dd/MM/yyyy HH:mm", null)))
            {
                info.Irrelevant = true;
            }
            return info;
        }
        public async Task AddAppointment(AppointmentDTO appointmentDTO, string patientToken)
        {
            var result = await AuthService.GetFromToken(patientToken).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 1 && await AuthService.CheckToken(_config, patientToken).ConfigureAwait(false))
            {
                var appointment = _mapper.Map<Appointment>(appointmentDTO);
                appointment.PatientId = result.Id;
                await _appointmentRepository.Create(appointment).ConfigureAwait(false);
            }
            else
                throw new UnauthorizedAccessException($"Unauthorized");
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

        public async Task<ICollection<AppointmentInfoDTO>> GetAppointmentInfo(string token)
        {
            var result = await AuthService.GetFromToken(token).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 1 && await AuthService.CheckToken(_config, token).ConfigureAwait(false))
            {
                Expression<Func<Appointment, bool>> filter = x => x.PatientId == result.Id;
                var appointments = _mapper.Map<ICollection<AppointmentInfoDTO>>(await _appointmentRepository.Get(filter));
                List<AppointmentInfoDTO> info = new List<AppointmentInfoDTO>();

                foreach (var appointment in appointments)
                {
                    info.Add(await MapInfo(appointment));
                }
                info.Reverse();
                return info;
            }
            else
                throw new UnauthorizedAccessException($"Unauthorized");
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
