using System;
using System.Collections.Generic;

namespace MamaSuper.Common.Models
{
    /// <summary>
    /// Represents a cashier's in the MamaSuper
    /// </summary>
    public class Cashier
    {
        /// <summary>
        /// Customers who passed in the cashier
        /// </summary>
        public Dictionary<Customer, List<Product>> Registers { get; set; }

        /// <summary>
        /// The date on which the cashier opened
        /// </summary>
        public DateTime DateOpened { get; set; }

        public Cashier(Dictionary<Customer, List<Product>> registers = null, DateTime dateOpened = default)
        {
            Registers = registers ?? new Dictionary<Customer, List<Product>>();
            DateOpened = dateOpened;
        }

        public bool IsOpen()
        {
            return Registers.Count > 0;
        }

        public override string ToString()
        {
            return string.Join(",", Registers.Keys);
        }
    }
}
