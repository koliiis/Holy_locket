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
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
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
        public async Task UpdateAppointment(AppointmentDTO appointment)
        {
            await _appointmentRepository.Update(_mapper.Map<Appointment>(appointment)).ConfigureAwait(false);
        }
        public void Dispose()
        {
        }
    }
}
