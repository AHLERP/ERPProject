﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.BrandDTO
{
    public class BrandDTORequest : BrandDTOBase
    {
        public long? AddedUser { get; set; }

        public long? UpdatedUser { get; set; }
    }
}
