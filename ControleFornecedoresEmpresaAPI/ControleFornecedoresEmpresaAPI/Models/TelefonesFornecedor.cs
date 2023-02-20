namespace ControleFornecedoresEmpresaAPI.Models
{
    public class TelefonesFornecedor
    {
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public string Telefone { get; set; }
    }
}
