using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Vended_Item_Types
{
    public class Candy: Item
    {
        public Candy(string brandName, decimal price)
            : base( brandName, price)
        {

        }

        public override string DispenseMessage()
        {
            return "Munch Munch, Yum!!!";
        }

    }
}
