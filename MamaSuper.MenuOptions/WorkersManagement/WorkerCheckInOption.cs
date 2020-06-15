using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    /// <summary>
    /// Worker check-in logic
    /// </summary>
    public class WorkerCheckInOption : IMenuOption
    {
        private readonly IWorkersService _workersService;

        public WorkerCheckInOption(IWorkersService workersService)
        {
            _workersService = workersService;
        }

        public string Description { get; } = "Check in";

        public void Action()
        {
            // Chooses a worker to check-in
            Worker chosenWorker = _workersService.ChooseWorker();
            if (chosenWorker == null) return;

            Cashier workerCashier = _workersService.GetCashierByWorker(chosenWorker);
            if (workerCashier.IsOpen)
            {
                Console.WriteLine($"Worker {chosenWorker} is already in the store!\n");
                return;
            }

            // Gathering information about the entering worker
            string bodyTempInput = ConsoleUtils.GetInputAfterOutput("Enter your body temp (c° degree):");
            if (!bodyTempInput.TryParseToInt(out int bodyTemperature)) return;

            string hasMaskInput = ConsoleUtils.GetInputAfterOutput("Do you wear mask? (true/false)");
            if (!hasMaskInput.TryParseToBool(out bool maskOn)) return;

            string shouldIsolateInput =
                ConsoleUtils.GetInputAfterOutput("Do you should be isolated? (true/false)");
            if (!shouldIsolateInput.TryParseToBool(out bool shouldIsolate)) return;

            if (!validateWorkerPermission(chosenWorker, bodyTemperature, maskOn, shouldIsolate, out string prohibitionReason))
            {
                Console.WriteLine(
                    $"\nYou are ejected and getting fined by 40$!. Ejecting reason:\n{prohibitionReason}\n");
                chosenWorker.Fine += 40;
                return;
            }

            openCashier(workerCashier);
            _workersService.CheckIns[chosenWorker] = DateTime.Now;
            Console.WriteLine($"\nWelcome back, {chosenWorker}!");
            if (chosenWorker.Fine > 0)
            {
                Console.WriteLine($"Today you'll work extra {chosenWorker.Fine / 30} hours!\n");
            }
        }

        /// <summary>
        /// Validates is the worker permitted to check-in
        /// </summary>
        private bool validateWorkerPermission(Worker worker, int bodyTemperature, bool maskOn, bool shouldIsolate,
            out string prohibitionReason)
        {
            worker.BodyTemperature = bodyTemperature;
            worker.HasMask = maskOn;
            worker.ShouldIsolate = shouldIsolate;
            return worker.IsPermittedToEnter(out prohibitionReason);
        }

        /// <summary>
        /// Opens a cashier in the supermarket
        /// </summary>
        private static void openCashier(Cashier cashier)
        {
            cashier.IsOpen = true;
            cashier.DateOpened = DateTime.Now;
        }
    }
}
