using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFornecedoresEmpresaAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SiglasUF> TBSiglasUF { get; set; }
        public DbSet<Empresa> TBEmpresa { get; set; }
        public DbSet<TipoPessoa> TBTipoPessoa { get; set; }
        public DbSet<Fornecedor> TBFornecedor { get; set; }
        public DbSet<TelefonesFornecedor> TBTelefonesFornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiglasUF>().HasData(
                new SiglasUF
                {
                    Id = 1,
                    Sigla = "AC",
                },
                new SiglasUF
                {
                    Id = 2,
                    Sigla = "AL",
                },
                new SiglasUF
                {
                    Id = 3,
                    Sigla = "AP",
                },
                new SiglasUF
                {
                    Id = 4,
                    Sigla = "AM",
                },
                new SiglasUF
                {
                    Id = 5,
                    Sigla = "BA",
                },
                new SiglasUF
                {
                    Id = 6,
                    Sigla = "CE",
                },
                new SiglasUF
                {
                    Id = 7,
                    Sigla = "DF",
                },
                new SiglasUF
                {
                    Id = 8,
                    Sigla = "ES",
                },
                new SiglasUF
                {
                    Id = 9,
                    Sigla = "GO",
                },
                new SiglasUF
                {
                    Id = 10,
                    Sigla = "MA",
                },
                new SiglasUF
                {
                    Id = 11,
                    Sigla = "MT",
                },
                new SiglasUF
                {
                    Id = 12,
                    Sigla = "MS",
                },
                new SiglasUF
                {
                    Id = 13,
                    Sigla = "MG",
                },
                new SiglasUF
                {
                    Id = 14,
                    Sigla = "PA",
                },
                new SiglasUF
                {
                    Id = 15,
                    Sigla = "PB",
                },
                new SiglasUF
                {
                    Id = 16,
                    Sigla = "PR",
                },
                new SiglasUF
                {
                    Id = 17,
                    Sigla = "PE",
                },
                new SiglasUF
                {
                    Id = 18,
                    Sigla = "PI",
                },
                new SiglasUF
                {
                    Id = 19,
                    Sigla = "RJ",
                },
                new SiglasUF
                {
                    Id = 20,
                    Sigla = "RN",
                },
                new SiglasUF
                {
                    Id = 21,
                    Sigla = "RS",
                },
                new SiglasUF
                {
                    Id = 22,
                    Sigla = "RO",
                },
                new SiglasUF
                {
                    Id = 23,
                    Sigla = "RR",
                },
                new SiglasUF
                {
                    Id = 24,
                    Sigla = "SC",
                },
                new SiglasUF
                {
                    Id = 25,
                    Sigla = "SP",
                },
                new SiglasUF
                {
                    Id = 26,
                    Sigla = "SE",
                },
                new SiglasUF
                {
                    Id = 27,
                    Sigla = "TO",
                }
                );
            modelBuilder.Entity<TipoPessoa>().HasData(
                new TipoPessoa
                {
                    Id = 1,
                    Tipo = "Jurídica",
                },
                new TipoPessoa
                {
                    Id = 2,
                    Tipo = "Física",
                }
                );
        }

    }
}
