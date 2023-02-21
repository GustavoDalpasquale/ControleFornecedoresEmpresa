using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFornecedoresEmpresaAPI.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [ForeignKey("TipoPessoa")]
        public int IdTipoPessoa { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0}: Máximo de 60 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor, coloque apenas números.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "{0}: coloque 11 (CPF) ou 14 (CNPJ) caracteres.")]
        public string CPFCNPJ { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime DataHoraCadastro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }


        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor, coloque apenas números.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "{0} deve ter apenas 7 caracteres.")]
        public string? RG { get; set; }

        //Teste array
        public string[] NumTel;
    }
}
