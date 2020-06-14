using System;
using System.Collections.Generic;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    public interface IWorkersService
    {
        List<Worker> Workers { get; set; }

        Dictionary<Worker, DateTime?> CheckIns { get; set; }

        Dictionary<Worker, DateTime?> CheckOuts { get; set; }
    }
}
