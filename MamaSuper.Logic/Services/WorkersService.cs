using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="IWorkersService"/>
    /// </summary>
    public class WorkersService : IWorkersService
    {
        private readonly ICashiersService _cashiersService;

        public WorkersService(List<Worker> workers, ICashiersService cashiersService)
        {
            Workers = workers;
            _cashiersService = cashiersService;

            // Initiates the check-ins/outs of every worker
            Workers.ForEach(worker =>
            {
                CheckIns[worker] = null;
                CheckOuts[worker] = null;
            });
        }

        /// <summary>
        /// <inheritdoc cref="IWorkersService.Workers"/>
        /// </summary>
        public List<Worker> Workers { get; set; }

        /// <summary>
        /// <inheritdoc cref="IWorkersService.CheckIns"/>
        /// </summary>
        public Dictionary<Worker, DateTime?> CheckIns { get; set; } = new Dictionary<Worker, DateTime?>();

        /// <summary>
        /// <inheritdoc cref="IWorkersService.CheckOuts"/>
        /// </summary>
        public Dictionary<Worker, DateTime?> CheckOuts { get; set; } = new Dictionary<Worker, DateTime?>();

        /// <summary>
        /// <inheritdoc cref="IWorkersService.GetCashierByWorker"/>
        /// </summary>
        public Cashier GetCashierByWorker(Worker worker)
        {
            return _cashiersService.Cashiers.Find(cashier => cashier.Worker == worker);
        }

    }
}
