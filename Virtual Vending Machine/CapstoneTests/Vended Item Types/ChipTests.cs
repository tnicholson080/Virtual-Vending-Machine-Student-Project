using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Vended_Item_Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DispenseMessage.Tests
{
    [TestClass()]
    public class ChipTests
    {
        [TestMethod()]
        public void DispenseMessageTest()
        {
            //Arrange
            Chip sut = new Chip("bobBob", 333);
            //Act

            string expected = "Crunch Crunch, Yum!!!";
            string acutal = sut.DispenseMessage();
            //Assert



            Assert.AreEqual(expected, acutal);
        }
    }
}