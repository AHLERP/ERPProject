using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.CategoryDTO
{
    public class CategoryDTOBase
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
