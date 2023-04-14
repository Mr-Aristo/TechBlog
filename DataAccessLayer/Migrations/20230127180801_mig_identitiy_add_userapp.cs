using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migidentitiyadduserapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(  //Eklenecek sutunlar
                name: "ImageUrl",
                table: "AspNetUsers", //Sutunun eklenecegi tablo
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "AspNetUsers", 
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "AspNetUsers");
        }
    }
}
