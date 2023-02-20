using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFornecedoresEmpresaAPI.Migrations
{
    public partial class CriacaoBaseBancoTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBSiglasUF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSiglasUF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiglasUFId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBEmpresa_TBSiglasUF_SiglasUFId",
                        column: x => x.SiglasUFId,
                        principalTable: "TBSiglasUF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TBSiglasUF",
                columns: new[] { "Id", "Sigla" },
                values: new object[,]
                {
                    { 1, "AC" },
                    { 25, "SP" },
                    { 24, "SC" },
                    { 23, "RR" },
                    { 22, "RO" },
                    { 21, "RS" },
                    { 20, "RN" },
                    { 19, "RJ" },
                    { 18, "PI" },
                    { 17, "PE" },
                    { 16, "PR" },
                    { 15, "PB" },
                    { 26, "SE" },
                    { 14, "PA" },
                    { 12, "MS" },
                    { 11, "MT" },
                    { 10, "MA" },
                    { 9, "GO" },
                    { 8, "ES" },
                    { 7, "DF" },
                    { 6, "CE" },
                    { 5, "BA" },
                    { 4, "AM" },
                    { 3, "AP" },
                    { 2, "AL" },
                    { 13, "MG" },
                    { 27, "TO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBEmpresa_SiglasUFId",
                table: "TBEmpresa",
                column: "SiglasUFId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBEmpresa");

            migrationBuilder.DropTable(
                name: "TBSiglasUF");
        }
    }
}
