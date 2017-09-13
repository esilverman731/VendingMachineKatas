using System.Collections.Generic;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Interfaces
{
    public interface ICoinService
    {
        bool IsCoinValid(CoinModel model);
        CoinModel GetCoinValue(CoinModel model);
        List<CoinModel> GetCurrentCoinStack();
        double InsertCoin(CoinModel coin);
        void ClearCoinsInStack();

    }
}
