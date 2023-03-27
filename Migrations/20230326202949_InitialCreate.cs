using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licenta_Kovacs_Adela.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aroma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireAroma = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aroma", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bob",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireBoabe = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bob", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lapte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireLapte = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lapte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarimeMl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marime", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipCafea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCafea", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireTopping = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CafeaClient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCafea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipCafeaID = table.Column<int>(type: "int", nullable: true),
                    BobID = table.Column<int>(type: "int", nullable: true),
                    LapteID = table.Column<int>(type: "int", nullable: true),
                    AromaID = table.Column<int>(type: "int", nullable: true),
                    MarimeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeaClient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CafeaClient_Aroma_AromaID",
                        column: x => x.AromaID,
                        principalTable: "Aroma",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_Bob_BobID",
                        column: x => x.BobID,
                        principalTable: "Bob",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_Lapte_LapteID",
                        column: x => x.LapteID,
                        principalTable: "Lapte",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_Marime_MarimeID",
                        column: x => x.MarimeID,
                        principalTable: "Marime",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CafeaClient_TipCafea_TipCafeaID",
                        column: x => x.TipCafeaID,
                        principalTable: "TipCafea",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CafeaTipuriToppingClient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CafeaClientID = table.Column<int>(type: "int", nullable: false),
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeaTipuriToppingClient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CafeaTipuriToppingClient_CafeaClient_CafeaClientID",
                        column: x => x.CafeaClientID,
                        principalTable: "CafeaClient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CafeaTipuriToppingClient_Topping_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Topping",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_AromaID",
                table: "CafeaClient",
                column: "AromaID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_BobID",
                table: "CafeaClient",
                column: "BobID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_LapteID",
                table: "CafeaClient",
                column: "LapteID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_MarimeID",
                table: "CafeaClient",
                column: "MarimeID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaClient_TipCafeaID",
                table: "CafeaClient",
                column: "TipCafeaID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaTipuriToppingClient_CafeaClientID",
                table: "CafeaTipuriToppingClient",
                column: "CafeaClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CafeaTipuriToppingClient_ToppingID",
                table: "CafeaTipuriToppingClient",
                column: "ToppingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CafeaTipuriToppingClient");

            migrationBuilder.DropTable(
                name: "Membru");

            migrationBuilder.DropTable(
                name: "CafeaClient");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Aroma");

            migrationBuilder.DropTable(
                name: "Bob");

            migrationBuilder.DropTable(
                name: "Lapte");

            migrationBuilder.DropTable(
                name: "Marime");

            migrationBuilder.DropTable(
                name: "TipCafea");
        }
    }
}
