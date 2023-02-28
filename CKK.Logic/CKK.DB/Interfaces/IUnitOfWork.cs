using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository<Product> Products { get; }
        IOrderRepository<Order> Orders { get; }
        IShoppingCartRepository ShoppingCarts { get; }
    }
}
