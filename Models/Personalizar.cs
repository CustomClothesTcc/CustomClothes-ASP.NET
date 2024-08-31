namespace CustomClothing.Models
{
    public class Personalizar
    {
        //Criando encapsulamento do objeto com get e set
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public string? Tamanho { get; set; }
        public string? Tecido { get; set; }
        public string? Estampa { get; set; }
        public int Preco { get; set; }
    }
}
