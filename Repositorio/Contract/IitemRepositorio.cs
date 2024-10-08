using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IitemRepositorio
    {

        //CRUD do nosso Sistema
        IEnumerable<Item> ObterTodosPedidos();
        void Cadastrar(Item item);
        void Atualizar(Item item);
        Item ObterProdutos(int Id);
        void Excluir(int Id);
    }
}
