﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Vended_Item_Types
{
    public class Chip: Item
    {
        public Chip(string brandName, decimal price)
            : base(brandName, price)
        {
            
        }

        public override string DispenseMessage()
        {
            return "Crunch Crunch, Yum!!!";
        }
    }
}
