using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace CustomClothing.Repositorio
{
    public class ItemRepositorio : IitemRepositorio
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
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbItemPedido values(default, @IdItem, @IdProduto, @IdPedido, @Quantidade, @ValorUnit)", conexao);
                cmd.Parameters.Add("@IdItem", MySqlDbType.Int32).Value = item.IdItem;
                cmd.Parameters.Add("@IdProduto", MySqlDbType.Int32).Value = item.IdProduto;
                cmd.Parameters.Add("@IdPedido", MySqlDbType.Int32).Value = item.IdPedido;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.Int32).Value = item.Quantidade;
                cmd.Parameters.Add("@ValorUnit", MySqlDbType.Decimal).Value = item.Valor;
                cmd.ExecuteNonQuery();
                conexao.Close();
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
            List<Item> ItemList = new List<Item>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbItemPedido;", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(
                        new Item
                        {
                            IdItem = Convert.ToInt32(dr["IdItem"]),
                            IdProduto = Convert.ToInt32(dr["IdProduto"]),
                            Quantidade = Convert.ToInt32(dr["Quantidade"]),
                            Valor = Convert.ToDecimal(dr["ValorUnit"])
                        });
                }
                return ItemList;
            }

        }
    }
}
