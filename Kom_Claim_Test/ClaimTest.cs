using KomClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Kom_Claim_Test
{
    [TestClass]
    public class ClaimTest
    {
        private readonly ClaimRepo _repo = new ClaimRepo();
        [TestMethod]
        public void AddClaimTest()
        {
            //Arrange
            Claim newClaim = new Claim(2, ClaimType.Theft, "PS5 stolen from house by ex-husband", 500.00, new DateTime(2020, 12, 20), new DateTime(2020 / 12 / 22), true, false);

            //Act
            bool wasAdded = _repo.AddClaim(newClaim);

            //Assert
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetAllClaimsTest()
        {
            //Arrange
            SeedContentList();

            //Act
            List<Claim> allClaims =_repo.GetAllClaims();

            //Assert
            Assert.AreEqual(1, allClaims.Count);
        }
        private void SeedContentList()
        {
            Claim RuinedChristmas = new Claim(1, ClaimType.Car, "Car accident", 1000.00, new DateTime(2020, 12, 25), new DateTime(2020, 12, 26), true, false);
            _repo.AddClaim(RuinedChristmas);
        }
        [TestMethod]
        public void GetClaimsByIdTest()
        {
            //Arrange
            SeedContentList();

            //Act
            Claim claim = _repo.GetClaimById(1);
            Claim emptyClaim = _repo.GetClaimById(2);

            //Assert
            Assert.IsNotNull(claim);
            Assert.IsNull(emptyClaim);
        }
        [TestMethod]
        public void UpdateClaimByIdTest()
        {
            //Arrange
            SeedContentList();
            
            //Act
            Claim updatedClaim=new Claim(1, ClaimType.Car, "Car accident", 10000.00, new DateTime(2020, 12, 25), new DateTime(2020, 12, 26), true, false);
            bool wasUpdated = _repo.UpdateClaimById(1, updatedClaim);

            //Assert
            Assert.IsTrue(wasUpdated);
        }
        [TestMethod]
        public void RemoveClaimByIdTest()
        {
            //Arrange
            SeedContentList();

            //Act
            bool wasRemoved = _repo.RemoveClaimById(1);

            //Assert
            Assert.IsTrue(wasRemoved);
        }
    }
}
