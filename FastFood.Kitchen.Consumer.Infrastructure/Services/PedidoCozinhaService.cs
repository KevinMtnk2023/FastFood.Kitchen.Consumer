using FastFood.Kitchen.Consumer.Application.Interfaces;
using FastFood.Kitchen.Consumer.Domain.Entities;
using FastFood.Kitchen.Consumer.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Kitchen.Consumer.Infrastructure.Services
{
    public class PedidoCozinhaService : IPedidoCozinhaService
    {
        private readonly IPedidoCozinhaRepository _pedidoCozinhaRepository;
        public PedidoCozinhaService(IPedidoCozinhaRepository pedidoCozinhaRepository)
        {
            _pedidoCozinhaRepository = pedidoCozinhaRepository;
        }
        public async Task SalvarPedidoCozinhaAsync(PedidoCozinha pedidoCozinha)
        {
            // Garantir que a DataCriacao e DataAlteracao sejam atualizadas antes de salvar
            pedidoCozinha.DataCriacao = DateTime.Now;
            pedidoCozinha.DataAlteracao = DateTime.Now;
            await _pedidoCozinhaRepository.AddPedidoCozinhaAsync(pedidoCozinha);
        }

    }
}
