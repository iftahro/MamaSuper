using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.MenuOptions.LineManagement;
using MamaSuper.MenuOptions.Menus;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Services;
using MamaSuper.MenuOptions.CashiersManagement;
using MamaSuper.MenuOptions.WorkersManagement;

namespace MamaSuper.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Supermarket objects

            var workers = new List<Worker> { new Worker("Avi"), new Worker("Eti"), new Worker("Mosh") };
            List<Cashier> cashiers = workers.Select(worker => new Cashier(worker)).ToList();
            var products = new Dictionary<string, int> { { "Banana", 7 }, { "Bread", 10 }, { "Water", 8 }, { "Gums", 5 } };

            #endregion

            #region Services

            var lineService = new LineService(new SupermarketLine<Customer>());
            var cashiersService = new CashiersService(cashiers, lineService, products);
            var workersService = new WorkersService(workers, cashiersService);

            #endregion

            #region Management Menus

            var lineManagementMenu = new NumericMenu("Line Management Menu",
                new List<IMenuOption>
                {
                    new LineAdderOption(lineService),
                    new LineMoverOption(lineService),
                    new LineCustomersOption(lineService)
                });

            var cashiersManagementMenu = new NumericMenu("Cashiers Management Menu",
                new List<IMenuOption>
                {
                    new CashiersRegistersOption(cashiersService),
                    new CashiersOpeningDateOption(cashiersService),
                    new CashierIsolationOption(cashiersService)
                });

            var workersManagementMenu = new NumericMenu("Workers Management Menu",
                new List<IMenuOption>
                {
                    new WorkerCheckInOption(workersService),
                    new WorkerCheckOutOption(workersService),
                    new WorkersRegistersOption(workersService)
                });

            #endregion

            // The main menu that contains all the management menus
            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption>
                {lineManagementMenu, cashiersManagementMenu, workersManagementMenu});

            try
            {
                mainMenu.Action();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"MamaSuper process has failed! Failing message:\n{e.Message}");
            }
        }
    }
}