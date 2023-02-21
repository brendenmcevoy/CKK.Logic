using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IProductRepository<Product>:IGenericRepository<Product>
    {
        Task<List<Product>> GetByNameAsync(string name);
    }
}
