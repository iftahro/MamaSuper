using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="IWorkersService"/>
    /// </summary>
    public class WorkersService : IWorkersService
    {
        private readonly ICashiersService _cashiersService;
        private readonly List<Worker> _workers;

        public WorkersService(List<Worker> workers, ICashiersService cashiersService)
        {
            _workers = workers;
            _cashiersService = cashiersService;

            // Initiates the check-ins/outs of every worker
            _workers.ForEach(worker =>
            {
                CheckIns[worker] = null;
                CheckOuts[worker] = null;
            });
        }

        /// <summary>
        /// <inheritdoc cref="IWorkersService.CheckIns"/>
        /// </summary>
        public Dictionary<Worker, DateTime?> CheckIns { get; set; } = new Dictionary<Worker, DateTime?>();

        /// <summary>
        /// <inheritdoc cref="IWorkersService.CheckOuts"/>
        /// </summary>
        public Dictionary<Worker, DateTime?> CheckOuts { get; set; } = new Dictionary<Worker, DateTime?>();

        /// <summary>
        /// <inheritdoc cref="IWorkersService.ChooseWorker"/>
        /// </summary>
        public Worker ChooseWorker()
        {
            Console.WriteLine("Workers:");
            for (int i = 0; i < _workers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_workers[i]}");
            }

            string userInput = ConsoleUtils.GetInputAfterOutput("Enter your number:");
            if (!MenuUtils.ValidateNumericMenuChoice(userInput, _workers.Count, out int userChoice)) return null;

            return _workers[userChoice - 1];
        }

        /// <summary>
        /// <inheritdoc cref="IWorkersService.GetCashierByWorker"/>
        /// </summary>
        public Cashier GetCashierByWorker(Worker worker)
        {
            return _cashiersService.Cashiers.Find(cashier => cashier.Worker == worker);
        }

    }
}
