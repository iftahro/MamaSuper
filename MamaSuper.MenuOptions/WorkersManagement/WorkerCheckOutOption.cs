using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    /// <summary>
    /// Worker check-out at the end of working day
    /// </summary>
    public class WorkerCheckOutOption : IMenuOption
    {
        private readonly IWorkersService _workersService;

        public WorkerCheckOutOption(IWorkersService workersService)
        {
            _workersService = workersService;
        }

        public string Description { get; } = "Check out";

        public void Action()
        {
            // Select a worker to check-out
            Console.WriteLine("Workers:");
            MenuUtils.PrintListAscending(_workersService.Workers);
            string userInput = ConsoleUtils.GetInputAfterOutput("Enter your number:");
            if (!MenuUtils.ValidateNumericMenuChoice(userInput, _workersService.Workers.Count, out int userChoice)
            ) return;

            Worker chosenWorker = _workersService.Workers[userChoice - 1];
            Cashier workerCashier = _workersService.GetCashierByWorker(chosenWorker);

            // Checks if worker checked in yet
            if (!workerCashier.IsOpen)
            {
                Console.WriteLine($"\nWorker '{chosenWorker}' hasn't checked in yet!\n");
                return;
            }

            _workersService.CheckOuts[chosenWorker] = DateTime.Now;
            workerCashier.IsOpen = false;
            Console.WriteLine($"\nHave a good day, {chosenWorker}!\n");
        }
    }
}