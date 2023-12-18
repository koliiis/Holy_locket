using Holy_locket.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IRatingService
    {
        Task DeleteRating(int id);
        Task UpdateRating(RatingDTO speciality);
        Task AddRating(RatingDTO speciality);
        Task<double> GetCalculated(int doctorId);
        Task<ICollection<RatingDTO>> GetAll();
    }
}
