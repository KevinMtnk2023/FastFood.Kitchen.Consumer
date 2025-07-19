using Dapper;
using FastFood.Kitchen.Consumer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Kitchen.Consumer.Infrastructure.Persistence
{
    public class PedidoCozinhaRepository(IConfiguration configuration) : IPedidoCozinhaRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");

        public async Task AddPedidoCozinhaAsync(PedidoCozinha pedidoCozinha)
        {
            // Garantir que a DataCriacao e DataAlteracao sejam atualizadas antes de salvar
            pedidoCozinha.DataCriacao = DateTime.Now;

            const string query = @"
            INSERT INTO kitchen_events (order_id, action, justification, created_at) 
            VALUES (@PedidoId, @Status, @MotivoCancelamento, @DataCriacao);";

            Console.WriteLine($"PedidoId: {pedidoCozinha.PedidoId}, Status: {pedidoCozinha.Status}, MotivoCancelamento: {pedidoCozinha.MotivoCancelamento}, DataCriacao: {pedidoCozinha.DataCriacao}");

            using var connection = new MySqlConnection(_connectionString);

            await connection.ExecuteAsync(query, pedidoCozinha);
        }
    }
}
