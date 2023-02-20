using System.ComponentModel.DataAnnotations;

namespace ControleFornecedoresEmpresaAPI.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]

        public SiglasUF SiglasUF { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0}: Máximo de 60 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor, coloque apenas números.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} deve ter 14 caracteres.")]
        public string CNPJ { get; set; }
    }
}
