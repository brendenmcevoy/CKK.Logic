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
        public ProductRepository(IConnectionFactory Conn) //Connect to database
        {
            _connectionFactory = Conn;
        }

        public async Task<int> AddAsync(Product entity) //Add a Product
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "INSERT into Products (Price,Quantity,Name) VALUES (@Price,@Quantity,@Name)";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id) //Delete a Product
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "DELETE FROM Products WHERE Id = @Id";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {Id = id });
                return result;
            }
        }
        
        public async Task<List<Product>> GetAllAsync() //Get all Products
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * From Products";
                var result = await SqlMapper.QueryAsync<Product>(connection, sql);
                return result.ToList();
            }

        }

        public async Task<Product> GetByIdAsync(int id) //Get specific Product using Product Id
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Products WHERE Id = @Id";
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id }); //.ConfigureAwait(false);
                return result;
            }
        }

        public async Task<List<Product>> GetByNameAsync(string name) //Get Products using a name (specific product name or keyword)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Products WHERE Name LIKE @Name"; 
                var result = await SqlMapper.QueryAsync<Product>(connection, sql, new { Name = "%" + name + "%" });
                return result.ToList();
            }
        }

        public async Task<int> UpdateAsync(Product entity) //Update Product
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "UPDATE Products SET Quantity =(@Quantity), Name = (@Name), Price= (@Price) WHERE Id = @Id";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
