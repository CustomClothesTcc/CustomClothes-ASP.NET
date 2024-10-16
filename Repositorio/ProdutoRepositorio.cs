using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

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
                MySqlCommand cmd = new MySqlCommand("insert into tbProduto values(default, @Descricao, @Categoria, @Cor, @Estampa, @Quantidade, @Tamanho, @Valor)", conexao);
                cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                cmd.Parameters.Add("@Categoria", MySqlDbType.VarChar).Value = produto.Categoria;
                cmd.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = produto.Cor;
                cmd.Parameters.Add("@Estampa", MySqlDbType.VarChar).Value = produto.Estampa;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.VarChar).Value = produto.Quantidade;
                cmd.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = produto.Tamanho;
                cmd.Parameters.Add("@Valor", MySqlDbType.VarChar).Value = produto.Valor;
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
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto where CodProduto = @CodProduto", conexao);
                cmd.Parameters.Add("@CodProduto", MySqlDbType.VarChar).Value = Id;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Produto produto = new Produto();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    produto.CodProduto = Convert.ToInt32(dr["CodProduto"]);
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

        public IEnumerable<Produto> ObterTodosProdutos()
        {
            List<Produto> ProdutoList = new List<Produto>();
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
                        new Produto
                        {
                            CodProduto = Convert.ToInt32(dr["CodProduto"]),
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
