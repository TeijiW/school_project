using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace school_project.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School_Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", new object()),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Year = table.Column<int>(type: "int(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", new object()),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Subject = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", new object()),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_School_Class_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "School_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacher", x => new { x.SchoolClassId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ClassTeacher_School_Class_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "School_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_TeacherId",
                table: "ClassTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolClassId",
                table: "Student",
                column: "SchoolClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassTeacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "School_Class");
        }
    }
}
