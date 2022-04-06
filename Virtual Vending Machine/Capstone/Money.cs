using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Vended_Item_Types;
namespace Capstone
{
    public class Money
    {
        
        /*public decimal Quarter = 0.25M;
        public decimal Dime = 0.10M;
        public decimal Nickel = 0.05M;*/
        public decimal Change { get; set; }
        public decimal RunningTotalInserted { get; set; } = 0.00M;

        public decimal BalanceDue { get; set; } = 0.00M;

        public decimal InsertedBill { get; set; } = 0.00M;

        public decimal LogRunningTotal { get; set; } = 0.00M;

        public void InitiateMoney(decimal balanceDue)
        {

        }

        public void FeedMoney()
        {
            bool isItANumber = true;
            while (isItANumber == true)
            { 
                decimal insertedBill = 0.00M;
                string stringBill = Console.ReadLine();
                if (decimal.TryParse(stringBill, out insertedBill))
                {
                    insertedBill = decimal.Parse(stringBill);
                    isItANumber = false;
                    if (insertedBill <= 0)
                    {
                        insertedBill = 0.00M;
                    }
            
                RunningTotalInserted = RunningTotalInserted + insertedBill ;
                InsertedBill = insertedBill;
                LogRunningTotal = RunningTotalInserted;

                }
                else if (!decimal.TryParse(stringBill, out insertedBill))
                {
                    Console.WriteLine("You did not enter a numerical value. Try again.");
                }
            
            
            }
        }
       
        public void Purchase (decimal balanceDue)
        {
            
            BalanceDue = balanceDue;
            Change = RunningTotalInserted - BalanceDue;
          

            Change = Change * 100;
            int anQuarter = 0;
            int anDime = 0;
            int anNickel = 0;
            

            while (Change >= 25)
            {
                Change = Change - 25;
                anQuarter++;
            }
            while (Change >= 10)
            {
                anDime++;
                Change = Change - 10;
            }
            while (Change >= 5)
            {
                anNickel++;
                Change = Change - 5;
            }
         

            Console.WriteLine($"You change will be {anQuarter} quarters, {anDime} dimes, and {anNickel} nickels"); 
        }
    }
}
