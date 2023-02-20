using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFornecedoresEmpresaAPI.Migrations
{
    public partial class CriacaoTBTelefonesFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBTelefonesFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorId = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTelefonesFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTelefonesFornecedor_TBFornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "TBFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTelefonesFornecedor_FornecedorId",
                table: "TBTelefonesFornecedor",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTelefonesFornecedor");
        }
    }
}
