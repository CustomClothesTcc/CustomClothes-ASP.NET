namespace CustomClothing.Models
{
    public class Cliente
    {
        //Criando encapsulamento do objeto com get e set
        public int CodCliente { get; set; }
        public int CPF { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Celular { get; set; }
        public string Sexo  { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
