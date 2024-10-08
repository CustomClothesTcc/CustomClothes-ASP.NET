namespace CustomClothing.Models
{
    public class Pedido
    {
        //Criando encapsulamento do objeto com get e set
        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int CodCliente { get; set; }

    }
}
