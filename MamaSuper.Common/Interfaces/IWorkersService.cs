using System;
using System.Collections.Generic;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Managers the supermarket workers
    /// </summary>
    public interface IWorkersService
    {
        /// <summary>
        /// All supermarket workers
        /// </summary>
        List<Worker> Workers { get; set; }

        /// <summary>
        /// Every worker start of the working day
        /// </summary>
        Dictionary<Worker, DateTime?> CheckIns { get; set; }

        /// <summary>
        /// Every worker end of the working day
        /// </summary>
        Dictionary<Worker, DateTime?> CheckOuts { get; set; }

        /// <summary>
        /// Gets a cashier by its worker
        /// </summary>
        Cashier GetCashierByWorker(Worker worker);
    }
}
