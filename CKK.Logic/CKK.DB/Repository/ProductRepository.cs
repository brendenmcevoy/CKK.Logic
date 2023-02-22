using CKK.DB.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ProductRepository<Product> : IProductRepository<Product>
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }

        public async Task<int> AddAsync(Product entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "INSERT into Products (Price,Quantity,Name) VALUES (@Price,@Quantity,@Name)";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "DELETE FROM Products WHERE Id = @Id";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {Id = id });
                return result;
            }
        }
        
        public async Task<List<Product>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * From Products";
                var result = SqlMapper.Query<Product>(connection, sql);
                return result.ToList();
            }

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Products WHERE Id = @Id";
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id }); //.ConfigureAwait(false);
                return result;
            }
        }

        public async Task<List<Product>> GetByNameAsync(string name)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Products WHERE Name = @Name";
                var result = await SqlMapper.QueryAsync<Product>(connection, sql, new { Name = name });
                return result.ToList();
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "UPDATE Products SET Quantity = (Products.Quantity - ShoppingCartItems.Quantity) FROM Products JOIN ShoppingCartItems ON ProductId = ShoppingCartItems.ProductId";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
