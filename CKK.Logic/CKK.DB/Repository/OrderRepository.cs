using CKK.DB.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class OrderRepository<Order> : IOrderRepository<Order>
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory Conn) //Connect to database
        {
            _connectionFactory = Conn;
        }

        public async Task<int> AddAsync(Order entity) //Adds an Order
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "INSERT into Orders (OrderId,OrderNumber,CustomerId,ShoppingCartId) VALUES (@OrderId,@OrderNumber,@CustomerId,@ShoppingCartId)";
                connection.Open();
                var result = await Task.Run(() => connection.Execute(sql, entity));
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id) //Deletes an Order
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "DELETE FROM Orders WHERE OrderId = @OrderId";
                connection.Open();
                var result = await Task.Run(() => connection.Execute(sql, new { OrderId = id }));
                return result;
            }
        }

        public async Task<List<Order>> GetAllAsync() //Get all Orders
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Orders";
                var result = await Task.Run(() => SqlMapper.Query<Order>(connection, sql).ToList());
                return result;
            }
        }

        public async Task<Order> GetByIdAsync(int id) //Get specific Order using Order Id
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Orders WHERE OrderId = @OrderId";
                connection.Open();
                var result = await Task.Run(() => connection.QuerySingleOrDefault<Order>(sql, new { OrderId = id }));
                return result;
            }
        }

        public async Task<Order> GetOrderByCustomerIdAsync(int id) //Get specific Order by Customer Id
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Orders WHERE CustomerId = @Id";
                connection.Open();
                var result = await Task.Run(() => connection.QuerySingleOrDefault<Order>(sql, new { Id = id }));
                return result;
            }
        }

        public async Task<int> UpdateAsync(Order entity) //Update and Order
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
