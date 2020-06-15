using System;
using System.Collections.Generic;

namespace MamaSuper.Common.Models
{
    /// <summary>
    /// Represents a cashier's in the supermarket
    /// </summary>
    public class Cashier
    {
        public Cashier(Worker worker, Dictionary<Customer, List<Product>> registers = null, DateTime? dateOpened = null)
        {
            Registers = registers ?? new Dictionary<Customer, List<Product>>();
            Worker = worker;
            DateOpened = dateOpened;
        }

        /// <summary>
        /// The cashier registers (customers and their bargains)
        /// </summary>
        public Dictionary<Customer, List<Product>> Registers { get; }

        /// <summary>
        /// The date on which the cashier opened
        /// </summary>
        public DateTime? DateOpened { get; set; }

        /// <summary>
        /// The cashier's worker
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// Is the cashier open
        /// </summary>
        public bool IsOpen { get; set; } = false;

        public override string ToString()
        {
            return string.Join(",", Registers.Keys);
        }
    }
}