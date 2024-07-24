using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvBuilderDev.Migrations
{
    /// <inheritdoc />
    public partial class AccountDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Header_userId",
                table: "WorkExperience");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Header",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Header_userId",
                table: "Header",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Header_Users_userId",
                table: "Header",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Users_userId",
                table: "WorkExperience",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Header_Users_userId",
                table: "Header");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Users_userId",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Header_userId",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Header");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Header_userId",
                table: "WorkExperience",
                column: "userId",
                principalTable: "Header",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
