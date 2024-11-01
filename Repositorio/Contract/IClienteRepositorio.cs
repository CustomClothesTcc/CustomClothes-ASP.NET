using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IClienteRepositorio
    {
        //CRUD do nosso Sistema
        Cliente Login(string Email, string Senha);
        IEnumerable<Cliente> ObterTodosClientes();
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        Cliente ObterClientes(string CPF);
        Cliente ObterNomeCliente(string Nome);
        void Excluir(string CPF);
    }
}
