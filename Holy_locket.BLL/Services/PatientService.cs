﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public PatientService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Patient>();
            _mapper = mapper;
        }
        public async Task CreatePatient(PatientDTO patient)
        {
            await _repository.Create(_mapper.Map<Patient>(patient)).ConfigureAwait(false);
        }
        public async Task DeletePatient(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
        public async Task UpdatePatient(PatientDTO patient)
        {
            await _repository.Update(_mapper.Map<Patient>(patient)).ConfigureAwait(false);

        }
        public async Task<PatientDTO> GetPatientById(int id)
        {
            var patient = await _repository.Get(id).ConfigureAwait(false);
            return _mapper.Map<PatientDTO>(patient);
        }
        public void Dispose()
        {
        }
    }
}