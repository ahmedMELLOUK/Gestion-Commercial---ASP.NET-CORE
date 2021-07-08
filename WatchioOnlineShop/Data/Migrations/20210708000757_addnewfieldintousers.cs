using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchioOnlineShop.Data.Migrations
{
    public partial class addnewfieldintousers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_type",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_type",
                table: "AspNetUsers");
        }
    }
}
