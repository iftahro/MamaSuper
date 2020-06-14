namespace MamaSuper.Common.Models
{
    /// <summary>
    /// A supermarket product
    /// </summary>
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// The product's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The product's price
        /// </summary>
        public int Price { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}