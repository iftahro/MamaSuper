using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Models;

namespace MamaSuper.Logic.Utils
{
    public static class ProductUtils
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates random products, based on a product properties dict
        /// </summary>
        /// <param name="supermarketProducts">The product properties dict</param>
        /// <param name="maxProducts">The max products to generate</param>
        /// <returns>The random products</returns>
        public static List<Product> GenerateRandomProducts(Dictionary<string, int> supermarketProducts, int maxProducts = 5)
        {
            var randomProducts = new List<Product>();
            // The amount of products to generate
            int productsAmount = _random.Next(1, maxProducts);
            for (int i = 0; i < productsAmount; i++)
            {
                // Selects random product properties from the supermarketProducts dict
                (string name, int price) = supermarketProducts.ElementAt(_random.Next(0, supermarketProducts.Count));
                randomProducts.Add(new Product(name, price));
            }

            return randomProducts;
        }

        /// <summary>
        /// Groups a products list by their names
        /// </summary>
        /// <param name="products">The <see cref="Product"/> list</param>
        /// <returns>Dictionary of product names and appearances</returns>
        public static Dictionary<string, int> GroupProductsByName(List<Product> products)
        {
            var productNameGroups = products.GroupBy(product => product.Name);
            var productsDict = new Dictionary<string, int>();
            foreach (IGrouping<string, Product> group in productNameGroups)
            {
                productsDict[group.Key] = group.Count();
            }

            return productsDict;
        }
    }
}
