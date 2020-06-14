using System.Collections.Generic;
using System.Linq;
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
            ILineService lineService = new LineService(new SupermarketLine<Customer>());
            var lineManagementMenu = new NumericMenu("Line Management Menu",
                new List<IMenuOption>
                {
                    new LineAdderOption(lineService),
                    new LineMoverOption(lineService),
                    new LineCustomersOption(lineService)
                });

            // Supermarket cashiers and products
            var workers = new List<Worker> {new Worker("Avi"), new Worker("Eti"), new Worker("Mosh")};
            List<Cashier> cashiers = workers.Select(worker => new Cashier(worker)).ToList();
            var products = new Dictionary<string, int> {{"Banana", 7}, {"Bread", 10}, {"Water", 8}, {"Gums", 5}};
            var cashiersService = new CashiersService(cashiers, lineService, products);
            // Cashiers management menu for the supermarket cashiers
            var cashiersManagementMenu = new NumericMenu("Cashiers Management Menu",
                new List<IMenuOption>
                {
                    new CashiersRegistersOption(cashiersService),
                    new CashiersOpeningDateOption(cashiersService),
                    new CashierIsolationOption(cashiersService)
                });

            // The main menu that contains all the management menus
            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption>
                {lineManagementMenu, cashiersManagementMenu});

            mainMenu.Action();
        }
    }
}