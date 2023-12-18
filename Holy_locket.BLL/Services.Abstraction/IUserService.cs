using Holy_locket.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IUserService
    {
        Task<TokenInfoDTO> Login(string Phone, string Password);
    }
}
