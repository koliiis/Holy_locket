﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class TokenInfoDTO
    {
        public TokenInfoDTO(string Token, int Role) 
        { 
            this.Role = Role;
            this.Token = Token;
        }
        public string Token { get; set; }
        public int Role { get; set; }

    }
}
