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

        public bool AddAccount(Account account)
        {
            try
            {
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("AddAccount Error");
                return false;
            }
        }

        public bool AddPhoneNumber(string id,string phone)
        {
            try
            {
                if(_dbContext.Accounts.FirstOrDefault(x=>x.Id_student==id)!=null)
                {
                    _dbContext.Accounts.FirstOrDefault(x => x.Id_student == id).PhoneNumber = phone;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                Console.WriteLine("AddPhoneNumber Error");
                return false;
            }
        }

        public bool UpdatePoint (string id, int num)
        {
            try
            {
                if(_dbContext.Accounts.FirstOrDefault(x=>x.Id_student==id)!=null)
                {
                    _dbContext.Accounts.FirstOrDefault(x => x.Id_student == id).Point = num;
                    _dbContext.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("AddPhoneNumber Error");
                return false;
            }
        }

        public List<Account> GetAccount()
        {
            return _dbContext.Accounts.ToList();
        }

        public List<Account> GetAccount(string id)
        {

            return _dbContext.Accounts.Where(x => x.Id_student == id).ToList();
        }

        public List<Account> GetAccountMember()
        {
            var Memberlist = from accountlist in _dbContext.Accounts
                             where accountlist.Role == "student"
                             select accountlist;
            return Memberlist.ToList();
        }
    }
}
