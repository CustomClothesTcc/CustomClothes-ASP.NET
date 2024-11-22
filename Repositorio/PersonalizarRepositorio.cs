using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace CustomClothing.Repositorio
{
    public class PersonalizarRepositorio : IPersonalizarRepositorio
    {
        //Conexao com o DataBase
        private readonly string _conexaoMySQL;
        public PersonalizarRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Personalizar produto)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Personalizar produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbProduto(Tecido, Descricao,Cor,Estampa,Quantidade,Tamanho,Valor) values(@Tecido, @Descricao, @Cor,@Estampa, @Quantidade, @Tamanho, @Valor)", conexao);
                cmd.Parameters.Add("@Tecido", MySqlDbType.VarChar).Value = produto.Tecido;
                cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                cmd.Parameters.Add("@Categoria", MySqlDbType.VarChar).Value = produto.Categoria;
                cmd.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = produto.Cor;
                cmd.Parameters.Add("@Estampa", MySqlDbType.VarChar).Value = produto.Estampa;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.Int64).Value = produto.Quantidade;
                cmd.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = produto.Tamanho;
                cmd.Parameters.Add("@Valor", MySqlDbType.Decimal).Value = produto.Valor;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Personalizar ObterProdutos(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto where IdProduto = @IdProduto", conexao);
                cmd.Parameters.Add("@IdProduto", MySqlDbType.VarChar).Value = Id;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Personalizar produto = new Personalizar();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    produto.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                    produto.Tecido = (string)(dr["Tecido"]);
                    produto.Descricao = (string)(dr["Descricao"]);
                    produto.Cor = (string)(dr["Cor"]);
                    produto.Estampa = (string)(dr["Estampa"]);
                    produto.Quantidade = Convert.ToInt32(dr["Quantidade"]);
                    produto.Tamanho = (string)(dr["Tamanho"]);
                    produto.Valor = Convert.ToDecimal(dr["Valor"]);
                }
                return produto;
            }
        }

        public IEnumerable<Personalizar> ObterTodosProdutos()
        {
            List<Personalizar> ProdutoList = new List<Personalizar>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    ProdutoList.Add(
                        new Personalizar
                        {
                            IdProduto = Convert.ToInt32(dr["IdProduto"]),
                            Tecido = (string)(dr["Tecido"]),
                            Descricao = (string)(dr["Descricao"]),
                            Cor = (string)(dr["Cor"]),
                            Estampa = (string)(dr["Estampa"]),
                            Quantidade = Convert.ToInt32(dr["Quantidade"]),
                            Tamanho = (string)(dr["Tamanho"]),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                        });
                }
                return ProdutoList;
            }
        }
    }
}
