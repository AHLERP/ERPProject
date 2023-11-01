using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.UserDTO
{
    public class UserDTOBase
    {
        public long Id { get; set; }

        public int DepartmentId { get; set; }

        public int RolId { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
