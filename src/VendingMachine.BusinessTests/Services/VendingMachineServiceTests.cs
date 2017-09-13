using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Business.Services;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Factories;
using VendingMachine.Business.Models;
using VendingMachine.Business.Enums;

namespace VendingMachine.BusinessTests.Services
{
    /// <summary>
    /// Tests for the VendingMachineServiceInterface
    /// </summary>
    [TestClass]
    public class VendingMachineServiceTests
    {
        private IVendingMachineService _service;
        private CoinFactory _coinFactory;
        public VendingMachineServiceTests()
        {
            _service = new VendingMachineService();
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
        public void VendingMachineServiceTest_GetStatus()
        {
            var result = _service.GetStatusMessage();
            Assert.AreNotEqual("", "VendingMachineServiceGetCurrentStatus is blank");
        }
        [TestMethod]
        public void VendingMachineServiceTest_GetAmount()
        {
            var result = _service.GetCurrentAmount();
            Assert.IsTrue(result >= 0, "VendingMachineServiceGetCurrentAmount does not return a valid value");
        }
        [TestMethod]
        public void VendingMachineServiceTest_AddCoin_ShouldReturnZero()
        {
            var coin = _coinFactory.GetObject(CoinType.Random);
            var result = _service.InsertCoin(coin);
            Assert.AreEqual(0, result, "VendingMachineService returns invalid data from random coin");
        }
        [TestMethod]
        public void VendingMachineServiceTest_AddCoin_ShouldReturnNickel()
        {
            var coin = _coinFactory.GetObject(CoinType.Nickel);
            var result = _service.InsertCoin(coin);
            Assert.AreEqual(0.05, result, "VendingMachineService returns invalid data from nickel");
        }
    }
}
