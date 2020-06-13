using System;
using System.Collections.Generic;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Handles the costumers line
    /// </summary>
    public interface ICustomersLineService
    {
        /// <summary>
        /// This event will be invoked when a customer move out from the line
        /// </summary>
        event EventHandler<Customer> CustomerMovedOut;
        
        /// <summary>
        /// Tries adding an customer to the line
        /// </summary>
        /// <param name="customer">The customer to be added</param>
        /// <param name="failingMessage">Failing message (if the adding action failed)</param>
        /// <returns>Is the adding action was successful</returns>
        bool TryAddCustomer(Customer customer, out string failingMessage);

        /// <summary>
        /// Moves out customers from line
        /// </summary>
        /// <param name="count">The number of customers to move out</param>
        /// <returns>The customers that where moved out</returns>
        IEnumerable<Customer> MoveOutCustomers(int count);

        /// <summary>
        /// Gets all line customers
        /// </summary>
        IEnumerable<Customer> GetLineCustomers();

        /// <summary>
        /// Counts the line customers
        /// </summary>
        int CountLineCustomers();
    }
}
