using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.Logic.Services
{
    public class CashiersService : ICashiersService
    {
        public CashiersService(List<Cashier> cashiers, ICustomersLineService customersLineService)
        {
            Cashiers = cashiers;
            customersLineService.CustomerMovedOut += onCustomerEnters;
        }

        public List<Cashier> Cashiers { get; set; }

        public IEnumerable<Cashier> GetAllCashiers()
        {
            foreach (Cashier cashier in Cashiers)
            {
                yield return cashier;
            }
        }

        /// <summary>
        /// This method is called when a customer enters into the supermarket
        /// </summary>
        private void onCustomerEnters(object sender, Customer customer)
        {
            Cashier emptiestCashier = getEmptiestCashier();
            registerOnCashier(customer, emptiestCashier);
        }

        /// <summary>
        /// Returns the emptiest supermarket cashier
        /// </summary>
        private Cashier getEmptiestCashier()
        {
            for (int i = 0; i < Cashiers.Count; i++)
            {
                if (i == Cashiers.Count - 1) break;
                if (Cashiers[i].PassedCustomers.Count > Cashiers[i + 1].PassedCustomers.Count)
                {
                    return Cashiers[i + 1];
                }
            }

            return Cashiers[0];
        }

        /// <summary>
        /// Customer registration in a cashier 
        /// </summary>
        /// <param name="customer">The customer who registered</param>
        /// <param name="cashier">The cashier to be registered</param>
        private void registerOnCashier(Customer customer, Cashier cashier)
        {
            if (cashier.PassedCustomers.Count == 0)
            {
                cashier.DateOpened = DateTime.Now;
            }

            cashier.PassedCustomers.Add(customer);
        }
    }
}