using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFornecedoresEmpresaAPI.Migrations
{
    public partial class BancoBase : Migration
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

            migrationBuilder.CreateTable(
                name: "TBEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSiglasUF = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBEmpresa_TBSiglasUF_IdSiglasUF",
                        column: x => x.IdSiglasUF,
                        principalTable: "TBSiglasUF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdTipoPessoa = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TBFornecedor_TBEmpresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "TBEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBFornecedor_TBTipoPessoa_IdTipoPessoa",
                        column: x => x.IdTipoPessoa,
                        principalTable: "TBTipoPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBTelefonesFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTelefonesFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTelefonesFornecedor_TBFornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "TBFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TBSiglasUF",
                columns: new[] { "Id", "Sigla" },
                values: new object[,]
                {
                    { 1, "AC" },
                    { 27, "TO" },
                    { 26, "SE" },
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
                    { 13, "MG" },
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
                    { 14, "PA" }
                });

            migrationBuilder.InsertData(
                table: "TBTipoPessoa",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Jurídica" },
                    { 2, "Física" }
                });

            migrationBuilder.InsertData(
                table: "TBEmpresa",
                columns: new[] { "Id", "CNPJ", "IdSiglasUF", "Nome" },
                values: new object[] { 1, "CNPJ Teste", 1, "Empresa Teste" });

            migrationBuilder.InsertData(
                table: "TBFornecedor",
                columns: new[] { "Id", "CPFCNPJ", "DataHoraCadastro", "DataNascimento", "IdEmpresa", "IdTipoPessoa", "Nome", "RG" },
                values: new object[] { 1, "12345678911", new DateTime(2023, 2, 21, 18, 32, 26, 523, DateTimeKind.Local).AddTicks(7706), new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, 2, "Fornecedor Teste", "1234567" });

            migrationBuilder.InsertData(
                table: "TBTelefonesFornecedor",
                columns: new[] { "Id", "IdFornecedor", "Telefone" },
                values: new object[] { 1, 1, "4798877665544" });

            migrationBuilder.CreateIndex(
                name: "IX_TBEmpresa_IdSiglasUF",
                table: "TBEmpresa",
                column: "IdSiglasUF");

            migrationBuilder.CreateIndex(
                name: "IX_TBFornecedor_IdEmpresa",
                table: "TBFornecedor",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TBFornecedor_IdTipoPessoa",
                table: "TBFornecedor",
                column: "IdTipoPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_TBTelefonesFornecedor_IdFornecedor",
                table: "TBTelefonesFornecedor",
                column: "IdFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTelefonesFornecedor");

            migrationBuilder.DropTable(
                name: "TBFornecedor");

            migrationBuilder.DropTable(
                name: "TBEmpresa");

            migrationBuilder.DropTable(
                name: "TBTipoPessoa");

            migrationBuilder.DropTable(
                name: "TBSiglasUF");
        }
    }
}
