using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Interfaces
{
    public interface IVendingMachineService
    {
        string GetStatusMessage();
        double GetCurrentAmount();
        double InsertCoin(CoinModel coin);
    }
}
