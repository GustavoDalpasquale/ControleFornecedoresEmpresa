using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFornecedoresEmpresaAPI.Migrations
{
    public partial class CriacaoTBTipoPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBTipoPessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTipoPessoa", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TBTipoPessoa",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1, "Jurídica" });

            migrationBuilder.InsertData(
                table: "TBTipoPessoa",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2, "Física" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTipoPessoa");
        }
    }
}
