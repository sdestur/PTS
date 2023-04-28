using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class EntityV5_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber1",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber2",
                table: "Employees",
                newName: "ContactNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Employees",
                newName: "PhoneNumber2");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber1",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
