﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class LoginInfoDTO
    {
        public LoginInfoDTO(string phone, string password) 
        {
            this.phone = phone;
            this.password = password;
        }
        public string phone { get; set; }
        public string password { get; set; }    
    }
}
