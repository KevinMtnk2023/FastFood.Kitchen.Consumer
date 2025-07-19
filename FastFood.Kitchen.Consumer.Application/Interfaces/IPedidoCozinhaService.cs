using FastFood.Kitchen.Consumer.Domain.Entities;

namespace FastFood.Kitchen.Consumer.Application.Interfaces
{
    public interface IPedidoCozinhaService
    {
        Task SalvarPedidoCozinhaAsync(PedidoCozinha pedidoCozinha);
    }
}
