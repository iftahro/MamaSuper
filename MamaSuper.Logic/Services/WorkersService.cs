using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.Logic.Services
{
    public class WorkersService : IWorkersService
    {
        public WorkersService(List<Worker> workers)
        {
            Workers = workers;
            Workers.ForEach(worker =>
            {
                CheckIns[worker] = null;
                CheckOuts[worker] = null;
            });
        }

        public List<Worker> Workers { get; set; }

        public Dictionary<Worker, DateTime?> CheckIns { get; set; } = new Dictionary<Worker, DateTime?>();

        public Dictionary<Worker, DateTime?> CheckOuts { get; set; } = new Dictionary<Worker, DateTime?>();
    }
}
