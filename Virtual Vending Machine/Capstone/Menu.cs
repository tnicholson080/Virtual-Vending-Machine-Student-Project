using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Vended_Item_Types;

namespace Capstone
{
    public class Menu
    {
        public void InitiateMoney(decimal initialBalanceDue)
        {

        }

        public void Display(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Vendo-Matic 800");
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options: ");

            Console.WriteLine();
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");

            string userSelection = Console.ReadLine();
            if (userSelection == "")
            {
                Console.Clear();
                Display(displayInventory, money, VirtualInventory);
            }
            

            switch (userSelection)
            {
                case "1":
                    DisplayCurrentInventory(displayInventory, money, VirtualInventory);
                    break;
                case "2":
                    Purchase(displayInventory, money, VirtualInventory);
                    break;
                case "3":
                    Exit();
                    break;
            }
        }

        public void DisplayItems(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
            foreach (KeyValuePair<string, List<Item>> pair in displayInventory)
            {

                if (pair.Value.Count == 0)
                {
                    foreach (KeyValuePair<string, List<Item>> kvp in VirtualInventory)
                    {
                        string itemSoldOut = kvp.Value[0].BrandName.PadRight(20) + "";
                        string priceSoldOut = kvp.Value[0].Price.ToString().PadRight(10) + "";

                        if (VirtualInventory.ContainsKey(pair.Key))
                        {
                            if (pair.Key == kvp.Key)
                                Console.WriteLine($"{kvp.Key.PadRight(10)} {itemSoldOut} ${priceSoldOut} Stock: Sold Out");
                        }
                    }
                }
                else if (pair.Value.Count > 0)
                {
                    string item = pair.Value[0].BrandName.PadRight(20) + "";
                    string price = pair.Value[0].Price.ToString().PadRight(10) + "";


                    Console.WriteLine($"{pair.Key.PadRight(10)} {item} ${price} Stock: {pair.Value.Count}");
                }
            }
        }
        public void DisplayCurrentInventory(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Available products:");

            
            List<int> count = new List<int>();

            DisplayItems(displayInventory, money, VirtualInventory);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press the enter key to return to the Main Menu");
            string userInput = Console.ReadLine();
            if (userInput == "")
            {
                Display(displayInventory, money,VirtualInventory);
            }
            else
            {
                Display(displayInventory, money, VirtualInventory);
            }

        }

