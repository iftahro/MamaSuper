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
            Line<Customer> customersLine = new Line<Customer>();
            ILineService<Customer> customersLineService = new CustomersLineService(customersLine);

            var lineManagementMenu = new NumericMenu("Line Management Menu",
                new List<IMenuOption>
                {
                    new CustomersLineAdder("Add new customer to the line", customersLineService),
                    new CustomersLineMover("Move customers into the supermarket", customersLineService),
                    new CustomersLinePrinter("Print all customers in line", customersLineService)
                });

            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption> { lineManagementMenu });

            mainMenu.Action();
        }
    }
}