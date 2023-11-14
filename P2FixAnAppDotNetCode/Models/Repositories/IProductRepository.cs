using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(); //Refactored array to List syntax and added Collections.Generic

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
