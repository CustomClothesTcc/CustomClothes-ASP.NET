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
                MySqlCommand cmd = new MySqlCommand("insert into tbItemPedido values(default, @CodItemPedido, @CodProduto, @Valor, @ValorTotal)", conexao);
                cmd.Parameters.Add("@CodItemPedido", MySqlDbType.Int32).Value = item.CodItemPedido;
                cmd.Parameters.Add("@CodProduto", MySqlDbType.Int32).Value = item.CodProduto;
                cmd.Parameters.Add("@Valor", MySqlDbType.Decimal).Value = item.Valor;
                cmd.Parameters.Add("@ValorTotal", MySqlDbType.Decimal).Value = item.ValorTotal;
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
                            CodItemPedido = Convert.ToInt32(dr["CodItemPedido"]),
                            CodProduto = Convert.ToInt32(dr["CodProduto"]),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                            ValorTotal = Convert.ToDecimal(dr["ValorTotal"])
                        });
                }
                return ItemList;
            }

        }
    }
}
