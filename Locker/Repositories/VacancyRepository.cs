using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class VacancyRepository
    {
        LockerDbContext _dbContext;

        public VacancyRepository(LockerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddVacancy(Vacancy vacant)
        {
            //_dbContext.Database.ExecuteSqlCommandAsync(@"CREATE VIEW View_vacancy AS 
            //                SELECT Mac_address, No_vacancy from Vacancies");
            try
            {
                var result = from vacantlist in _dbContext.Vacancies
                             where vacantlist.Mac_addressRef == vacant.Mac_addressRef 
                             select vacantlist;
                var locker = from lockerlist in _dbContext.LockerMetadatas
                             where lockerlist.Mac_address == vacant.Mac_addressRef && lockerlist.IsActive == true
                             select lockerlist;
                if (locker.FirstOrDefault(x=>x.Mac_address == vacant.Mac_addressRef)==null)
                {
                    return false;
                }
                else if (result.FirstOrDefault(x => x.No_vacancy == vacant.No_vacancy) != null)
                {
                    return false;
                }
                else {
                    _dbContext.Vacancies.Add(vacant);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Have %s\t%s it already on AddVacancy()",vacant.Mac_addressRef,vacant.No_vacancy);
                return false;
            }
        }

        public bool DeleteVacancy(string No_vacant, string Mac_address)
        {
            try
            {
                var result = from vacantlist in _dbContext.Vacancies
                         where vacantlist.Mac_addressRef == Mac_address 
                         select vacantlist;
           
            result.FirstOrDefault(x => x.No_vacancy == No_vacant).IsActive = false;
            _dbContext.SaveChanges();
            return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Have %s\t%s it already on DeleteVacancy", Mac_address, No_vacant);
                return false;
            }
        }

        public bool UpdateActive(string No_vacant, string Mac_address)//consider no_vacant and mac_address to set active
        {
            try
            {
                /* var result = from vacantlist in _dbContext.Vacancies
                              where vacantlist.Mac_addressRef == Mac_address
                              select vacantlist;*/

                var result = from vacanlist in _dbContext.Vacancies
                             join lockerlist in _dbContext.LockerMetadatas on vacanlist.Mac_addressRef equals lockerlist.Mac_address
                             where lockerlist.IsActive == true && vacanlist.Mac_addressRef == Mac_address
                             select vacanlist;
                if (result != null)
                {
                    result.FirstOrDefault(x => x.No_vacancy == No_vacant).IsActive = true;
                }

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //Console.WriteLine("No have %s\t%s it already on UpdateActive()", Mac_address, No_vacant);
                return false;
            }
        }

        public bool UpdateSize(string No_vacant, string Mac_address, string Size)
        {
            try
            {
                var result = from vacantlist in _dbContext.Vacancies
                             where vacantlist.Mac_addressRef == Mac_address && vacantlist.No_vacancy == No_vacant && vacantlist.IsActive == true
                             select vacantlist;
                if (result != null)
                {
                    result.FirstOrDefault(x => x.No_vacancy == No_vacant).Size = Size;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                // Console.WriteLine("No have %s\t%s it already on UpdateSize()", Mac_address, No_vacant);
                return false;
            }
        }
        public List<Vacancy> GetVacancy()
        {
            return _dbContext.Vacancies.ToList();
        }

        public List<Vacancy> GetVacancy(int id)
        {

            return _dbContext.Vacancies.Where(x => x.Id_vacancy == id).ToList();
        }

    }
}
        
       

