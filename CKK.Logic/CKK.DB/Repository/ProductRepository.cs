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

        public int Add(Product entity)
        {
            var sql = "INSERT into Products (Price,Quantity,Name) VALUES (@Price,@Quantity,@Name)";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, new {Id = id });
                return result;
            }
        }

        public List<Product> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * From Products";
                var result = SqlMapper.Query<Product>(connection,sql).ToList();
                return result;
            }

        }

        public Product GetById(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Product>(sql, new { Id = id });
                return result;
            }
        }

        public List<Product> GetByName(string name)
        {
            

            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM Products WHERE Name = @Name";
                var result = SqlMapper.Query<Product>(connection,sql, new { Name = name}).ToList();
                return result;
            }
        }

        public int Update(Product entity)
        {
            var sql = "UPDATE Products SET Quantity = (Products.Quantity - ShoppingCartItems.Quantity) FROM Products JOIN ShoppingCartItems ON ProductId = ShoppingCartItems.ProductId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
