using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Services
{
    public class CoinService:ICoinService
    {
        private List<CoinModel> _coinsInStack { get; set; }
        private double _currentCoinStackValue { get; set; }
        public CoinService()
        {
            _coinsInStack = new List<CoinModel>();
            _currentCoinStackValue = 0;
        }
        /// <summary>
        /// gets if coin is valid, based on value
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsCoinValid(CoinModel model)
        {
            if (model.Value == .05 || model.Value == .10 || model.Value == .25)
                return true;
            else return false;
        }
        public CoinModel GetCoinValue(CoinModel model)
        {
            if (model.Diameter==null || model.Weight==null)
            {
                model.Value = 0;
            }
            else
            {
                var weightValue = getCoinValueByWeight(model.Weight);
                var diameterValue = getCoinValueByDiameter(model.Diameter);
                if (weightValue == diameterValue)
                    model.Value = weightValue;
            }
            return model;
        }
        /// <summary>
        /// gets coins currently in coinstack
        /// </summary>
        /// <returns></returns>
        public List<CoinModel> GetCurrentCoinStack()
        {
            return _coinsInStack;
        }
        /// <summary>
        /// adds coin to coinstack
        /// </summary>
        /// <param name="coin"></param>
        /// <returns>value of current coin stack</returns>
        public double InsertCoin(CoinModel coin)
        {
            //double check coin value
            coin = GetCoinValue(coin);
            if (coin.Value != 0)
            {
                _coinsInStack.Add(coin);
                _currentCoinStackValue += coin.Value;
            }
            return _currentCoinStackValue;
        }
        /// <summary>
        /// clears coins in service
        /// </summary>
        public void ClearCoinsInStack()
        {
            _coinsInStack.Clear();
            _currentCoinStackValue = 0;
        }
        private double getCoinValueByWeight(double weight)
        {
            if (weight > 2.49 && weight < 2.51)
                return .01;
            else if (weight > 4.9 && weight < 5.1)
                return .05;
            else if (weight > 2.2 && weight < 2.3)
                return .10;
            else if (weight > 5.6 && weight < 5.7)
                return .25;
            else
                return 0;
        }
        private double getCoinValueByDiameter(double diameter)
        {
            if (diameter == 19.05)
                return .01;
            else if (diameter == 21.21)
                return .05;
            else if (diameter == 17.91)
                return .10;
            else if (diameter == 24.26)
                return .25;
            else
                return 0;
        }
    }
}
