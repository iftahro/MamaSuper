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

            // Supermarket cashiers and products
            var cashiers = new List<Cashier> {new Cashier(), new Cashier(), new Cashier()};
            var products = new Dictionary<string, int>{ { "Banana", 7 }, { "Bread", 10 }, { "Water", 8 }, { "Gums", 5 }};
            var cashiersService = new CashiersService(cashiers, customersLineService, products);
            // Cashiers management menu for the supermarket cashiers
            var cashiersManagementMenu = new NumericMenu("Cashiers Management Menu",
                new List<IMenuOption>
                {
                    new RegistersOption(cashiersService),
                    new OpeningDateOption(cashiersService),
                    new IsolationOption(cashiersService)
                });

            // The main menu that contains all the management menus
            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption>
                {lineManagementMenu, cashiersManagementMenu});

            mainMenu.Action();
        }
    }
}