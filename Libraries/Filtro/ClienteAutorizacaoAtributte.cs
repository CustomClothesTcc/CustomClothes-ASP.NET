using CustomClothing.Libraries.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace CustomClothing.Libraries.Filtro
{
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Models.Cliente cliente = _loginCliente.GetCliente();
            if (cliente == null)
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
        }
    }
}
