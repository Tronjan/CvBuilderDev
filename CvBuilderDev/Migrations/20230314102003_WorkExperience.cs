using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvBuilderDev.Migrations
{
    /// <inheritdoc />
    public partial class WorkExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tag1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tag2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tag3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tag4 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkExperience");
        }
    }
}
