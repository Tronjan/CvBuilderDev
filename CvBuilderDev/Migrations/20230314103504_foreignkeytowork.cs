using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvBuilderDev.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeytowork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "WorkExperience",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_userId",
                table: "WorkExperience",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Header_userId",
                table: "WorkExperience",
                column: "userId",
                principalTable: "Header",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Header_userId",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_userId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "WorkExperience");
        }
    }
}
