﻿using CKK.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCartItem AddToCart(int ShoppingCartId, int ProductId, int quantity);
        int ClearCart(int shoppingCartId);
        decimal GetTotal(int shoppingCartId);
        List<ShoppingCartItem> GetProducts(int shoppingCartId);
        void Ordered(int shoppingCartId);
        Task<int> UpdateAsync(ShoppingCartItem entity);
        Task<int> AddAsync(ShoppingCartItem entity);
    }
}
