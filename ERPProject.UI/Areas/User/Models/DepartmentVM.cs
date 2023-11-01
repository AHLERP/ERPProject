﻿using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class DepartmentVM
    {
        public virtual ICollection<DepartmentDTOResponse> Departments { get; set; } = new List<DepartmentDTOResponse>();

        public virtual ICollection<CompanyDTOResponse> Companies { get; set; } = new List<CompanyDTOResponse>();

    }
}
