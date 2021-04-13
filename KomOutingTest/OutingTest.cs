using KomOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomOutingTest
{
    [TestClass]
    public class OutingTest
    {
        private readonly OutingsRepo _repo = new OutingsRepo();
        [TestMethod]
        public void AddOutingTest()
        {
            //Arrange
            Outing newOuting = new Outing(EventType.Bowling, 5, new DateTime(2021, 4, 10), 50.00);

            //ACT
            bool wasAdded = _repo.AddOuting(newOuting);

            //ASSERT
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetAllOutingsTest()
        {
            //ARRANGE
            SeedContentList();

            //ACT
            List<Outing> allOutings = _repo.GetAllOutings();

            //ASSERT
            Assert.AreEqual(5, allOutings.Count);
        }
        private void SeedContentList()
        {
            Outing Outing1 = new Outing(EventType.Bowling, 5, new DateTime(2021, 4, 10), 50.00);
            Outing Outing2 = new Outing(EventType.Concert, 50, new DateTime(2021, 4, 09), 1000.00);
            Outing Outing3 = new Outing(EventType.AmusementPark, 40, new DateTime(2021, 4, 08), 2000.00);
            Outing Outing4 = new Outing(EventType.Golf, 10, new DateTime(2021, 4, 07), 400.00);
            Outing Outing5 = new Outing(EventType.AmusementPark, 30, new DateTime(2021, 4, 06), 1650.00);
            _repo.AddOuting(Outing1);
            _repo.AddOuting(Outing2);
            _repo.AddOuting(Outing3);
            _repo.AddOuting(Outing4);
            _repo.AddOuting(Outing5);
        }
        [TestMethod]
        public void GetOutingByTypeTest()
        {
            //ARRANGE
            SeedContentList();

            //ACT
            List<Outing> outing = _repo.GetOutingByType(EventType.AmusementPark);

            //ASSERT
            Assert.AreEqual(2, outing.Count);
        }
        [TestMethod]
        public void TotalCostTest()
        {
            //ARRANGE
            SeedContentList();

            //ACT
            double totalCost = _repo.TotalCost();

            //ASSERT
            Assert.AreEqual(5100.00, totalCost);
        }
        [TestMethod]
        public void TotalCostForEventTest()
        {
            //ARRANGE
            SeedContentList();

            //ACT
            double costForAmusementParks = _repo.TotalCostForEventType(EventType.AmusementPark);

            //ASSERT
            Assert.AreEqual(3650.00, costForAmusementParks);
        }
    }
}
