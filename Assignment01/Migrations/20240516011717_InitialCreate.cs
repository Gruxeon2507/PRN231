using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment01.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    TeacherCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.TeacherCode);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StillStudying = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentCode);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectCode);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSubject",
                columns: table => new
                {
                    TeacherCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSubject", x => new { x.TeacherCode, x.SubjectCode });
                    table.ForeignKey(
                        name: "FK_InstructorSubject_Instructor",
                        column: x => x.TeacherCode,
                        principalTable: "Instructor",
                        principalColumn: "TeacherCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorSubject_Subject",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcript",
                columns: table => new
                {
                    StudentCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    HighestScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcript", x => new { x.StudentCode, x.SubjectCode });
                    table.ForeignKey(
                        name: "FK_Transcript_Student",
                        column: x => x.StudentCode,
                        principalTable: "Student",
                        principalColumn: "StudentCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transcript_Subject",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubject_SubjectCode",
                table: "InstructorSubject",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_SubjectCode",
                table: "Transcript",
                column: "SubjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorSubject");

            migrationBuilder.DropTable(
                name: "Transcript");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
