using CKK.DB.Interfaces;
using CKK.DB.Repository;
using CKK.Logic.Models;

namespace CKK.DB.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConnectionFactory Conn)
        {
            Products = new ProductRepository<Product>(Conn);
            Orders = new OrderRepository<Order>(Conn);
            ShoppingCarts = new ShoppingCartRepository(Conn);
        }

        public IProductRepository<Product> Products { get; private set; }
        public IOrderRepository<Order> Orders { get; private set; }
        public IShoppingCartRepository ShoppingCarts { get; private set; }
    }
}
