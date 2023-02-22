using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class OrderRepository<Order> : IOrderRepository<Order>
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory Conn) 
        {
            _connectionFactory = Conn;
        }
        public async Task<int> AddAsync(Order entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "INSERT into Orders (OrderId,OrderNumber,CustomerId,ShoppingCartId) VALUES (@OrderId,@OrderNumber,@CustomerId,@ShoppingCartId)";
                connection.Open();
                var result = await Task.Run(() => connection.Execute(sql, entity));
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "DELETE FROM Orders WHERE OrderId = @OrderId";
                connection.Open();
                var result = await Task.Run(() => connection.Execute(sql, new {OrderId = id}));
                return result;
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Orders";
                var result = await Task.Run(() => SqlMapper.Query<Order>(connection, sql).ToList());
                return result;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Orders WHERE OrderId = @OrderId";
                connection.Open();
                var result = await Task.Run(() => connection.QuerySingleOrDefault<Order>(sql, new { OrderId = id }));
                return result;
            }
        }

        public async Task<Order> GetOrderByCustomerIdAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection) 
            {
                var sql = "SELECT * FROM Orders WHERE CustomerId = @Id";
                connection.Open();
                var result = await Task.Run(() => connection.QuerySingleOrDefault<Order>(sql, new { Id = id }));
                return result;
            }
        }

        public async Task<int> UpdateAsync(Order entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "UPDATE Orders SET OrderNumber = @OrderNumber, CustomerId = @CustomerId, ShoppingCartId = @ ShoppingCartId VALUES (@OrderNumber,@CustomerId,@ShoppingCartId)";
                connection.Open();
                var result = await Task.Run(() => connection.Execute(sql, entity));
                return result;
            }
        }
    }
}
