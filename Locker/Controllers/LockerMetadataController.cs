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
    public class LockerMetadataController : Controller
    {
        private readonly LockerMetadataRepository _lockerRepo;
        private readonly LockerDbContext _dbContext;


        public LockerMetadataController(LockerDbContext lockerDbContext)
        {
            _dbContext = lockerDbContext;
            _lockerRepo = new LockerMetadataRepository(_dbContext);
        }

        [Route("LockerMetadata")]
        [HttpPost]
        public IActionResult AddLocker([FromBody] LockerMetadata locker)
        {
            if (_lockerRepo.AddLocker(locker))
            {
                return Ok(locker.Mac_address);
            }
            return NotFound();
        }

        [Route("LockerMetadata")]
        [HttpDelete]
        public IActionResult DeleteLocker([FromQuery] string Mac_address)
        {
            if (_lockerRepo.DeleteLocker(Mac_address))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}