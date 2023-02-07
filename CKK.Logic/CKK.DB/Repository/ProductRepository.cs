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
            List<Product> products = new List<Product>();

            var sql = "SELECT * From Products";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query<Product>(sql);
                foreach(var r in result)
                {
                    products.Add(r);
                }
                return products;
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
            List<Product> products = new List<Product>();

            var sql = "SELECT * FROM Products WHERE Name = @Name";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Product>(sql, new { Name = name});
                products.Add(result);
                return products;
            }
        }

        public int Update(Product entity)
        {
            var sql = "UPDATE Products (Price,Quantity,Name) VALUES (@Price,@Quantity,@Name)";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
