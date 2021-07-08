 using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchioOnlineShop.Data.Migrations
{
    public partial class addednewfieldintousertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prenom",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "prenom",
                table: "AspNetUsers");
        }
    }
}
