using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    /// <summary>
    /// Prints all workers registers
    /// </summary>
    public class WorkersRegistersOption : IMenuOption
    {
        private readonly IWorkersService _workersService;

        public WorkersRegistersOption(IWorkersService workersService)
        {
            _workersService = workersService;
        }

        public string Description { get; } = "Get all workers registers";

        public void Action()
        {
            Console.WriteLine("Check-Ins:");
            printRegisters(_workersService.CheckIns);

            Console.WriteLine("Check-Outs:");
            printRegisters(_workersService.CheckOuts);
        }

        private void printRegisters(Dictionary<Worker, DateTime?> registers)
        {
            foreach ((Worker worker, DateTime? date) in registers)
            {
                string normalizedDate = date != null ? date.ToString() : "None";
                Console.WriteLine($"{worker}: {normalizedDate}");
            }

            Console.WriteLine();
        }
    }
}