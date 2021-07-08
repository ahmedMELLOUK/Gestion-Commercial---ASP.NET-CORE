using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchioOnlineShop.Data.Migrations
{
    public partial class addcommandemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "commandeId",
                table: "article",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nbre_article = table.Column<int>(nullable: false),
                    prix_total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_commandeId",
                table: "article",
                column: "commandeId");

            migrationBuilder.AddForeignKey(
                name: "FK_article_commande_commandeId",
                table: "article",
                column: "commandeId",
                principalTable: "commande",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_article_commande_commandeId",
                table: "article");

            migrationBuilder.DropTable(
                name: "commande");

            migrationBuilder.DropIndex(
                name: "IX_article_commandeId",
                table: "article");

            migrationBuilder.DropColumn(
                name: "commandeId",
                table: "article");
        }
    }
}
