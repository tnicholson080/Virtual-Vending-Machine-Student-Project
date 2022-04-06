using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Vended_Item_Types
{
    public class Gum: Item
    {
        public Gum( string brandName, decimal price)
            : base( brandName, price)
        {

        }

        public override string DispenseMessage()
        {
            return "Chew Chew, Yum!!!";
        }

    }
}
