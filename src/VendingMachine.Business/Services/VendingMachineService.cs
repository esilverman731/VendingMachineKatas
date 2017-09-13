using System.Collections.Generic;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Services
{
    public class VendingMachineService:IVendingMachineService
    {
        private string _currentStatus { get; set; }
        private double _currentAmount { get; set; }
        private ICoinService _coinService { get; set; }
        private List<CoinModel> _coinReturn { get; set; }
        public VendingMachineService()
        {
            _currentStatus = "INSERT COINS";
            _currentAmount = 0;
            _coinService = new CoinService();
            _coinReturn = new List<CoinModel>();
        }
        public string GetStatusMessage()
        {
            return _currentStatus;
        }
        public double GetCurrentAmount()
        {
            return _currentAmount;
        }
        public double InsertCoin(CoinModel coin)
        {
            var coinWithValue = _coinService.GetCoinValue(coin);
            var isValid = _coinService.IsCoinValid(coinWithValue);
            if (isValid)
            {
                _currentAmount = _coinService.InsertCoin(coin);
                _currentStatus = _currentAmount.ToString("0.00")+" inserted";
                return _currentAmount;
            } else
            {
                return 0;
            }
        }
        

    }
}
