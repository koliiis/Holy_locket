using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _repository;
        private readonly IRepository<Doctor> _docRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public RatingService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Rating>();
            _mapper = mapper;
            _docRepository = _unitOfWork.GetRepository<Doctor>();
            _config = config;
        }
        public async Task AddRating(RatingDTO ratingDTO, string patientToken)
        {
            var result = await AuthService.GetFromToken(patientToken).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 1 && await AuthService.CheckToken(_config, patientToken).ConfigureAwait(false))
            {
                var rating = _mapper.Map<Rating>(ratingDTO);
                    rating.PatientId = result.Id;
                    await _repository.Create(_mapper.Map<Rating>(rating)).ConfigureAwait(false);
                    var averageRating = (await _repository.Get().ConfigureAwait(false)).Where(a => a.DoctorId == rating.DoctorId).Average(item => item.Rate);
                    var doctor = await _docRepository.GetById(rating.DoctorId);
                    doctor.Rating = averageRating;
                    await _docRepository.Update(doctor);
            }
        }
        public async Task DeleteRating(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
        public async Task UpdateRating(RatingDTO rating)
        {
            await _repository.Update(_mapper.Map<Rating>(rating)).ConfigureAwait(false);
        }
        public async Task<double> GetCalculated(int doctorId)
        {
            var ratings = (await _repository.Get().ConfigureAwait(false)).Where(a => a.DoctorId == doctorId);
            return ratings.Average(item => item.Rate);
        }
        public async Task<ICollection<RatingDTO>> GetAll()
        {
            var ratings = await _repository.Get().ConfigureAwait(false);
            return _mapper.Map<ICollection<RatingDTO>>(ratings);
        }
    }
}
