using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class LockerMetadataRepository
    {
        LockerDbContext _dbContext;

        public LockerMetadataRepository(LockerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddLocker(LockerMetadata locker)
        {
            //_dbContext.Database.ExecuteSqlCommandAsync(@"CREATE VIEW View_vacancy AS 
            //                SELECT Mac_address, No_vacancy from Vacancies");
            try
            {
                if ((_dbContext.LockerMetadatas.FirstOrDefault(x => x.Mac_address == locker.Mac_address))!=null){
                    return false;
                }
                _dbContext.LockerMetadatas.Add(locker);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Have %s it already", locker.ToString());
                return false;
            }
        }
        public bool DeleteLocker(string Mac_address)
        {
            try
            {

                _dbContext.LockerMetadatas.FirstOrDefault(x => x.Mac_address == Mac_address).IsActive = false;
                var vacancylocker = from vacantlist in _dbContext.Vacancies
                                    where vacantlist.Mac_addressRef == Mac_address
                                    select vacantlist;
                if (vacancylocker!=null)
                {
                    vacancylocker.ToList().ForEach(x => x.IsActive = false);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("No have %s\t%s it already", Mac_address);
                return false;
            }
        }

        public bool UpdateActive(string Mac_address)//consider no_vacant and mac_address to set active
        {
            try {

                var listLocker = from lockers in _dbContext.LockerMetadatas
                                 where lockers.Mac_address == Mac_address 
                                 select lockers;
                if (listLocker != null)
                {
                    _dbContext.LockerMetadatas.FirstOrDefault(x => x.Mac_address == Mac_address).IsActive = true;
                    _dbContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception)
            {
                Console.WriteLine("No have %s\t%s it already", Mac_address);
                return false;
            }
        }
    }
}
