using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Services;
using VendingMachine.Business.Factories;
using VendingMachine.Business.Enums;
using VendingMachine.Business.Models;

namespace VendingMachine.BusinessTests.Services
{
    /// <summary>
    /// Tests for CoinService
    /// </summary>
    [TestClass]
    public class CoinServiceTests
    {
        ICoinService _coinService;
        CoinFactory _coinFactory;
        public CoinServiceTests()
        {
            _coinService = new CoinService();
            _coinFactory = new CoinFactory();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CoinServiceTest_GetValue()
        {
            CoinModel coin;

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Penny));
            Assert.AreEqual(.01, coin.Value, "CoinService getCoinValue returns invalid value for penny");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Nickel));
            Assert.AreEqual(.05, coin.Value, "CoinService getCoinValue returns invalid value for nickel");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Dime));
            Assert.AreEqual(.10, coin.Value, "CoinService getCoinValue returns invalid value for dime");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Quarter));
            Assert.AreEqual(.25, coin.Value, "CoinService getCoinValue returns invalid value for quarter");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Random));
            Assert.AreEqual(.00, coin.Value, "CoinService getCoinValue returns invalid value for random");

        }

        //Tests Validity of CoinService for vending machine
        [TestMethod]
        public void CoinServiceTest_IsCoinValid()
        {
            CoinModel coin;

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Penny));
            Assert.IsFalse(_coinService.IsCoinValid(coin), "CoinService Returns invalid validity result for penny");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Nickel));
            Assert.IsTrue(_coinService.IsCoinValid(coin), "CoinService Returns invalid validity result for nickels");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Dime));
            Assert.IsTrue(_coinService.IsCoinValid(coin), "CoinService Returns invalid result for dimes");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Quarter));
            Assert.IsTrue(_coinService.IsCoinValid(coin), "CoinService Returns invalid result for quarters");

            coin = _coinService.GetCoinValue(_coinFactory.GetObject(CoinType.Random));
            Assert.IsFalse(_coinService.IsCoinValid(coin), "CoinService Returns invalid result for random");

        }
        [TestMethod]
        public void CoinServiceTest_InsertCoin()
        {
            if (_coinService.GetCurrentCoinStack().Count > 0)
                _coinService.ClearCoinsInStack();
            CoinModel coin;

            coin = _coinFactory.GetObject(CoinType.Nickel);
            Assert.AreEqual(_coinService.InsertCoin(coin), .05);

            coin = _coinFactory.GetObject(CoinType.Random);
            Assert.AreEqual(_coinService.InsertCoin(coin), .05);
            
        }

    }
}
