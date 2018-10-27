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

        [Route("AddVacant")]
        [HttpPost]
        public IActionResult AddVacancy([FromBody] Vacancy vacant)
        {
            if (_vacancyRepo.AddVacancy(vacant))
            {
                return Ok(vacant.Id_vacancy);
            }
            return NotFound();
        }

        [Route("DeleteVacant")]
        [HttpDelete]
        public IActionResult DeleteVacancy([FromQuery] string No_vacant, string Mac_address)
        {
            if (_vacancyRepo.DeleteVacancy(No_vacant,Mac_address))
            {
                return Ok();
            }
            return NotFound();

        }

        [Route("UpadateActiveVacant")]
        [HttpPut]
        public IActionResult UpdateActive([FromQuery] string No_vacant,string Mac_address )
        {
            if (_vacancyRepo.UpdateActive(No_vacant,Mac_address))
            {
                return Ok();
            }
            return NotFound();
        }

        [Route("UpdateSizeVacant")]
        [HttpPut]
        public IActionResult UpdateSize([FromQuery] string No_vacant, string Mac_address, string size)
        {
            if (_vacancyRepo.UpdateSize(No_vacant, Mac_address, size))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}