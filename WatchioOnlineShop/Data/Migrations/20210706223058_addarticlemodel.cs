using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchioOnlineShop.Data.Migrations
{
    public partial class addarticlemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    disponible = table.Column<bool>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    quantite = table.Column<int>(nullable: false),
                    prix = table.Column<double>(nullable: false),
                    id_categorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_article_categorie_id_categorie",
                        column: x => x.id_categorie,
                        principalTable: "categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_id_categorie",
                table: "article",
                column: "id_categorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");
        }
    }
}
