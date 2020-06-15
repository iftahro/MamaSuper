using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    /// <summary>
    /// Worker check out logic
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
            // Chooses a worker to check-out
            Worker chosenWorker = _workersService.ChooseWorker();
            if (chosenWorker == null) return;

            Cashier workerCashier = _workersService.GetCashierByWorker(chosenWorker);

            if (!workerCashier.IsOpen)
            {
                Console.WriteLine($"Worker {chosenWorker} is not in the store!\n");
                return;
            }

            _workersService.CheckOuts[chosenWorker] = DateTime.Now;
            workerCashier.IsOpen = false;
            Console.WriteLine($"\nHave a good day, {chosenWorker}!\n");
        }
    }
}
