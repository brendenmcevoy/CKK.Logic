﻿using CKK.DB.Interfaces;
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
        public int Add(ShoppingCartItem entity)
        {
            var sql = "INSERT into ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public ShoppingCartItem AddToCart(string itemName, int quantity)
        {
            throw new NotImplementedException();
        }

        public int ClearCart(int shoppingCartId)
        {
            var sql = "DELETE ProductId, Quantity FROM ShoppingCartItems WHERE ShoppingCartId = @shoppingCartId";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                connection.QuerySingleOrDefault<Product>(sql, new { ShoppingCartId = shoppingCartId });
                return shoppingCartId;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            var sql = "SELECT * FROM Products JOIN ShoppingCartId USING ShoppingCartId = Id WHERE ShoppingCartId = @shoppingCartId";
            List<ShoppingCartItem> items = new List<ShoppingCartItem>();
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<ShoppingCartItem>(sql, new { ShoppingCartId = shoppingCartId });
                items.Add(result);
                return items;
            }
        }

        public decimal GetTotal(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public int Update(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
