using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class AccountRepository
    {
        LockerDbContext _dbContext;

        public AccountRepository(LockerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public bool AddAccount (Account account)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
