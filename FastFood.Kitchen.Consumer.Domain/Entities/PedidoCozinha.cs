namespace FastFood.Kitchen.Consumer.Domain.Entities
{
    public class PedidoCozinha
    {
        public decimal Id { get; set; }
        public decimal PedidoId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? MotivoCancelamento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;
    }
}
