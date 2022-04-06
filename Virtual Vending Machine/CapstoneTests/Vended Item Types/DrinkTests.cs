using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Vended_Item_Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DispenseMessage.Tests
{
    [TestClass()]
    public class DrinkTests
    {
        [TestMethod()]
        public void DispenseMessageTest()
        {
            //Arrange
            Drink sut = new Drink("bobBob", 333);
            //Act

            string expected = "Glug Glug, Yum!!!";
            string acutal = sut.DispenseMessage();
            //Assert



            Assert.AreEqual(expected, acutal);
        }
    }
}