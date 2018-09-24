using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using Locker.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Locker.Controllers
{
    [Route("/api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _empRepo;
        private readonly LockerDbContext _dbContext;

        /// <summary>
        ///     Initialize EmployeeController with a specific database context
        /// </summary>
        /// <param name="lockerDbContext">the targeted database context</param>
        public EmployeeController(LockerDbContext lockerDbContext)
        {
            _dbContext = lockerDbContext;
            _empRepo = new EmployeeRepository(_dbContext);
        }

        /// <summary>
        ///     Add an employee to database
        /// </summary>
        /// <param name="employee">An employee to be added</param>
        /// <returns>
        ///     Ok - if success
        ///     null - if the employee is already exist
        /// </returns>
        [Route("Employee")]
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (_empRepo.AddEmployee(employee))
            {
                return Ok(employee.StaffId);
            }
            return NotFound();
        }
    }
}