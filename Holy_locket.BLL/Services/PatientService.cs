using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PatientService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Patient>();
            _mapper = mapper;
            _config = config;
        }
        public async Task<TokenInfoDTO> CreatePatient(PatientDTO patient)
        {
            await _repository.Create(_mapper.Map<Patient>(patient)).ConfigureAwait(false);
            var user = (await _repository.Get())
            .Where(p => p.Phone == patient.Phone)
            .FirstOrDefault();
            return new TokenInfoDTO(await AuthService.GenerateJSONWebToken(_config, user.Id, user.Role), user.Role);
        }
        public async Task DeletePatient(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
        public async Task UpdatePatient(PatientDTO patient)
        {
            await _repository.Update(_mapper.Map<Patient>(patient)).ConfigureAwait(false);
        }
        public async Task<PatientDTO> GetPatientById(string token)
        {
            var result = await AuthService.GetFromToken(token).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 1 && await AuthService.CheckToken(_config, token).ConfigureAwait(false))
            {
                var patient = await _repository.GetById(result.Id).ConfigureAwait(false);
                    return _mapper.Map<PatientDTO>(patient);
            }
            else
                return null;
        }
        public void Dispose()
        {
        }
    }
}
