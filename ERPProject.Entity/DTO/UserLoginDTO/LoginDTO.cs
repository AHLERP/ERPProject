using System;
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
        public string CompanyName { get; set; }
        public string Token { get; set; }
        public List<string> RoleName { get; set; }
        public string AdSoyad { get; set; }
        public string EPosta { get; set; }
        public long UserId { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
