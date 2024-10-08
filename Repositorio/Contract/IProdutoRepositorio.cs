using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IProdutoRepositorio
    {
        //CRUD do nosso Sistema
        IEnumerable<Produto> ObterTodosProdutos();
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        Produto ObterProdutos(int Id);
        void Excluir(int Id);
    }
}
