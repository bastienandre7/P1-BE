using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts(); //Refactored array to list and added Collections.Generic
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
