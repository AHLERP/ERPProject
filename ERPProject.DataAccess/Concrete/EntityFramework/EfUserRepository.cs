﻿using ERPProject.DataAccess.Abstract;
using ERPProject.DataAccess.Concrete.EntityFramework.DataManagement;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserRepository : EfRepository<User>, IUserRepository
    {
        public EfUserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<User> UpdateAsyncForLogin(UserDTOResponse Entity)
        {
            throw new NotImplementedException();
        }
    }
}
