using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.UserDTO
{
    public class UserDTOResponse:UserDTOBase
    {

        public string DepartmentName { get; set; }
        public string RoleName { get; set; }



        //public string PasswordHash {get; set;}

    }
}
