using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MySql.Data.MySqlClient;
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
                MySqlCommand cmd = new MySqlCommand("insert into tbCliente(CPF, RG,Nome,DataNasc,Celular,Sexo,Email,Senha) values(@CPF,@RG,@Nome,@DataNasc,@Celular,@Sexo,@Email,@Senha)", conexao);
                cmd.Parameters.Add("@CPF", MySqlDbType.Int64).Value = cliente.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = cliente.RG;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.Date).Value = cliente.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@Celular", MySqlDbType.VarChar).Value = cliente.Celular;
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
                MySqlCommand cmd = new MySqlCommand("insert into tbCliente(CPF, RG,Nome,DataNasc,Celular,Sexo,Email,Senha) values(@CPF,@RG,@Nome,@DataNasc,@Celular,@Sexo,@Email,@Senha)", conexao);
                cmd.Parameters.Add("@CPF", MySqlDbType.Int64).Value = cliente.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = cliente.RG;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.Date).Value = cliente.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@Celular", MySqlDbType.VarChar).Value = cliente.Celular;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete * from Cliente where Id=@Id", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Cliente Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from tbCliente where Email= @Email and Senha =@Senha", conexao);
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.CPF = Convert.ToInt32(dr["CPF"]);
                    cliente.RG = Convert.ToString(dr["RG"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DataNasc = Convert.ToDateTime(dr["Nascimento"]);
                    cliente.Celular = Convert.ToString(dr["Celular"]);
                    cliente.Sexo = Convert.ToString(dr["Sexo"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;
            }
        }

        public Cliente ObterClientes(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from tbCliente where CPF =@CPF", conexao);
                cmd.Parameters.AddWithValue("@CPF", Id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.CPF = Convert.ToInt32(dr["CPF"]);
                    cliente.RG = Convert.ToString(dr["RG"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DataNasc = Convert.ToDateTime(dr["Nascimento"]);
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
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    clienteList.Add(
                        new Cliente
                        {
                            CPF = Convert.ToInt32(dr["CPF"]),
                            RG = (string)(dr["RG"]),
                            Nome = (string)(dr["Nome"]),
                            DataNasc = Convert.ToDateTime(dr["Nascimento"]),
                            Celular = (string)(dr["Celular"]),
                            Sexo = (string)(dr["Sexo"]),
                            Email = (string)(dr["Email"]),
                            Senha = (string)(dr["Senha"])
                        });
                }
                return clienteList;
            }
        }
    }
}
