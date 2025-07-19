using FastFood.Kitchen.Consumer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Kitchen.Consumer.Infrastructure.Persistence
{
    public interface IPedidoCozinhaRepository
    {
        Task AddPedidoCozinhaAsync(PedidoCozinha pedidoCozinha);
    }
}
