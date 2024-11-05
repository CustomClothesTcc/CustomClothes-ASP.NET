using CustomClothing.Libraries.Sessao;
using CustomClothing.Models;
using Newtonsoft.Json;

namespace CustomClothing.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login";
        private Sessao.Sessao _sessao;

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }
        public void Login(Cliente cliente)
        {
            //Serializar
            string clienteJSONString = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastrar(Key, clienteJSONString);
        }
        //Reverter Json para objeto cliente
        public Cliente GetCliente()
        {
            //Deserializar
            if (_sessao.Existe(Key))
            {
               string clienteJSONString= _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }
        //Remover a sessao e deslogar o Cliente
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
