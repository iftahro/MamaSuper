using System;
using System.Collections.Generic;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Handles the costumers line operations
    /// </summary>
    public interface ILineService
    {
        /// <summary>
        /// This event will be invoked when a customer move out from the line
        /// </summary>
        event EventHandler<Customer> CustomerMovedOut;

        /// <summary>
        /// The supermarket customers line
        /// </summary>
        Line<Customer> CustomersLine { get; }

        /// <summary>
        /// Moves out customers from line
        /// </summary>
        /// <param name="count">The number of customers to move out</param>
        /// <returns>The customers that where moved out</returns>
        IEnumerable<Customer> MoveOutCustomers(int count);
    }
}