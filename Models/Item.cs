namespace CustomClothing.Models
{
    public class Item
    {
        //Criando encapsulamento do objeto com get e set
        public int IdItem { get; set; }
        public int IdProduto { get; set; }
        public int IdPedido { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
