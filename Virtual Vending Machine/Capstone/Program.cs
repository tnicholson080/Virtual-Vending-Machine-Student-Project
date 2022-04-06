using System;
using Capstone;
using Capstone.Vended_Item_Types;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            vm.Run();
            

            //Log.CapstoneLog("");

        }
    }
}
