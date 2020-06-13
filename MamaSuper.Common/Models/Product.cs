using System;
using System.Collections.Generic;
using System.Text;

namespace MamaSuper.Common.Models
{
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
