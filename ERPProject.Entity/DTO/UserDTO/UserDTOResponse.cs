﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.UserDTO
{
    public class UserDTOResponse:UserDTOBase
    {

        public string DepartmentName { get; set; }
        public List<string> RoleName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }


        //public string PasswordHash {get; set;}

    }
}
