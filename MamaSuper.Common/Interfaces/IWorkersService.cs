using System;
using System.Collections.Generic;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Handles the workers operations and registers
    /// </summary>
    public interface IWorkersService
    {
        /// <summary>
        /// Every worker start of the working day
        /// </summary>
        Dictionary<Worker, DateTime?> CheckIns { get; set; }

        /// <summary>
        /// Every worker end of the working day
        /// </summary>
        Dictionary<Worker, DateTime?> CheckOuts { get; set; }

        /// <summary>
        /// Chooses a worker from all supermarket workers
        /// </summary>
        /// <returns></returns>
        Worker ChooseWorker();

        /// <summary>
        /// Gets a cashier by its worker
        /// </summary>
        Cashier GetCashierByWorker(Worker worker);
    }
}
