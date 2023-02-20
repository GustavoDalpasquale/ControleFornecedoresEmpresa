using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFornecedoresEmpresaAPI.Migrations
{
    public partial class CriacaoTBFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    TipoPessoaId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CPFCNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBFornecedor_TBEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "TBEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBFornecedor_TBTipoPessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TBTipoPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBFornecedor_EmpresaId",
                table: "TBFornecedor",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBFornecedor_TipoPessoaId",
                table: "TBFornecedor",
                column: "TipoPessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFornecedor");
        }
    }
}
