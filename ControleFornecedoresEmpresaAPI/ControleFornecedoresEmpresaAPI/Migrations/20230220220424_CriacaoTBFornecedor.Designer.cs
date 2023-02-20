﻿// <auto-generated />
using System;
using ControleFornecedoresEmpresaAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleFornecedoresEmpresaAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230220220424_CriacaoTBFornecedor")]
    partial class CriacaoTBFornecedor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleFornecedoresEmpresaAPI.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("SiglasUFId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SiglasUFId");

                    b.ToTable("TBEmpresa");
                });

            modelBuilder.Entity("ControleFornecedoresEmpresaAPI.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPFCNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("RG")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int?>("TipoPessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("TBFornecedor");
                });

            modelBuilder.Entity("ControleFornecedoresEmpresaAPI.Models.SiglasUF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBSiglasUF");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Sigla = "AC"
                        },
                        new
                        {
                            Id = 2,
                            Sigla = "AL"
                        },
                        new
                        {
                            Id = 3,
                            Sigla = "AP"
                        },
                        new
                        {
                            Id = 4,
                            Sigla = "AM"
                        },
                        new
                        {
                            Id = 5,
                            Sigla = "BA"
                        },
                        new
                        {
                            Id = 6,
                            Sigla = "CE"
                        },
                        new
                        {
                            Id = 7,
                            Sigla = "DF"
                        },
                        new
                        {
                            Id = 8,
                            Sigla = "ES"
                        },
                        new
                        {
                            Id = 9,
                            Sigla = "GO"
                        },
                        new
                        {
                            Id = 10,
                            Sigla = "MA"
                        },
                        new
                        {
                            Id = 11,
                            Sigla = "MT"
                        },
                        new
                        {
                            Id = 12,
                            Sigla = "MS"
                        },
                        new
                        {
                            Id = 13,
                            Sigla = "MG"
                        },
                        new
                        {
                            Id = 14,
                            Sigla = "PA"
                        },
                        new
                        {
                            Id = 15,
                            Sigla = "PB"
                        },
                        new
                        {
                            Id = 16,
                            Sigla = "PR"
                        },
                        new
                        {
                            Id = 17,
                            Sigla = "PE"
                        },
                        new
                        {
                            Id = 18,
                            Sigla = "PI"
                        },
                        new
                        {
                            Id = 19,
                            Sigla = "RJ"
                        },
                        new
                        {
                            Id = 20,
                            Sigla = "RN"
                        },
                        new
                        {
                            Id = 21,
                            Sigla = "RS"
                        },
                        new
                        {
                            Id = 22,
                            Sigla = "RO"
                        },
                        new
                        {
                            Id = 23,
                            Sigla = "RR"
                        },
                        new
                        {
                            Id = 24,
                            Sigla = "SC"
                        },
                        new
                        {
                            Id = 25,
                            Sigla = "SP"
                        },
                        new
                        {
                            Id = 26,
                            Sigla = "SE"
                        },
                        new
                        {
                            Id = 27,
                            Sigla = "TO"
                        });
                });

            modelBuilder.Entity("ControleFornecedoresEmpresaAPI.Models.TipoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBTipoPessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tipo = "Jurídica"
                        },
                        new
                        {
                            Id = 2,
                            Tipo = "Física"
                        });
                });

            modelBuilder.Entity("ControleFornecedoresEmpresaAPI.Models.Empresa", b =>
                {
                    b.HasOne("ControleFornecedoresEmpresaAPI.Models.SiglasUF", "SiglasUF")
                        .WithMany()
                        .HasForeignKey("SiglasUFId");

                    b.Navigation("SiglasUF");
                });

            modelBuilder.Entity("ControleFornecedoresEmpresaAPI.Models.Fornecedor", b =>
                {
                    b.HasOne("ControleFornecedoresEmpresaAPI.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.HasOne("ControleFornecedoresEmpresaAPI.Models.TipoPessoa", "TipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaId");

                    b.Navigation("Empresa");

                    b.Navigation("TipoPessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
