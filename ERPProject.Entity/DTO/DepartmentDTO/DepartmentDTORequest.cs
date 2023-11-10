using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.DepartmentDTO
{
    public class DepartmentDTORequest:DepartmentDTOBase
    {
        public long? AddedUser { get; set; }

        public long? UpdatedUser { get; set; }
    }
}
