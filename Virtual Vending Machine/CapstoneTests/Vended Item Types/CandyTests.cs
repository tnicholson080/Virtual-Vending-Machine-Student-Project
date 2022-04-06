using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Vended_Item_Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DispenseMessage.Tests
{
    [TestClass()]
    public class CandyTests
    {
        [TestMethod()]
        public void DispenseMessageTest()
        {
            //Arrange
            Candy sut = new Candy("bobBob", 333);
            //Act

            string expected = "Munch Munch, Yum!!!";
            string acutal = sut.DispenseMessage();
            //Assert

           
            
            Assert.AreEqual(expected, acutal);
        }
    }
}