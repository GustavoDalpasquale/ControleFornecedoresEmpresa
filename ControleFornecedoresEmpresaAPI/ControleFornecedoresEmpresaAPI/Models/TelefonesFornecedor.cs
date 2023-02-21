using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFornecedoresEmpresaAPI.Models
{
    public class TelefonesFornecedor
    {
        public int Id { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public string Telefone { get; set; }
    }
}
