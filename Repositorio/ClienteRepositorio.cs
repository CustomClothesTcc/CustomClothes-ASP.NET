using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace CustomClothing.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        //Conexao com o DataBase
        private readonly string _conexaoMySQL;
        public ClienteRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("CALL pcd_AtualizarCliente(@CPF, @RG, @Nome, @DataNans, @Celular, @Sexo, @Email, @Senha)", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = cliente.RG;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@DataNans", MySqlDbType.Date).Value = cliente.DataNans.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@Celular", MySqlDbType.VarChar).Value = cliente.Celular;
                cmd.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = cliente.Sexo;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }


        public void Cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("CALL pcd_CadastrarCliente(@CPF,@RG,@Nome,@DataNans,@Celular,@Sexo,@Email,@Senha)", conexao);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = cliente.RG;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@DataNans", MySqlDbType.Date).Value = cliente.DataNans.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@Celular", MySqlDbType.VarChar).Value = cliente.Celular;
                cmd.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = cliente.Sexo;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(string CPF)
        {
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("CALL pcd_DeletarClientepcd_LoginCliente(@CPF)", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CPF", CPF);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Cliente Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("CALL pcd_LoginCliente(@Email, @Senha)", conexao);
                //MySqlCommand cmd = new MySqlCommand("CALL pcd_LoginCliente(@Email, @Senha)", conexao);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.CPF = Convert.ToString(dr["CPF"]);
                    cliente.RG = Convert.ToString(dr["RG"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DataNans = DateOnly.FromDateTime((DateTime)dr["DataNans"]);
                    cliente.Celular = Convert.ToString(dr["Celular"]);
                    cliente.Sexo = Convert.ToString(dr["Sexo"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;
            }
        }

        public Cliente ObterClientes(string CPF)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("CALL pcd_ExibirCliente(@CPF)", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CPF", CPF);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.CPF = Convert.ToString(dr["CPF"]);
                    cliente.RG = Convert.ToString(dr["RG"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DataNans = DateOnly.FromDateTime((DateTime)dr["DataNans"]);
                    cliente.Celular = Convert.ToString(dr["Celular"]);
                    cliente.Sexo = Convert.ToString(dr["Sexo"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;
            }
        }

        public Cliente ObterNomeCliente(string Nome)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("CALL pcd_ExibirCliente_Nome(@Nome)", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", Nome);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.CPF = Convert.ToString(dr["CPF"]);
                    cliente.RG = Convert.ToString(dr["RG"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DataNans = DateOnly.FromDateTime((DateTime)dr["DataNans"]);
                    cliente.Celular = Convert.ToString(dr["Celular"]);
                    cliente.Sexo = Convert.ToString(dr["Sexo"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;
            }
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            List<Cliente> clienteList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbCliente", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    clienteList.Add(
                        new Cliente
                        {
                            CPF = Convert.ToString(dr["CPF"]),
                            RG = (string)(dr["RG"]),
                            Nome = (string)(dr["Nome"]),
                            DataNans = DateOnly.FromDateTime((DateTime)dr["DataNans"]),
                            Celular = (string)(dr["Celular"]),
                            Sexo = (string)(dr["Sexo"]),
                            Email = (string)(dr["Email"]),
                            Senha = (string)(dr["Senha"])
                        }) ;
                }
                return clienteList;
            }
        }
    }
}