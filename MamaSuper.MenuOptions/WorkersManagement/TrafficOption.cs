using System;
using System.Collections.Generic;
using System.Text;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.WorkersManagement
{
    public class TrafficOption : IMenuOption
    {
        private readonly IWorkersService _workersService;

        public TrafficOption(IWorkersService workersService)
        {
            _workersService = workersService;
        }

        public string Description { get; } = "See workers traffic";
        public void Action()
        {
            Console.WriteLine("Check-Ins");
            WorkerUtils.PrintTraffic(_workersService.CheckIns);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Check-Outs");
            WorkerUtils.PrintTraffic(_workersService.CheckOuts);
            Console.WriteLine(Environment.NewLine);
        }
    }
}
