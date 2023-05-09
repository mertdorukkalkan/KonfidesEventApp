using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "EventDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Addresses",
                newName: "AddressDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AddressDescription",
                table: "Addresses",
                newName: "Description");
        }
    }
}
