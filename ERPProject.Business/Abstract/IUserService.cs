﻿using ERPProject.Business.Abstract.DataManagement;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Business.Abstract
{
    public interface IUserService:IGenericService<User>
    {
        
    }
}
