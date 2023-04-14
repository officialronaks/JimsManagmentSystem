using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jims_Managment_System_Or.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cfees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalstudents = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Fid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    CourseCid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Fid);
                    table.ForeignKey(
                        name: "FK_Faculties_Courses_CourseCid",
                        column: x => x.CourseCid,
                        principalTable: "Courses",
                        principalColumn: "Cid");
                });

            migrationBuilder.CreateTable(
                name: "Studentss",
                columns: table => new
                {
                    Sid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    CourseCid = table.Column<int>(type: "int", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: false),
                    totalpercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentss", x => x.Sid);
                    table.ForeignKey(
                        name: "FK_Studentss_Courses_CourseCid",
                        column: x => x.CourseCid,
                        principalTable: "Courses",
                        principalColumn: "Cid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_CourseCid",
                table: "Faculties",
                column: "CourseCid");

            migrationBuilder.CreateIndex(
                name: "IX_Studentss_CourseCid",
                table: "Studentss",
                column: "CourseCid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Studentss");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
