using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.Logic.Services
{
    public class CashiersService : ICashiersService
    {
        public CashiersService(ICustomersLineService customersLineService)
        {
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

        private void onCustomerEnters(object sender, Customer customer)
        {
            for (int i = 0; i < Cashiers.Count; i++)
            {
                if (i == Cashiers.Count - 1) break;
                if (Cashiers[i].PassedCustomers.Count > Cashiers[i + 1].PassedCustomers.Count)
                {
                    registerOnCashier(customer, Cashiers[i + 1]);
                    return;
                }
            }

            registerOnCashier(customer, Cashiers[0]);
        }

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
