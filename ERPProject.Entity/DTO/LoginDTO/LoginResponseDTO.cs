using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.LoginDTO
{
    public class LoginResponseDTO
    {
        public string AdSoyad { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }

        public string Token { get; set; }
        public string RoleName { get; set; }
        public long UserId { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
    }
}
