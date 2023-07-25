using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCRM.Data.Migrations
{
    public partial class stdenlong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "StudentNumber",
                table: "Student",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<long>(
                name: "StudentCode",
                table: "Student",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "StudentNumber",
                table: "Student",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<byte>(
                name: "StudentCode",
                table: "Student",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
