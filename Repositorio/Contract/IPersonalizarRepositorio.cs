using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IPersonalizarRepositorio
    {
        //CRUD do nosso Sistema
        IEnumerable<Personalizar> ObterTodosProdutos();
        void Cadastrar(Personalizar produto);
        void Atualizar(Personalizar produto);
        Personalizar ObterProdutos(int Id);
        void Excluir(int Id);
    }
}
