namespace CustomClothing.Cookie
{
    public class Cookies
    {
        private IHttpContextAccessor _context;
        private IConfiguration _configuration;
        public Cookies(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Cadastrar(string Key, string Valor)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(3);
            options.IsEssential = true;

            _context.HttpContext.Response.Cookies.Append(Key, Valor, options);
        }
        public void Remover(string Key)
        {
            _context.HttpContext.Response.Cookies.Delete(Key);
        }
        public string Consultar(string Key, bool Cript = true)
        {
            var valor = _context.HttpContext.Request.Cookies[Key];
            return valor;
        }
        public bool Existe(string Key)
        {
            if (_context.HttpContext.Request.Cookies[Key] == null)
            {
                return false;
            }
            return true;
        }
        public void Atualizar(string Key, string valor)
        {
            if (Existe(Key))
            {
                Remover(Key);
            }
            Cadastrar(Key, valor);
        }
        public void RemoverTodos()
        {
            var ListaCookie = _context.HttpContext.Request.Cookies.ToList();
            foreach (var Cookie in ListaCookie)
            {
                Remover(Cookie.Key);
            }
        }
    }
}
