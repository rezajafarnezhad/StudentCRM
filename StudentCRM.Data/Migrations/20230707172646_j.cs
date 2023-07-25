using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCRM.Data.Migrations
{
    public partial class j : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentResult_Code",
                table: "StudentResult");

            migrationBuilder.DropIndex(
                name: "IX_StudentResult_StudentNumber",
                table: "StudentResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_Code",
                table: "StudentResult",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_StudentNumber",
                table: "StudentResult",
                column: "StudentNumber",
                unique: true);
        }
    }
}
