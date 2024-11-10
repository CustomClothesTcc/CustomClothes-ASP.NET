using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IProdutoRepositorio
    {
        //CRUD do nosso Sistema
        IEnumerable<Produto> ObterTodosProdutos();
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(int Id);
        Produto ObterProdutos(int Id);
    }
}
