using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migrayting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //BU KISIM HATAYA SEBEP OLUYOR. CREATE ISLEMI GERCEKLESTIKTEN SONRA DROPTABLE UP'DA OLAMAMALI
            //AYNI SEKILDE DOWNDA'DA CREATE. KODU SILMEDIM SORUNU GOSTERMEK ICIN.

            //migrationBuilder.DropTable(
            //    name: "BlogRatings");

            migrationBuilder.CreateTable(
                name: "BlogRayrings",
                columns: table => new
                {
                    BlogRaytingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    BlogTotalScore = table.Column<int>(type: "int", nullable: false),
                    BlogRaytingCoutn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogRayrings", x => x.BlogRaytingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogRayrings");

            //migrationBuilder.CreateTable(
            //    name: "BlogRatings",
            //    columns: table => new
            //    {
            //        BlogRatingID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BlogID = table.Column<int>(type: "int", nullable: false),
            //        BlogRaytingCounts = table.Column<int>(type: "int", nullable: false),
            //        BlogTotalScore = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BlogRatings", x => x.BlogRatingID);
            //    });
        }
    }
}
