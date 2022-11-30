using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllPanel.Migrations
{
    public partial class Afteredited1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonalId",
                value: 1221376459L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonalId",
                value: 12L);
        }
    }
}
