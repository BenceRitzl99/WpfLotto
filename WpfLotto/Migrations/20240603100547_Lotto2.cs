using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfLotto.Migrations
{
    public partial class Lotto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SorsolasId = table.Column<int>(type: "int", nullable: false),
                    szam1 = table.Column<int>(type: "int", nullable: false),
                    szam2 = table.Column<int>(type: "int", nullable: false),
                    szam3 = table.Column<int>(type: "int", nullable: false),
                    szam4 = table.Column<int>(type: "int", nullable: false),
                    szam5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipp_Sorsolasok_SorsolasId",
                        column: x => x.SorsolasId,
                        principalTable: "Sorsolasok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tipp_SorsolasId",
                table: "Tipp",
                column: "SorsolasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tipp");
        }
    }
}
