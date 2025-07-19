namespace FastFood.Kitchen.Consumer.Application.DTO
{
    public static class PedidoCozinhaDtoExtensions 
    {
        public static Domain.Entities.PedidoCozinha ToEntity(this PedidoCozinhaDto dto)
        {
            return new Domain.Entities.PedidoCozinha
            {
                Id = dto.Id,
                PedidoId = dto.PedidoId,
                Status = dto.Status,
                MotivoCancelamento = dto.MotivoCancelamento,
                DataCriacao = dto.DataCriacao,
                DataAlteracao = dto.DataAlteracao
            };
        }
    }
}
