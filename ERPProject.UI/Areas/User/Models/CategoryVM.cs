﻿using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.DTO.CategoryDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class CategoryVM
    {
        public virtual ICollection<CategoryDTOResponse> Companies { get; set; } = new List<CategoryDTOResponse>();

    }
}
