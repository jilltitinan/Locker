using Locker.DatabaseContext.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext
{
    public class LockerDbContext : DbContext
    {
        public LockerDbContext(DbContextOptions<LockerDbContext> options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
