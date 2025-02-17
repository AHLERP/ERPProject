﻿using ERPProject.Business.Abstract.DataManagement;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Business.Abstract
{
    public interface IOfferService:IGenericService<Offer>
    {
        Task<ICollection<Offer>> UpdateAllAsync(Offer Entity);
    }
}
