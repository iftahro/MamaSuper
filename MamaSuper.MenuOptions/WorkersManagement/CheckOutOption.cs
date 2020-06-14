using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    public class CheckOutOption : IMenuOption
    {
        private readonly IWorkersService _workersService;
        private readonly ICashiersService _cashiersService;

        public CheckOutOption(IWorkersService workersService, ICashiersService cashiersService)
        {
            _workersService = workersService;
            _cashiersService = cashiersService;
        }

        public string Description { get; } = "Check out";
        public void Action()
        {
            Worker chosenWorker = WorkerUtils.ChooseWorker(_workersService.Workers);
            Cashier workerCashier = _cashiersService.Cashiers.Find(cashier => cashier.Worker == chosenWorker);

            if (!workerCashier.IsOpen)
            {
                Console.WriteLine($"Worker {chosenWorker} not in store!\n");
                return;
            }

            _workersService.CheckOuts[chosenWorker] = DateTime.Now;
            workerCashier.IsOpen = false;
            Console.WriteLine($"\nHave a good day, {chosenWorker}!\n");
        }
    }
}
