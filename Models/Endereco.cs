namespace CustomClothing.Models
{
    public class Endereco
    {
        //Representando a tabela Endereco no ASP
        public int IdEnd { get; set; }

        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? CEP { get; set; }
        public string? Complemnto { get; set; }
        public Funcionario CPFunc { get; set; }
        public List<Funcionario> ListaFuncionarios { get; set; }
        public Cliente CPF { get; set; }
        public List<Cliente> ListaClientes { get; set; }
    }
}