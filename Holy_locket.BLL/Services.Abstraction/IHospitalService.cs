﻿using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IHospitalService : IDisposable
    {
        Task DeleteHospital(int id);
        Task UpdateHospital(HospitalDTO hospital);
        Task CreateHospital(HospitalDTO hospital);
        Task<HospitalDTO> GetHospitalById(int id);
        Task<ICollection<Hospital>> GetAllHospitals();
    }
}
