using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Vended_Item_Types;
namespace Capstone
{
    public class VendingMachine
    {
        

        public Dictionary<string, List<Item>> CurrentInventory;

        private Menu vendingMenu = new Menu();

        private Money vendingMoney = new Money();

        public decimal initialBalanceDue = 0;

        public Dictionary<string, List<Item>> VirtualInventory { get; private set; }

        public VendingMachine()
        {
            Stock();
            StockVirtual();
        }

        public void Run()
        {
            vendingMenu.Display(CurrentInventory, vendingMoney, VirtualInventory);
            vendingMenu.InitiateMoney(initialBalanceDue);
            vendingMoney.InitiateMoney(initialBalanceDue);
        }
        

        
        public void Stock()
        {
            string directory = @"C:\Users\Student\workspace\c-sharp-mini-capstone-module-1-team-4";
            string filename = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, filename);

            Dictionary<string, List<Item>> stockDictionary = new Dictionary<string, List<Item>>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split('|');
                        List<Item> listOfItems = new List<Item>();
                        for (int i = 0; i < 5; i++)
                        {
                            if (words[3] == "Chip")
                            {
                                Chip item = new Chip(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                            if (words[3] == "Candy")
                            {
                                Candy item = new Candy(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                            if (words[3] == "Drink")
                            {
                                Drink item = new Drink(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                            if (words[3] == "Gum")
                            {
                                Gum item = new Gum(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                        }
                        //Log.CapstoneLog(CurrentInventory.ToString());
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            CurrentInventory = stockDictionary;

        }


        public void StockVirtual()
        {
            string directory = @"C:\Users\Student\workspace\c-sharp-mini-capstone-module-1-team-4";
            string filename = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, filename);

            Dictionary<string, List<Item>> stockDictionary = new Dictionary<string, List<Item>>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split('|');
                        List<Item> listOfItems = new List<Item>();
                        for (int i = 0; i < 1; i++)
                        {
                            if (words[3] == "Chip")
                            {
                                Chip item = new Chip(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                            if (words[3] == "Candy")
                            {
                                Candy item = new Candy(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                            if (words[3] == "Drink")
                            {
                                Drink item = new Drink(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                            if (words[3] == "Gum")
                            {
                                Gum item = new Gum(words[1], decimal.Parse(words[2]));
                                listOfItems.Add(item);
                                stockDictionary[words[0]] = listOfItems;
                            }
                        }
                        //Log.CapstoneLog(CurrentInventory.ToString());
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            VirtualInventory = stockDictionary;
        }
    }
}
