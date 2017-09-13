using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Business.Models
{
    public class CoinModel
    {
        /// <summary>
        /// Coin Properties
        /// Weight is weight in grams
        /// Diameter is in millimeters
        /// </summary>
        public double Weight { get; set; }
        public double Diameter { get; set; }
        public double Value { get; set; }
    }
}
