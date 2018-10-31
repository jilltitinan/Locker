﻿using System;
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
    public class AccountController : Controller
    {
        private readonly AccountRepository _accountRepo;
        private readonly LockerDbContext _dbContext;

        public AccountController(LockerDbContext lockerDbContext)
        {
            _dbContext = lockerDbContext;
            _accountRepo = new AccountRepository(_dbContext);
        }

        [Route("AddAccount")]
        [HttpPost]
        public IActionResult AddAccount([FromBody] Account account)
        {
            if (_accountRepo.AddAccount(account))
            {
                return Ok(account.Id_student);
            }
            return NotFound();
        }

        [Route("AddPhoneNumber")]
        [HttpPut]
        public IActionResult AddPhoneNumber([FromQuery] string id, string phone)
        {
            if (_accountRepo.AddPhoneNumber(id,phone))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [Route("UpdatePoint")]
        [HttpPut]
        public IActionResult UpdatePoint([FromQuery] string id, int num)
        {
            if (_accountRepo.UpdatePoint(id,num))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [Route("AccountAll")]
        [HttpGet]
        public IActionResult GetAccount()
        {
            var list = _accountRepo.GetAccount();
            return Ok(list);
        }

        [Route("ContentId")]
        [HttpGet]
        public IActionResult GetAccount(string id)
        {
            var list = _accountRepo.GetAccount(id);
            return Ok(list);
        }
    }
}