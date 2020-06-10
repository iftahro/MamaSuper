using System.Collections.Generic;
using MamaSuper.Logic.Interfaces;
using MamaSuper.MenuOptions.LineManagement;
using MamaSuper.MenuOptions.Menus;
using MamaSuper.Common.Models;

namespace MamaSuper.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Line<Costumer> costumersLine = new Line<Costumer>();
            
            var lineManagementMenu = new NumericMenu("Line Management",
                new List<IMenuOption>
                {
                    new CostumerAdder("Add a costumer", costumersLine),
                    new CostumerMover("Move costumers into the super", costumersLine),
                    new CostumerPrinter("Print all costumers", costumersLine)
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