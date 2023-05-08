using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adresses_city_CityId",
                table: "adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_events_adresses_AddressId",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adresses",
                table: "adresses");

            migrationBuilder.RenameTable(
                name: "adresses",
                newName: "addresses");

            migrationBuilder.RenameIndex(
                name: "IX_adresses_CityId",
                table: "addresses",
                newName: "IX_addresses_CityId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_city_CityId",
                table: "addresses",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_addresses_AddressId",
                table: "events",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_city_CityId",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_events_addresses_AddressId",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "adresses");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_CityId",
                table: "adresses",
                newName: "IX_adresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adresses",
                table: "adresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adresses_city_CityId",
                table: "adresses",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_adresses_AddressId",
                table: "events",
                column: "AddressId",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
