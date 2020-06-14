using System.Collections.Generic;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Handles the supermarket cashiers operations
    /// </summary>
    public interface ICashiersService
    {
        /// <summary>
        /// The supermarket cashiers
        /// </summary>
        List<Cashier> Cashiers { get; }

        /// <summary>
        /// This method is called when a new customer enters into the supermarket
        /// </summary>
        void OnCustomerEnters(object sender, Customer customer);
    }
}