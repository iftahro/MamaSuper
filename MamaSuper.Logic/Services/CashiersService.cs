using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="ICashiersService"/>
    /// </summary>
    public class CashiersService : ICashiersService
    {
        private readonly Dictionary<string, int> _supermarketProducts;

        public CashiersService(List<Cashier> cashiers, ILineService lineService, 
            Dictionary<string, int> supermarketProducts)
        {
            Cashiers = cashiers;
            _supermarketProducts = supermarketProducts;
            lineService.CustomerMovedOut += OnCustomerEnters;
        }

        /// <summary>
        /// <inheritdoc cref="ICashiersService.Cashiers"/>
        /// </summary>
        public List<Cashier> Cashiers { get; }

        /// <summary>
        /// <inheritdoc cref="ICashiersService.OnCustomerEnters"/>
        /// </summary>
        public void OnCustomerEnters(object sender, Customer customer)
        {
            Cashier emptiestCashier = getEmptiestCashier();
            List<Product> randomProducts = ProductUtils.GenerateRandomProducts(_supermarketProducts);
            registerCustomer(customer, emptiestCashier, randomProducts);
        }

        /// <summary>
        /// Returns the emptiest supermarket cashier
        /// </summary>
        private Cashier getEmptiestCashier()
        {
            for (int i = 0; i < Cashiers.Count; i++)
            {
                if (i == Cashiers.Count - 1) break;
                if (Cashiers[i].Registers.Count > Cashiers[i + 1].Registers.Count)
                {
                    return Cashiers[i + 1];
                }
            }

            return Cashiers[0];
        }

        /// <summary>
        /// Registers customer in a cashier 
        /// </summary>
        /// <param name="customer">The customer who registers</param>
        /// <param name="cashier">The cashier to be registered in</param>
        /// <param name="products">The costumer's products to buy</param>
        private void registerCustomer(Customer customer, Cashier cashier, List<Product> products)
        {
            if (!cashier.IsOpen()) cashier.DateOpened = DateTime.Now;
            cashier.Registers[customer] = products;
        }
    }
}