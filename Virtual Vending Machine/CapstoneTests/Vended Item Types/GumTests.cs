using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Vended_Item_Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DispenseMessage.Tests
{
    [TestClass()]
    public class GumTests
    {
        [TestMethod()]
        public void DispenseMessageTest()
        {
            //Arrange
            Gum sut = new Gum("bobBob", 333);
            //Act

            string expected = "Chew Chew, Yum!!!";
            string acutal = sut.DispenseMessage();
            //Assert



            Assert.AreEqual(expected, acutal);
        }
    
    }
}