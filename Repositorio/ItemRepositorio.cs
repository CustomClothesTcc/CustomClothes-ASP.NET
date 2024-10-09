using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;

namespace CustomClothing.Repositorio
{
    public class ItemRepositorio: IitemRepositorio
    {
        //Conexao com o DataBase
        private readonly string _conexaoMySQL;
        public ItemRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Item item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Item item)
        {
           using(var conexao= new MySqlConnection(_conexaoMySQL))
            {
             conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbItemPedido values(default, @CodItemPedido, @CodProduto, @Valor, @ValorTotal)", conexao);
                cmd.Parameters.Add("@CodItemPedido", MySqlDbType.Int32).Value = item.CodItemPedido;
                cmd.Parameters.Add("@CodProduto", MySqlDbType.Int32).Value = item.CodProduto;

            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Item ObterItens(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> ObterTodosItens()
        {
            throw new NotImplementedException();
        }
    }
}
