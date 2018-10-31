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
    public class ContentController : Controller
    {
        private readonly ContentRepository _contentRepo;
        private readonly LockerDbContext _dbContext;

        public ContentController(LockerDbContext lockerDbContext)
        {
            _dbContext = lockerDbContext;
            _contentRepo = new ContentRepository(_dbContext);
        }

        [Route("AddContent")]
        [HttpPost]
        public IActionResult AddLocker([FromBody] Content _cont)
        {
            if (_contentRepo.AddContent(_cont))
            {
                return Ok(_cont.Id_content);
            }
            return NotFound();
        }

        [Route("DeleteContent")]
        [HttpDelete]
        public IActionResult DeleteLocker([FromQuery] int id)
        {
            if (_contentRepo.DeleteContent(id))
            {
                return Ok();
            }
            return NotFound();

        }

        [Route("UpdateActiveContent")]
        [HttpPut]
        public IActionResult UpdateContent([FromQuery] int id)
        {
            if (_contentRepo.UpdateActive(id))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [Route("ContentAll")]
        [HttpGet]
        public IActionResult GetContent()
        {
            var list = _contentRepo.GetContent();
            return Ok(list);
        }

        [Route("ContentId")]
        [HttpGet]
        public IActionResult GetContent(int id)
        {
            var list = _contentRepo.GetContent(id);
            return Ok(list);
        }

    }
}