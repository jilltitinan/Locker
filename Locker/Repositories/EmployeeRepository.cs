using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class EmployeeRepository
    {
        LockerDbContext _dbContext;

        public EmployeeRepository(LockerDbContext dbContext)
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
        public bool AddEmployee(Employee employee)
        {
            if (_dbContext.Employees.Contains(employee))
                return false;
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return true;
        }

        /// <summary>
        ///     Delete employee in database
        /// </summary>
        /// <param name="staffId">An id of the one who will be deleted</param>
        /// <returns>
        ///     true - if success
        ///     false - if no id found
        /// </returns>
        public bool DeleteEmployee(string staffId)
        {
            if (_dbContext.Employees.Where(x => x.StaffId == staffId) == null)
                return false;
            _dbContext.Employees.FirstOrDefault(x => x.StaffId == staffId).IsActive = false;
            _dbContext.SaveChanges();
            return true;
        }

    }


}
