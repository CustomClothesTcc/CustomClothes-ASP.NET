using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IitemRepositorio
    {

        //CRUD do nosso Sistema
        IEnumerable<Item> ObterTodosItens();
        void Cadastrar(Item item);
        void Atualizar(Item item);
        Item ObterItens(int Id);
        void Excluir(int Id);
    }
}
