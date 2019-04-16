using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class ReservationRepository
    {
        LockerDbContext _dbContext;

        public ReservationRepository(LockerDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///     Add employee to database
        /// </summary>
        /// <param name="employee">An employee to be added</param>
        /// <returns>
        ///     true - if success
        ///     false - if already exist
        /// </returns>
        public bool AddReservation(Reservation reserve)
        {
            try
            {
                
                if (CheckId_studentRef(reserve.Id_studentRef))
                {
                    return false;
                }
                //else if (CheckId_vacancyRef(reserve.Id_vacancyRef))
                //{
                //    return false;
                //}
                else
                {
                    _dbContext.Reservations.Add(reserve);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("AddReservation Error");
                return false;
            }
            
            
        }

        public bool CheckId_studentRef(string id)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.Id_student == id) == null;
        }
        
        //public bool CheckVacancy (string Mac_address,)
        //{
        //    // list from vacancy that have Id_vacancy No_vacancy Size IsActive=true Mac_addressRef=Mac_address
        //    var reserve_list = from reservelist in _dbContext.Reservations
        //                       join vacancylist in _dbContext.Vacancies on reservelist.Id_vacancyRef equals vacancylist.Id_vacancy
        //                       where vacancylist.Mac_addressRef == Mac_address && vacancylist.IsActive == true
        //                       select reservelist;
              

        //}

        public bool CheckId_vacancyRef(int id)
        {
            return _dbContext.Vacancies.FirstOrDefault(x => x.Id_vacancy == id) == null;
        }

        public bool CancelReseveration(int id)
        {
            try
            {
                if (_dbContext.Reservations.FirstOrDefault(x => x.Id_reserve == id) == null)
                {
                    _dbContext.Reservations.FirstOrDefault(x => x.Id_reserve == id).IsActive = false;
                    return true;
                }
                return false;
            }catch (Exception)
            {
                Console.WriteLine("Cancel reservation error");
                return false;
            }
        }
        ///// <summary>
        /////     Delete employee in database
        ///// </summary>
        ///// <param name="staffId">An id of the one who will be deleted</param>
        ///// <returns>
        /////     true - if success
        /////     false - if no id found
        ///// </returns>
        //public bool DeleteEmployee(string staffId)
        //{
        //    if (_dbContext.Employees.Where(x => x.StaffId == staffId) == null)
        //        return false;
        //    _dbContext.Employees.FirstOrDefault(x => x.StaffId == staffId).IsActive = false;
        //    _dbContext.SaveChanges();
        //    return true;
        //}

        ///// <summary>
        /////     Get basic information of the employee
        ///// </summary>
        ///// <param name="staffId">An id of the employee</param>
        ///// <returns>
        /////     Employee - An instance of the employee
        /////     null - if no employee found
        ///// </returns>
        //public Employee GetProfile(string staffId)
        //{
        //    var emp = _dbContext.Employees.FirstOrDefault(x => x.StaffId == staffId);
        //    if (emp == null)
        //        return null;
        //    if (emp.IsActive == false)
        //        return null;
        //    return emp;
        //}

    }
}
