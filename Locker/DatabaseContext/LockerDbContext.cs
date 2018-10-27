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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vacancy>().HasKey(table => new {
                table.Mac_addressRef,
                table.No_vacancy
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<LockerMetadata> LockerMetadatas { get; set; }  
    }
}
