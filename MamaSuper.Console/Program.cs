using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.MenuOptions.LineManagement;
using MamaSuper.MenuOptions.Menus;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Services;
using MamaSuper.MenuOptions.CashiersManagement;

namespace MamaSuper.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Line management menu for the supermarket customers line
            ICustomersLineService customersLineService = new CustomersLineService(new Line<Customer>());
            var lineManagementMenu = new NumericMenu("Line Management Menu",
                new List<IMenuOption>
                {
                    new CustomerAdderOption(customersLineService),
                    new CustomersMoverOption(customersLineService),
                    new LineDetailsOption(customersLineService)
                });

            // Cashiers management menu for the supermarket cashiers
            var cashiersService = new CashiersService(new List<Cashier>
                {new Cashier(), new Cashier(), new Cashier()}, customersLineService);
            var passedCustomersOption = new PassedCustomersOption(cashiersService);
            var cashiersManagementMenu = new NumericMenu("Cashiers Management Menu",
                new List<IMenuOption>
                {
                    passedCustomersOption,
                    new OpeningDateOption(cashiersService),
                    new CashierIsolationOption(cashiersService, passedCustomersOption)
                });

            // The main menu that contains all the management menus
            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption>
                {lineManagementMenu, cashiersManagementMenu});

            mainMenu.Action();
        }
    }
}