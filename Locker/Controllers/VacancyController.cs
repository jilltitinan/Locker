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
    public class VacancyController : Controller
    {
        private readonly VacancyRepository _vacancyRepo;
        private readonly LockerDbContext _dbContext;


        public VacancyController(LockerDbContext lockerDbContext)
        {
            _dbContext = lockerDbContext;
            _vacancyRepo = new VacancyRepository(_dbContext);
        }

        [Route("Vacant")]
        [HttpPost]
        public IActionResult AddVacancy([FromBody] Vacancy vacant)
        {
            if (_vacancyRepo.AddVacancy(vacant))
            {
                return Ok(vacant.Id_vacancy);
            }
            return NotFound();
        }

        [Route("Vacant")]
        [HttpDelete]
        public IActionResult DeleteVacancy([FromQuery] string No_vacant, string Mac_address)
        {
            if (_vacancyRepo.DeleteVacancy(No_vacant,Mac_address))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}