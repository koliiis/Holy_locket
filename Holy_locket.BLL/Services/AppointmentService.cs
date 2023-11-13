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
    public class AppointmentsService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Appointment>();
            _mapper = mapper;
        }
        public async Task CreateAppointment(AppointmentDTO appointment)
        {
            await _repository.Create(_mapper.Map<Appointment>(appointment)).ConfigureAwait(false);
        }
        public async Task DeleteAppointment(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
        public async Task UpdateAppointment(AppointmentDTO appointment)
        {
            await _repository.Update(_mapper.Map<Appointment>(appointment)).ConfigureAwait(false);

        }
        public async Task<AppointmentDTO> GetAppointmentById(int id)
        {
            var appointment = await _repository.Get(id).ConfigureAwait(false);
            return _mapper.Map<AppointmentDTO>(appointment);
        }
        public async Task<ICollection<Appointment>> GetAll()
        {
            var appointments = await _repository.Get().ConfigureAwait(false);
            return _mapper.Map<ICollection<Appointment>>(appointments);
        }
        public void Dispose()
        {
        }
    }
}
