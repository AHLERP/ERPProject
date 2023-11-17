using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.CompanyDTO
{
    public class CompanyDTOBase
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
