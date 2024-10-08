using CustomClothing.Models;

namespace CustomClothing.Repositorio.Contract
{
    public interface IPedidoRepositorio
    {
        //CRUD do nosso Sistema
        IEnumerable<Pedido> ObterTodosPedidos();
        void Cadastrar(Pedido pedido);
        void Atualizar(Pedido pedido);
        Pedido ObterProdutos(int Id);
        void Excluir(int Id);
    }
}
