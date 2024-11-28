using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace CustomClothing.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        //Conexao com o DataBase
        private readonly string _conexaoMySQL;
        public ProdutoRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbProduto(Tecido, Descricao,Categoria,Cor,Estampa,Quantidade,Tamanho,Situacao,Valor) values(@Tecido, @Descricao,@Categoria, @Cor,@Estampa, @Quantidade, @Tamanho,@Situacao, @Valor)", conexao);
                cmd.Parameters.Add("@Tecido", MySqlDbType.VarChar).Value = produto.Tecido;
                cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                cmd.Parameters.Add("@Categoria", MySqlDbType.VarChar).Value = produto.Categoria;
                cmd.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = produto.Cor;
                cmd.Parameters.Add("@Estampa", MySqlDbType.VarChar).Value = produto.Estampa;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.Int64).Value = produto.Quantidade;
                cmd.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = produto.Tamanho;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = produto.Situacao;
                cmd.Parameters.Add("@Valor", MySqlDbType.Decimal).Value = produto.Valor;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Produto ObterProdutos(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto where IdProduto = @IdProduto", conexao);
                cmd.Parameters.Add("@IdProduto", MySqlDbType.VarChar).Value = Id;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Produto produtos = new Produto();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    produtos.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                    produtos.Tecido = (string)(dr["Tecido"]);
                    produtos.Descricao = (string)(dr["Descricao"]);
                    produtos.Categoria = Convert.ToString(dr["Categoria"]);
                    produtos.Cor = (string)(dr["Cor"]);
                    produtos.Estampa = (string)(dr["Estampa"]);
                    produtos.Quantidade = Convert.ToInt32(dr["Quantidade"]);
                    produtos.Tamanho = (string)(dr["Tamanho"]);
                    produtos.Situacao = (string)(dr["Situacao"]);
                    produtos.Valor = Convert.ToDecimal(dr["Valor"]);
                }
                return produtos;
            }
        }

        public IEnumerable<Produto> ObterTodosProdutos()
        {
            List<Produto> ProdutoList = new List<Produto>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto where Situacao = 'EM ESTOQUE'", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    ProdutoList.Add(
                        new Produto
                        {
                            IdProduto = Convert.ToInt32(dr["IdProduto"]),
                            Tecido = (string)(dr["Tecido"]),
                            Descricao = (string)(dr["Descricao"]),
                            Categoria = Convert.ToString(dr["Categoria"]),
                            Cor = (string)(dr["Cor"]),
                            Estampa = (string)(dr["Estampa"]),
                            Quantidade = Convert.ToInt32(dr["Quantidade"]),
                            Tamanho = (string)(dr["Tamanho"]),
                            Situacao = Convert.ToString(dr["Situacao"]),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                        });
                }
                return ProdutoList;
            }
        }
    }
}