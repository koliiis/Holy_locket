using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IPatientService : IDisposable
    {
        Task DeletePatient(int id);
        Task UpdatePatient(PatientDTO patient);
        Task<TokenInfoDTO> CreatePatient(PatientDTO patient);
        Task<PatientDTO> GetPatientById(string token);
    }   
}
