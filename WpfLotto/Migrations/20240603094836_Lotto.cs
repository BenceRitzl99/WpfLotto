using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfLotto.Migrations
{
    public partial class Lotto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sorsolasok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    szam1 = table.Column<int>(type: "int", nullable: false),
                    szam2 = table.Column<int>(type: "int", nullable: false),
                    szam3 = table.Column<int>(type: "int", nullable: false),
                    szam4 = table.Column<int>(type: "int", nullable: false),
                    szam5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorsolasok", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sorsolasok");
        }
    }
}
