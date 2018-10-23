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
                var result = from vacantMaclist in _dbContext.Vacancies
                             join vacantNolist in _dbContext.Vacancies on vacantMaclist.Id_vacancy equals vacantNolist.Id_vacancy
                             where vacantMaclist.Mac_address == vacant.Mac_address
                             select vacantNolist;
                if (result.FirstOrDefault(x => x.No_vacancy == vacant.No_vacancy) != null)
                {
                    return UpdateActive(vacant.No_vacancy, vacant.Mac_address);
                }
                else {
                    _dbContext.Vacancies.Add(vacant);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Have %s\t%s it already",vacant.Mac_address,vacant.No_vacancy);
                return false;
            }
        }

        public bool DeleteVacancy(string No_vacant, string Mac_address)
        {
            try
            {
                var result = from vacantMaclist in _dbContext.Vacancies
                         join vacantNolist in _dbContext.Vacancies on vacantMaclist.Id_vacancy equals vacantNolist.Id_vacancy
                         where vacantMaclist.Mac_address == Mac_address
                         select vacantNolist;
           
            _dbContext.Vacancies.FirstOrDefault(x => x.No_vacancy == No_vacant).IsActive = false;
            _dbContext.SaveChanges();
            return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Have %s\t%s it already", Mac_address, No_vacant);
                return false;
            }
        }

        public bool UpdateActive (string No_vacant,string Mac_address)//consider no_vacant and mac_address to set active
        {
            try
            {
                var result = from vacantMaclist in _dbContext.Vacancies
                             join vacantNolist in _dbContext.Vacancies on vacantMaclist.Id_vacancy equals vacantNolist.Id_vacancy
                             where vacantMaclist.Mac_address == Mac_address
                             select vacantNolist;

                _dbContext.Vacancies.FirstOrDefault(x => x.No_vacancy == No_vacant).IsActive = true;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("No have %s\t%s it already", Mac_address, No_vacant);
                return false;
            }
        }
    }
}
