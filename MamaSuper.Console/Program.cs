using System.Collections.Generic;
using MamaSuper.Logic.Interfaces;
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
            Line<Costumer> costumersLine = new Line<Costumer>();
            ILineService<Costumer> costumersLineService = new CostumersLineService(costumersLine);

            var lineManagementMenu = new NumericMenu("Line Management Menu",
                new List<IMenuOption>
                {
                    new CostumersLineAdder("Add new costumer to the line", costumersLineService),
                    new CostumersLineMover("Move costumers into the supermarket", costumersLineService),
                    new CostumersLinePrinter("Print all costumers in line", costumersLineService)
                });

            var mainMenu = new NumericMenu("Main Menu",
                new List<IMenuOption>
                {
                    lineManagementMenu
                });

            mainMenu.Action();
        }
    }
}