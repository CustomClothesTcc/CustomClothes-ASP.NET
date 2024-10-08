using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace CustomClothing.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly string _conexaoMySQL;
        IConfiguration _config;
        public PedidoRepositorio(IConfiguration conf, IConfiguration config)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
            _config = config;
        }
        public void Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pedido pedido)
        {
          using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbPedido " + " values(default, @IdPedido,  @DataPedido, @codCli, @Status)", conexao);

                cmd.Parameters.Add("@IdPedido", MySqlDbType.Int64).Value= pedido.IdPedido;
                cmd.Parameters.Add("@DataPedido", MySqlDbType.Datetime).Value = pedido.DataPedido;
                cmd.Parameters.Add("@codCli", MySqlDbType.Int64).Value = pedido.CodCliente;
                cmd.Parameters.Add("@Status", MySqlDbType.VarChar).Value = pedido.Status;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Pedido ObterProdutos(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterTodosPedidos()
        {
            List<Pedido> ListCat = new List<Pedido>();
            using(var conexao= new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tb tbPedido;", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexao.Close();
                foreach(DataRow dr in dt.Rows)
                {
                    ListCat.Add(
                        new Pedido
                        {
                           IdPedido = Convert.ToInt32(dr["id"]),
                           DataPedido = Convert.ToDateTime(dr["DataPedido"]),
                           CodCliente = Convert.ToInt32(dr["CodCliente"]),
                           Status = (string)(dr["Status"])
                        });
                    return ListCat;
                }
            }
        }
    }
}
