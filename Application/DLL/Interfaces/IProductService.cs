using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        public Task<bool> AddProduct(Product product, List<Characteristic> characteristic);

        public Task<List<Product>> GetAllProducts();
    }
}
