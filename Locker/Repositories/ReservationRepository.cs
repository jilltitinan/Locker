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
            var tmp = reserve; 
            if ((_dbContext.Reservations.Where(x => x.Id_locker==tmp.Id_locker) == null))
            {
                return false;
            }

            _dbContext.Reservations.Add(reserve);
            _dbContext.SaveChanges();
            return true;
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
