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
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Patient>();
        }
        public async Task CreatePatient(Patient patient)
        {
            await _repository.Create(patient);
        }
        public async Task DeletePatient(int id)
        {
            await _repository.Delete(id);
        }
        public async Task UpdatePatient(Patient patient)
        {
            await _repository.Update(patient);
       
        }
        public async Task GetPatientById(int id)
        {
            await _repository.Get(id);
        }
        public void Dispose()
        {
        }
    }
}
