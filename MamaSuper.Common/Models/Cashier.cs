using System;
using System.Collections.Generic;

namespace MamaSuper.Common.Models
{
    /// <summary>
    /// Represents a cashier's in the supermarket
    /// </summary>
    public class Cashier
    {
        public Cashier(Dictionary<Customer, List<Product>> registers = null, DateTime dateOpened = default)
        {
            Registers = registers ?? new Dictionary<Customer, List<Product>>();
            DateOpened = dateOpened;
        }

        /// <summary>
        /// The cashier registers (customers and their bargains)
        /// </summary>
        public Dictionary<Customer, List<Product>> Registers { get; }

        /// <summary>
        /// The date on which the cashier opened
        /// </summary>
        public DateTime DateOpened { get; set; }

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