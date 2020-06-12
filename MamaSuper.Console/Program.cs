using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.MenuOptions.LineManagement;
using MamaSuper.MenuOptions.Menus;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Services;

namespace MamaSuper.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Line management menu for the supermarket customer line management
            ILineService<Customer> customersLineService = new CustomersLineService(new Line<Customer>());
            var lineManagementMenu = new NumericMenu("Line Management Menu",
                new List<IMenuOption>
                {
                    new CustomersLineAdder(customersLineService),
                    new CustomersLineMover(customersLineService),
                    new CustomersLinePrinter(customersLineService)
                });

            // The main menu that contains all the management menus
            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption> { lineManagementMenu });

            mainMenu.Action();
        }
    }
}