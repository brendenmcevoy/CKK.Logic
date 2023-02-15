using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }
        //public int Add(ShoppingCartItem entity)
        //{
        //    var sql = "INSERT into ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";

        //    using (var connection = _connectionFactory.GetConnection)
        //    {
        //        connection.Open();
        //        var result = connection.Execute(sql, entity);
        //        return result;
        //    }
        //}

        public ShoppingCartItem AddToCart(int ShoppingCartId, int ProductId, int quantity)
        {
            var sql = "INSERT into ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";

            using (var connection = _connectionFactory.GetConnection)
            {
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

        public int ClearCart(int shoppingCartId)
        {
            var sql = "UPDATE ShoppingCartItems SET Quantity = 0 WHERE ShoppingCartId = @shoppingCartId";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, new {ShoppingCartId = shoppingCartId });
                return result;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
                var result = SqlMapper.Query<ShoppingCartItem>(connection,sql, new { ShoppingCartId = shoppingCartId }).ToList();
                return result;
            }
        }

        public decimal GetTotal(int shoppingCartId)
        {
            var sql = "SELECT sum (Price * ShoppingCartItems.Quantity) FROM Products JOIN ShoppingCartItems On ProductId = Products.Id WHERE ShoppingCartId = @shoppingCartId";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<decimal>(sql, new {ShoppingCartId = shoppingCartId}); 
                return result;
            }
        }

        public void Ordered(int shoppingCartId)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                connection.Execute(sql, new { ShoppingCartId = shoppingCartId });                
            }
        }

        //public int Update(ShoppingCartItem entity)
        //{
        //    var sql = "UPDATE ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";

        //    using (var connection = _connectionFactory.GetConnection)
        //    {
        //        connection.Open();
        //        var result = connection.Execute(sql, entity);
        //        return result;
        //    }
        //}
    }
}
