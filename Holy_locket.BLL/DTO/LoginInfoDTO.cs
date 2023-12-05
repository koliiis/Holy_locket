using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class LoginInfoDTO
    {
        public LoginInfoDTO(int Id,string Token) 
        { 
            id = Id;
            token= Token;
        }

        public int id { get; set; }
        public string token { get; set; }
    }
}
