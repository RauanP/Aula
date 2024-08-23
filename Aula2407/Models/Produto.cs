namespace Aula2407.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Marca {  get; set; } = string.Empty;
        public int Quantidade { get; set; } 
        public string Valor { get; set; } = string.Empty;
    }
}
