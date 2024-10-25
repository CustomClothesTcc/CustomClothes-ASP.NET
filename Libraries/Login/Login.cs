using CustomClothing.Libraries.Sessao;

namespace CustomClothing.Libraries.Login
{
    public class Login
    {
        private string Key = "Login";
        private Sessao.Sessao _sessao;

        public Login(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }
    }
}
