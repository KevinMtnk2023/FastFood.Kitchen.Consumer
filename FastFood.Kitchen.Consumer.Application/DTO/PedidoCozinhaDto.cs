using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FastFood.Kitchen.Consumer.Application.DTO
{
    public class PedidoCozinhaDto
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("pedidoId")]
        public decimal PedidoId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("motivoCancelamento")]
        public string MotivoCancelamento { get; set; } = string.Empty;

        [JsonPropertyName("dataCriacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("dataAlteracao")]
        public DateTime DataAlteracao { get; set; }
    }
}
