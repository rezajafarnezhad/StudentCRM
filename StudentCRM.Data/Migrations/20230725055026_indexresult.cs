using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCRM.Data.Migrations
{
    public partial class indexresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentResult_CourseId",
                table: "StudentResult");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_CourseId_StudentId_TermId",
                table: "StudentResult",
                columns: new[] { "CourseId", "StudentId", "TermId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentResult_CourseId_StudentId_TermId",
                table: "StudentResult");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_CourseId",
                table: "StudentResult",
                column: "CourseId");
        }
    }
}
