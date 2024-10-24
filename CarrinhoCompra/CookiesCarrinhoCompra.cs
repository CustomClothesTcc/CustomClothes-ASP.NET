﻿using CustomClothing.Models;
using Newtonsoft.Json;

namespace CustomClothing.CarrinhoCompra
{
    public class CookiesCarrinhoCompra
    {
        private string Key = "Carrinho.Compras";
        private Cookie.Cookies _cookies;

        public CookiesCarrinhoCompra(Cookie.Cookies cookies)
        {
            _cookies = cookies; 
        }

        public void Salvar(List<Personalizar> Lista)
        {
          string Valor = JsonConvert.SerializeObject(Lista);
          _cookies.Cadastrar(Key, Valor);
        }
        public List<Personalizar> Consultar()
        {
            if (_cookies.Existe(Key))
            {
                string valor = _cookies.Consultar(Key);
                return JsonConvert.DeserializeObject<List<Personalizar>>(valor);
            }
            else
            {
                return new List<Personalizar>();
            }
        }

        public void Cadastrar(Personalizar item)
        {
            List<Personalizar> Lista;

            if (_cookies.Existe(Key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.IdProduto == item.IdProduto);

                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                   // ItemLocalizado.Quantidade = ItemLocalizado.Quantidade + 1;
                }
            }
            else
            {
                Lista = new List<Personalizar>();
                Lista.Add(item);
            }
            Salvar(Lista);
        }

        public void Atualizar(Personalizar item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.IdProduto == item.IdProduto);

            if (ItemLocalizado != null)
            {
                ItemLocalizado.Quantidade = ItemLocalizado.Quantidade + 1;
                Salvar(Lista);
            }
        }
        public void Remover(Personalizar item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.IdProduto == item.IdProduto);

            if (ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }
        public bool Existe(string Key)
        {
            if (_cookies.Existe(Key))
            {
                return false;
            }
            return true;
        }
        public void Removertodos()
        {
            _cookies.Remover(Key);
        }
    }
}
