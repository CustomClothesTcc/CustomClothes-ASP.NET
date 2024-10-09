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
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbPedido " + " values(default, @IdPedido,  @DataPedido, @codCli, @Status)", conexao);

                cmd.Parameters.Add("@IdPedido", MySqlDbType.Int64).Value = pedido.IdPedido;
                cmd.Parameters.Add("@DataPedido", MySqlDbType.DateTime).Value = pedido.DataPedido;
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

        public Pedido ObterPedidos(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbPedido where IdPedido = @IdPedido", conexao);
                cmd.Parameters.Add("@IdPedido", MySqlDbType.VarChar).Value = Id;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Pedido pedido = new Pedido();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    pedido.IdPedido = Convert.ToInt32(dr["IdPedido"]);
                    pedido.DataPedido = Convert.ToDateTime(dr["DataPedido"]);
                    pedido.CodCliente = Convert.ToInt32(dr["CodCli"]);
                    pedido.Status = (string)(dr["Status"]);
                }
                return pedido;
            }
        }

        public IEnumerable<Pedido> ObterTodosPedidos()
        {
            List<Pedido> PedidoList = new List<Pedido>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbPedido;", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    PedidoList.Add(
                        new Pedido
                        {
                            IdPedido = Convert.ToInt32(dr["IdPedido"]),
                            DataPedido = Convert.ToDateTime(dr["DataPedido"]),
                            CodCliente = Convert.ToInt32(dr["CodCliente"]),
                            Status = (string)(dr["Status"])
                        });
                }
                return PedidoList;
            }

        }
    }
}
