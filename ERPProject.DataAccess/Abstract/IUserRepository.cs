﻿using ERPProject.Core.DataAccess;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateAsyncForLogin(UserDTOResponse Entity);
    }
}
