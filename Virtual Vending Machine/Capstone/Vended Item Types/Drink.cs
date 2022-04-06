using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Vended_Item_Types
{
    public class Drink : Item 
    {
        public Drink (string brandName, decimal price) 
            : base ( brandName, price)
        {

        }

        public override string DispenseMessage()
        {
            return "Glug Glug, Yum!!!";
        }
    }
}
