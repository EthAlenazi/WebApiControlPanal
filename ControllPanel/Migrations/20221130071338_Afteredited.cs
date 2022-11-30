using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllPanel.Migrations
{
    public partial class Afteredited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Accounts",
                newName: "IsFemale");

            migrationBuilder.AlterColumn<long>(
                name: "PersonalId",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "MobileNumber",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "ZipCode" },
                values: new object[] { 1, "Riyadh", "Saudi Arabia", "Olaya Street", 11461 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "ZipCode" },
                values: new object[] { 2, "Khubar", "Saudi Arabia", "king abdulaziz road", 31952 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "ZipCode" },
                values: new object[] { 3, "Jeddah", "Saudi Arabia", "Juffali Building, Madinah Road", 21442 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "IsActive", "IsAdmin", "IsFemale", "LastName", "MobileNumber", "PersonalId", "ProfilePhotopath" },
                values: new object[] { 1, 1, "Alotio123@gmail.com", "Ahmad", true, true, false, "Saeed", 966565433332L, 12345674321L, "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_1.PNG" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "IsActive", "IsAdmin", "IsFemale", "LastName", "MobileNumber", "PersonalId", "ProfilePhotopath" },
                values: new object[] { 2, 2, "Sa7ar@gmail.com", "Sahar", true, false, true, "Mohammed", 966545321888L, 12343215432L, "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_2.PNG" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "IsActive", "IsAdmin", "IsFemale", "LastName", "MobileNumber", "PersonalId", "ProfilePhotopath" },
                values: new object[] { 3, 3, "Saleh11@gmail.com", "Fahad", true, true, true, "Saleh", 966535432221L, 12L, "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_3.PNG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "IsFemale",
                table: "Accounts",
                newName: "Gender");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
