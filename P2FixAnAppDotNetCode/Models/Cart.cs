using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> _cartLines = new List<CartLine>(); // This will will retain the CartLines, this is the "Cart"
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            //return new List<CartLine>(); //Here it used to return a brand new list of empty Cartline
            return _cartLines; // _cartLines it just returns _cartLines from line 11 that is storing our List of Cartline

        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {

            var productInCartLines = FindProductInCartLines(product.Id);
            if (productInCartLines != null)
            {
                foreach (var cartLine in GetCartLineList())
                {
                    if (cartLine.Product.Id == product.Id)
                    {
                        cartLine.Quantity++;
                    }
                }
            }
            else
            {
                CartLine cartItem = new CartLine();

                cartItem.Product = product;
                cartItem.Quantity = quantity;

                _cartLines.Add(cartItem);
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            double totalValueOfCart = 0;
            foreach (var cartItem in GetCartLineList())
            {
                totalValueOfCart = totalValueOfCart + cartItem.Product.Price * cartItem.Quantity;
            }
            return totalValueOfCart;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {

            double totalValueOfCart = 0;
            double average = 0;
            foreach (var cartItem in GetCartLineList())
            {
                totalValueOfCart = totalValueOfCart + cartItem.Product.Price * cartItem.Quantity;
            }
            var countItemsInCartLine = GetCartLineList().Sum(p => p.Quantity);
            average = totalValueOfCart / countItemsInCartLine;
            if (double.IsNaN(average))
            {

                return 0;

            }

            return average;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {


            foreach (var cartItem in GetCartLineList())
            {
                if (cartItem.Product.Id == productId)
                {
                    return cartItem.Product;
                }

            }
            return null;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine //contains three properties
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