        public void Purchase(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
 
            Console.Clear();
            Console.Write("Please select from the following options");
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("");
            Console.WriteLine("(4) Return to Main Menu");
            Console.WriteLine("Current Money Provided: " + "$" + money.RunningTotalInserted );
            Console.WriteLine($"Current balance due: ${money.BalanceDue}");
            string userSelection = Console.ReadLine();
            if (userSelection == "")
            {
                Console.Clear();
                Purchase(displayInventory, money, VirtualInventory);
            }
            else if (userSelection == "1" || userSelection == "2" || userSelection == "3" || userSelection =="4")
            {
                switch (userSelection)
                {
                    case "1":
                        UserFeedMoney(displayInventory, money, VirtualInventory);
                        break;
                    case "2":
                        SelectProduct_s(displayInventory, money, VirtualInventory);
                        break;
                    case "3":
                        FinishTransaction(displayInventory, money, VirtualInventory);
                        break;
                    case "4":
                        Display(displayInventory, money, VirtualInventory);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Purchase(displayInventory, money, VirtualInventory);
            }
        }

        public void UserFeedMoney(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
            Console.Clear();
            bool continueToFeed = true;
            while (continueToFeed)
            {
                Console.WriteLine();
                if (money.RunningTotalInserted < money.BalanceDue)
                {
                    Console.WriteLine("Please Insert Additional Funds To Continue ");
                    Console.WriteLine("Current Money Provided: " + "$" + money.RunningTotalInserted );
                    Console.WriteLine($"Current balance due: ${money.BalanceDue}");
                    Console.WriteLine();
                    Console.WriteLine("Please insert whole dollar desired amount: ");
                    money.FeedMoney();
                    if(money.RunningTotalInserted < money.BalanceDue)
                    {
                        UserFeedMoney(displayInventory, money, VirtualInventory);
                    }
                    Console.WriteLine($"Current money provided: ${money.RunningTotalInserted}");
                    Console.WriteLine("Would you care to add additional funds?");
                    Console.WriteLine("Y/N");
                    string yesNoAddFunds = Console.ReadLine().ToUpper();

                    if (yesNoAddFunds == "Y")
                    {
                        continueToFeed = true;
                    }
                    else if (yesNoAddFunds == "N")
                    {

                        switch (yesNoAddFunds)
                        {
                            case "N":
                                Purchase(displayInventory, money, VirtualInventory);
                                break;
                        }
                        continueToFeed = false;
                    }
                }
                else if (money.RunningTotalInserted >= money.BalanceDue)
                {
                    Console.WriteLine("Please insert whole dollar desired amount: ");
                    money.FeedMoney();
                    if (money.InsertedBill <= 0)
                    {
                        money.InsertedBill = 0;
                        UserFeedMoney(displayInventory, money, VirtualInventory);
                    }
                    Console.WriteLine($"Current money provided: ${money.RunningTotalInserted}");
                }
                
                
                Console.WriteLine("Would you care to add additional funds?");
                Console.WriteLine("Y/N");
                string yesNo = Console.ReadLine().ToUpper();
               
                Log.CapstoneLog($"{DateTime.Now} FEED MONEY: ${money.InsertedBill}.00 ${money.RunningTotalInserted}");
                if( yesNo == "")
                {
                    switch (yesNo)
                    {
                            case "":
                            Purchase(displayInventory, money, VirtualInventory);
                            break;
                    }
                      
                }
                if (yesNo == "Y")
                {
                    continueToFeed = true;
                }
                else if (yesNo == "N")
                {
                    switch (yesNo)
                    {
                        case "N":
                            Purchase(displayInventory, money, VirtualInventory);
                            break;
                    }
                    continueToFeed = false;
                }
               
            }
        }

        public void SelectProduct_s(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
            bool keepGoing = true;

            while (keepGoing == true)
            {
                Console.Clear();
                DisplayItems(displayInventory, money, VirtualInventory);
                Console.WriteLine("Current Money Provided: " + "$" + money.RunningTotalInserted);
                Console.WriteLine($"Current balance due: ${money.BalanceDue}");

                Console.WriteLine("Please select slot or press (4) to return to the previous menu: ");
                string slotSelection = Console.ReadLine().ToUpper();
                Console.WriteLine();
                
                if (slotSelection == "4")
                {
                    keepGoing = false; 
                    Purchase(displayInventory, money, VirtualInventory);
                }
                
                else if (!displayInventory.ContainsKey(slotSelection))
                {
                    Console.WriteLine("Please enter a valid selection.");
                    SelectProduct_s(displayInventory, money, VirtualInventory);
                }
                else if (displayInventory[slotSelection].Count == 0)
                {
                    Console.WriteLine("This item is sold out. Hit any key to Return");

                    foreach (KeyValuePair<string, List<Item>> pair in VirtualInventory)
                    {

                        string item = pair.Value[0].BrandName.PadRight(20) + "";
                        string price = pair.Value[0].Price.ToString().PadRight(10) + "";

                        if (pair.Key == slotSelection)
                        {
                            Console.WriteLine($"{pair.Key.PadRight(10)} {item} ${price} Stock: Sold Out");
                        }
                    }

                    string userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        Purchase(displayInventory, money, VirtualInventory);
                    }
                }
                else if (displayInventory[slotSelection].Count > 0 && displayInventory.ContainsKey(slotSelection))
                {
                    Console.Clear();
                    Console.WriteLine("Great choice!\nYou chose slot " + slotSelection + ": " + displayInventory[slotSelection][0].BrandName + " $" + displayInventory[slotSelection][0].Price + ".");
                    Console.WriteLine();
                    Console.WriteLine(displayInventory[slotSelection][0].DispenseMessage());  
                    money.BalanceDue += displayInventory[slotSelection][0].Price;
                    displayInventory[slotSelection].Remove(displayInventory[slotSelection][0]);
                    keepGoing = false;

                    Console.WriteLine();
                    Console.WriteLine("Current Money Provided: " + "$" + money.RunningTotalInserted );
                    Console.WriteLine();
                    Console.WriteLine($"Current balance due: ${money.BalanceDue}");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to choose another item?");
                    
                    Console.WriteLine("Y/N");
                    string yesNo = Console.ReadLine().ToUpper();
                   
                    Log.CapstoneLog($"{DateTime.Now} {VirtualInventory[slotSelection][0].BrandName} {slotSelection}  ${money.LogRunningTotal} ${money.RunningTotalInserted - money.BalanceDue} ");
                    money.LogRunningTotal = money.RunningTotalInserted - VirtualInventory[slotSelection][0].Price;
                    if (yesNo == "Y")
                    {
                        keepGoing = true;
                    }
                    else if (yesNo == "N")
                    {
                        if (money.RunningTotalInserted < money.BalanceDue)
                        {                           
                            Console.WriteLine("Please Insert Additional Funds");
                            UserFeedMoney(displayInventory, money, VirtualInventory);
                        }
                        else
                        {
                            switch (yesNo)
                            {
                                case "N":
                                    Purchase(displayInventory, money, VirtualInventory);
                                    break;
                            }
                        }
                        
                    }
                }
            }
        }

        public void FinishTransaction(Dictionary<string, List<Item>> displayInventory, Money money, Dictionary<string, List<Item>> VirtualInventory)
        {
            {
                Console.WriteLine($"Current balance due: ${money.BalanceDue}");
                Console.WriteLine($"Your change is: ${money.RunningTotalInserted - money.BalanceDue}");
                money.Purchase(money.BalanceDue);
                Log.CapstoneLog($"{DateTime.Now}  $GIVE CHANGE: ${money.RunningTotalInserted - money.BalanceDue} $0.00");
                Console.WriteLine("Would you care to make another transaction?");
                Console.WriteLine("Y/N");
                string yesNo = Console.ReadLine().ToUpper();

                if (yesNo == "Y")
                {
                    switch (yesNo)
                    {
                        case "Y":
                            money.RunningTotalInserted = 0.00M;
                            money.BalanceDue = 0.00M;
                            Purchase(displayInventory, money, VirtualInventory);
                            
                            break;
                            
                    }
                }
                else if (yesNo == "N")
                {
                    switch (yesNo)
                    {
                        case "N":
                            Exit();
                            break;
                    }
                }
            }
        }    

            public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using Vendo-Matic 800!");
        }

    }
}
