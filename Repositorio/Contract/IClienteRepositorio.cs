using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IClienteRepositorio
    {
        //CRUD do nosso Sistema
        IEnumerable<Cliente> ObterTodosClientes();
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        Cliente ObterClientes(int Id);
        void Excluir(int Id);
    }
}
