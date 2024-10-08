using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using MySql.Data.MySqlClient;

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
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbProduto values(default,@ImagemProduto, @Descricao, @Categoria, @Cor, @Estampa, @Quantidade, @Tamanho, @Valor)", conexao);
                cmd.Parameters.Add("@ImagemProduto", MySqlDbType.VarChar).Value = produto.ImagemProduto;
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
          using(var conexao = new MySqlConnection(_conexaoMySQL))
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
                    produto.ImagemProduto = (String)(dr["ImagemProduto"]);
                    produto.Descricao = (String)(dr["Descricao"]);
                    produto.Cor = (String)(dr["Cor"]);
                    produto.Estampa = (String)(dr["Estampa"]);
                    produto.Quantidade = Convert.ToInt32(dr["Quantidade"]);
                    produto.Tamanho = (String)(dr["Tamanho"]);
                    produto.Valor = Convert.ToDecimal(dr["Valor"]);
                }
                return produto;
          }
        }

        public IEnumerable<Produto> ObterTodosProdutos()
        {
            throw new NotImplementedException();
        }
    }
}
