using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMailBox.Migrations
{
    public partial class AjoutCouleur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "MailBoxes");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "MailBoxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailBoxes_ColorId",
                table: "MailBoxes",
                column: "ColorId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_MailBoxes_ColorId",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "MailBoxes");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "MailBoxes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
