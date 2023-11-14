using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts() //Here, the brackets [] were removed and everything was refactored with the List syntax, including the Collections.Generic
        { //This happened in several other places where "Go to Definition" and "Go to Implementation" hotkeys turned specially useful.



            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            foreach (Product product in GetAllProducts())
            {
                if (product.Id == id)
                {
                    return product;
                }

            };

            return null;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            foreach (var productDecrementor in cart.Lines)
            {

                _productRepository.UpdateProductStocks(productDecrementor.Product.Id, productDecrementor.Quantity);

            }
        }
    }
}
