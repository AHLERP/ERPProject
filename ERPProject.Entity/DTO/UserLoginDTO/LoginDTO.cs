﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.UserLoginDTO
{
    public class LoginDTO
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public string Token { get; set; }
        public string RoleName { get; set; }
    }
}
