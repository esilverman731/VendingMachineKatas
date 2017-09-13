using System;
using VendingMachine.Business.Enums;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Factories
{
    public class CoinFactory
    {
        /// <summary>
        /// Generates Coins with correct weights and diameters.  Does not determine value
        /// </summary>
        /// <param name="type"></param>
        /// <returns>CoinModel with weight and diameter</returns>
        public CoinModel GetObject(CoinType type)
        {
            Random r = new Random();
            switch (type)
            {
                case CoinType.Penny:
                    return new CoinModel() { Diameter = 19.05, Weight = 2.5 };
                case CoinType.Nickel:
                    return new CoinModel() { Diameter = 21.21, Weight = 5 };
                case CoinType.Dime:
                    return new CoinModel() { Diameter = 17.91, Weight = 2.268 };
                case CoinType.Quarter:
                    return new CoinModel() { Diameter = 24.26, Weight = 5.670 };
                case CoinType.Random:
                    return new CoinModel() { Diameter = r.NextDouble(), Weight = r.NextDouble() };
            }
            return null;
        }
    }
}
