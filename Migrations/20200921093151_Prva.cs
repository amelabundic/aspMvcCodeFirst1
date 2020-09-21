using Microsoft.EntityFrameworkCore.Migrations;

namespace aspMvcCodeFirst1.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    OsobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Adresa = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.OsobaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osoba");
        }
    }
}
