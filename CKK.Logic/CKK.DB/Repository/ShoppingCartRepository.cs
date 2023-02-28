using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory Conn) //Connect to database
        {
            _connectionFactory = Conn;
        }

        public async Task<int> AddAsync(ShoppingCartItem entity) //Add a Shopping Cart
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "INSERT into ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public ShoppingCartItem AddToCart(int ShoppingCartId, int ProductId, int quantity) //Adds a Product to a Shopping Cart
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "INSERT into ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";
                connection.Open();

                var result = connection.QueryFirstOrDefault<ShoppingCartItem>(sql, new
                {
                    Quantity = quantity,
                    ShoppingCartId = ShoppingCartId,
                    ProductId = ProductId
                });
                return result;
            }
        }

        public int ClearCart(int shoppingCartId) //Clears ShoppingCartItems quantity of a specific Shopping Cart
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "UPDATE ShoppingCartItems SET Quantity = 0 WHERE ShoppingCartId = @shoppingCartId";
                connection.Open();
                var result = connection.Execute(sql, new { ShoppingCartId = shoppingCartId });
                return result;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId) //Get all products from a specific Shopping Cart
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
                var result = SqlMapper.Query<ShoppingCartItem>(connection, sql, new { ShoppingCartId = shoppingCartId }).ToList();
                return result;
            }
        }

        public decimal GetTotal(int shoppingCartId) //Get the total price of a Shopping Cart
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT sum (Price * ShoppingCartItems.Quantity) FROM Products JOIN ShoppingCartItems On ProductId = Products.Id WHERE ShoppingCartId = @shoppingCartId";
                connection.Open();
                var result = connection.QuerySingleOrDefault<decimal>(sql, new { ShoppingCartId = shoppingCartId });
                return result;
            }
        }

        public void Ordered(int shoppingCartId) //Delete Shopping Cart data after an order is placed
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
                connection.Open();
                connection.Execute(sql, new { ShoppingCartId = shoppingCartId });
            }
        }

        public async Task<int> UpdateAsync(ShoppingCartItem entity) //Update the quantity of Products based on the Products in a specific Shopping Cart
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "UPDATE Products SET Quantity = (Products.Quantity - @Quantity) WHERE Id = @ProductId";
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
