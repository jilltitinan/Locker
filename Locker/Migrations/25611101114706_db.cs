using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locker.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id_student = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id_student);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id_content = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlainText = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id_content);
                });

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
                name: "LockerMetadatas",
                columns: table => new
                {
                    Mac_address = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerMetadatas", x => x.Mac_address);
                });

            migrationBuilder.CreateTable(
                name: "MessageDetails",
                columns: table => new
                {
                    Id_message = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    Id_contentRef = table.Column<int>(nullable: false),
                    Id_studentRef = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDetails", x => x.Id_message);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id_reserve = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_student = table.Column<string>(nullable: true),
                    Id_locker = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id_vacancy = table.Column<int>(nullable: false),
                    No_vacancy = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Mac_addressRef = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => new { x.Mac_addressRef, x.No_vacancy });
                    table.UniqueConstraint("AK_Vacancies_Id_vacancy", x => x.Id_vacancy);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LockerMetadatas");

            migrationBuilder.DropTable(
                name: "MessageDetails");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
