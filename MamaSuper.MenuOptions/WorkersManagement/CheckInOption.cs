using System;
using System.Collections.Generic;
using System.Text;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    public class CheckInOption : IMenuOption
    {
        private readonly IWorkersService _workersService;
        private readonly ICashiersService _cashiersService;

        public CheckInOption(IWorkersService workersService, ICashiersService cashiersService)
        {
            _workersService = workersService;
            _cashiersService = cashiersService;
        }

        public string Description { get; } = "Check in";
        public void Action()
        {
            Worker chosenWorker = WorkerUtils.ChooseWorker(_workersService.Workers);
            Cashier workerCashier = _cashiersService.Cashiers.Find(cashier => cashier.Worker == chosenWorker);

            if (workerCashier.IsOpen)
            {
                Console.WriteLine($"Worker {chosenWorker} already in store!\n");
                return;
            }

            _workersService.CheckIns[chosenWorker] = DateTime.Now;
            workerCashier.IsOpen = true;
            Console.WriteLine($"\nWelcome back, {chosenWorker}!\n");
        }
    }
}
