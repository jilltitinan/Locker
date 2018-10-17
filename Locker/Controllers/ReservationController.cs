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
    public class ReservationController : Controller
    {
        private readonly ReservationRepository _reserveRepo;
        private readonly LockerDbContext _dbContext;


        public ReservationController(LockerDbContext lockerDbContext)
        {
            _dbContext = lockerDbContext;
            _reserveRepo = new ReservationRepository(_dbContext);
        }

        [Route("Reserve")]
        [HttpPost]
        public IActionResult AddReservation([FromBody] Reservation reserve)
        {
            if (_reserveRepo.AddReservation(reserve))
            {
                return Ok(reserve.Id_reserve);
            }
            return NotFound();
        }
    }
}