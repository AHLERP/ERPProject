﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.StockDTO
{
    public class StockDTOResponse:StockDTOBase
    {

        public string CompanyName { get; set; }
        public string ProductName { get; set; }
    }
}
