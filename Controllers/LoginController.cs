using CustomClothing.Libraries.Filtro;
using CustomClothing.Libraries.Login;
using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class LoginController : Controller
    {
        //Injeção de dependência
        private IClienteRepositorio _clienteRepositorio;
        private LoginCliente _logincliente;
        public LoginController(IClienteRepositorio clienteRepositorio, LoginCliente logincliente)
        {
            _clienteRepositorio = clienteRepositorio;
            _logincliente = logincliente;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {
            Cliente clienteDB = _clienteRepositorio.Login(cliente.Email, cliente.Senha);
            if (clienteDB.Email != null && clienteDB.Senha != null)
            {
                _logincliente.Login(clienteDB);
                return new RedirectResult(Url.Action(nameof(PerfilCliente)));
            }
            else
            {
                //Erro na sessão
                ViewData["MSG_E"] = "Usuario não localizado, por favor verifique e-mail e senha digitado";
                return View();
            }
        }
        public IActionResult PerfilCliente()
        {
            return View();
        }

        [ClienteAutorizacao]
        public IActionResult LogoutCliente()
        {
            _logincliente.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Cliente cliente)
        {
            _clienteRepositorio.Cadastrar(cliente);
            return RedirectToAction(nameof(Login));
        }
    }
}
