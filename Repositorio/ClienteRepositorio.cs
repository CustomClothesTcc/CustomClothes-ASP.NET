using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;

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
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterClientes(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
