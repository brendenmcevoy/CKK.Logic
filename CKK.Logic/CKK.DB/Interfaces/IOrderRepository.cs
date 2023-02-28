using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IOrderRepository<Order> : IGenericRepository<Order>
    {
        Task<Order> GetOrderByCustomerIdAsync(int id);
    }
}
