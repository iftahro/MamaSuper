using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Models;

namespace MamaSuper.Logic.Utils
{
    public static class ProductUtils
    {
        private static readonly Random _random = new Random();

        public static List<Product> GenerateRandomProducts(Dictionary<string, int> supermarketProducts, int maxProducts = 5)
        {
            var randomProducts = new List<Product>();
            int amount = _random.Next(1, maxProducts);
            for (int i = 0; i < amount; i++)
            {
                KeyValuePair<string, int> randomProduct =
                    supermarketProducts.ElementAt(_random.Next(0, supermarketProducts.Count));
                randomProducts.Add(new Product(randomProduct.Key, randomProduct.Value));
            }

            return randomProducts;
        }

        public static string DictionaryRepresentation(List<Product> products)
        {
            var productNameGroups = products.GroupBy(product => product.Name);
            var productsDict = new Dictionary<string, int>();
            foreach (var group in productNameGroups)
            {
                productsDict[group.Key] = group.Count();
            }

            return string.Join(",", productsDict);
        }
    }
}
