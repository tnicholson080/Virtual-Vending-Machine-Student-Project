using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Vended_Item_Types;
namespace Capstone
{
    public abstract class Item
    {

        public string BrandName { get; }  
        public decimal Price { get; }  //look at conversion later decimal vs double

        public Item(string brandName, decimal price)
        {

            BrandName = brandName;
            Price = price;
        }

        public abstract string DispenseMessage();
        
    }
}
  