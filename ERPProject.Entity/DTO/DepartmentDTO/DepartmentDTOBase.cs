using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.DepartmentDTO
{
    public class DepartmentDTOBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // ilişkili olduğu tablolar
        public int CompanyId { get; set; } 
    }
}
