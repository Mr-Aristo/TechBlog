using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migmessagedeletedmessage2using : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages2");

            migrationBuilder.DropColumn(
                name: "Reciever",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "RecieverID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecieverID",
                table: "Messages",
                column: "RecieverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_RecieverID",
                table: "Messages",
                column: "RecieverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_RecieverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_SenderID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecieverID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecieverID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Reciever",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Messages2",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecieverID = table.Column<int>(type: "int", nullable: true),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages2", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages2_Writers_RecieverID",
                        column: x => x.RecieverID,
                        principalTable: "Writers",
                        principalColumn: "WriterID");
                    table.ForeignKey(
                        name: "FK_Messages2_Writers_SenderID",
                        column: x => x.SenderID,
                        principalTable: "Writers",
                        principalColumn: "WriterID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages2_RecieverID",
                table: "Messages2",
                column: "RecieverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages2_SenderID",
                table: "Messages2",
                column: "SenderID");
        }
    }
}
