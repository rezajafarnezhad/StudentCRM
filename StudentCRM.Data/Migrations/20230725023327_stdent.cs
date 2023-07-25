using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCRM.Data.Migrations
{
    public partial class stdent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "StudentResult");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "StudentResult");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "StudentResult");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCode = table.Column<byte>(type: "tinyint", nullable: false),
                    StudentNumber = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_StudentId",
                table: "StudentResult",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentCode",
                table: "Student",
                column: "StudentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentNumber",
                table: "Student",
                column: "StudentNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResult_Student_StudentId",
                table: "StudentResult",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentResult_Student_StudentId",
                table: "StudentResult");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_StudentResult_StudentId",
                table: "StudentResult");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentResult");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StudentResult",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "StudentResult",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "StudentResult",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
