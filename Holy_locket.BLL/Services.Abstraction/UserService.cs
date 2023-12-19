using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Holy_locket.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public class UserService : IUserService
    {
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = unitOfWork.GetRepository<Patient>();
            _doctorRepository = unitOfWork.GetRepository<Doctor>();
            _mapper = mapper;
            _config = config;
        }

        public async Task<TokenInfoDTO> Login(string phone, string password)
        {
            var user = (await _doctorRepository.Get())
            .Where(d => d.Phone == phone)
            .Cast<User>()
            .Union((await _patientRepository.Get())
            .Where(p => p.Phone == phone))
            .FirstOrDefault();
            if (user != null && user.Password == password)
            {
                return new TokenInfoDTO(await AuthService.GenerateJSONWebToken(_config, user.Id, user.Role), user.Role);
            }
            else return null;
        }
    }
}
