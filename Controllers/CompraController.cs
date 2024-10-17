using CustomClothing.CarrinhoCompra;
using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class CompraController : Controller
    {
        private CookiesCarrinhoCompra _cookiesCarrinhoCompra;
        private IProdutoRepositorio _produtoRepositorio;
        private IitemRepositorio _itemRepositorio;
        public CompraController(IProdutoRepositorio produtoRepositorio, CookiesCarrinhoCompra cookiesCarrinhoCompra, IitemRepositorio itemRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _cookiesCarrinhoCompra = cookiesCarrinhoCompra;
            _itemRepositorio = itemRepositorio;
        }
        public IActionResult AdicionarItem(int id)
        {
            Produto produto = _produtoRepositorio.ObterProdutos(id);

            if (produto == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new Produto()
                {
                    CodProduto = id,
                    Descricao = produto.Descricao,
                    Estampa = produto.Estampa,
                    Tamanho = produto.Tamanho,
                    Valor = produto.Valor
                };
                _cookiesCarrinhoCompra.Cadastrar(item);
                return RedirectToAction(nameof(Carrinho));
            }
        }
        public object Carrinho()
        {
            return View(_cookiesCarrinhoCompra.Consultar());
        }
    }
}
