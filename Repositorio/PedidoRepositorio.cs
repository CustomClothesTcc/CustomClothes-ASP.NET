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
                MySqlCommand cmd = new MySqlCommand("insert into tbPedido values(default, @DataPedido, @ValorTotal, @PedidoStatus, @Quantidade, @CPFCli)", conexao);
                                
                cmd.Parameters.Add("@DataPedido", MySqlDbType.VarChar).Value = pedido.DataPedido;
                cmd.Parameters.Add("@ValorTotal", MySqlDbType.Decimal).Value = pedido.ValorTotal;
                cmd.Parameters.Add("@PedidoStatus", MySqlDbType.VarChar).Value = pedido.PedidoStatus;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.Int64).Value = pedido.Quantidade;
                cmd.Parameters.Add("@CPFCli", MySqlDbType.VarChar).Value = pedido.CPFCli;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }

        }
        public void buscarIdPedido(Pedido pedido)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlDataReader dr;

                MySqlCommand cmd = new MySqlCommand("SELECT IdPedido FROM tbPedido ORDER BY IdPedido DESC limit 1", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pedido.IdPedido = dr[0].ToString();
                }
                conexao.Close();

            }

        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Pedido ObterPedidos(int Id)
        {
            throw new NotImplementedException();
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
                            IdPedido = Convert.ToString(dr["IdPedido"]),
                            DataPedido = Convert.ToString(dr["DataPedido"]),
                            ValorTotal = Convert.ToDecimal(dr["ValorTotal"]),
                            PedidoStatus = Convert.ToString(dr["PedidoStatus"]),
                            Quantidade = Convert.ToInt32(dr["Quantidade"]),
                            CPFCli = Convert.ToString(dr["CPFCli"])
                        });
                }
                return PedidoList;
            }

        }
    }
}
