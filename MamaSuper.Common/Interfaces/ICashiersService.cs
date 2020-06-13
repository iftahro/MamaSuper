using System;
using System.Collections.Generic;
using System.Text;
using MamaSuper.Common.Models;

namespace MamaSuper.Common.Interfaces
{
    public interface ICashiersService
    {
        List<Cashier> Cashiers { get; }

        IEnumerable<Cashier> GetAllCashiers();
    }
}