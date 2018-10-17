using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locker.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffId = table.Column<string>(nullable: true),
                    FirstNameTH = table.Column<string>(nullable: true),
                    LastNameTH = table.Column<string>(nullable: true),
                    FirstNameEN = table.Column<string>(nullable: true),
                    LastNameEN = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GenderCode = table.Column<string>(nullable: true),
                    RoleCode = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsNotified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id_reserve = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    StartDay = table.Column<DateTime>(nullable: false),
                    EndDay = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id_reserve);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
