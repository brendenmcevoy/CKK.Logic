using CKK.DB.Interfaces;
using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        public Order Order { get; set; }
        public IUnitOfWork UOW { get; set; }

        public ShopModel(IUnitOfWork uow) 
        {
            UOW = uow;
            Order = new Order();
            Order.OrderId = 1;
            Order.CustomerId= 1;    
            Order.OrderNumber = "1";
            Order.ShoppingCartid = 100;
            uow.Orders.Add(Order);
        }
    }
}
