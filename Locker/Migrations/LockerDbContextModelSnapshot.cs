﻿// <auto-generated />
using Locker.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locker.Migrations
{
    [DbContext(typeof(LockerDbContext))]
    partial class LockerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("Locker.DatabaseContext.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstNameEN");

                    b.Property<string>("FirstNameTH");

                    b.Property<string>("GenderCode");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsNotified");

                    b.Property<string>("LastNameEN");

                    b.Property<string>("LastNameTH");

                    b.Property<string>("Nickname");

                    b.Property<string>("ProfilePicture");

                    b.Property<string>("RoleCode");

                    b.Property<string>("StaffId");

                    b.HasKey("EmployeeNumber");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
