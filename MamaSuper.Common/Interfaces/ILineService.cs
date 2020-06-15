using System;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Managers the costumers line
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
        SupermarketLine<Customer> CustomersLine { get; }

        /// <summary>
        /// Moves out customers from line
        /// </summary>
        /// <param name="count">The number of customers to move out</param>
        void MoveOutCustomers(int count);
    }
}