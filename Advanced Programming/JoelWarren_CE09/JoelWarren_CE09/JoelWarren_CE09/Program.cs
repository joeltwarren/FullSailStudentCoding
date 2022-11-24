using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JoelWarren_CE09
{
    class Program
    {
        // Implementing the logger allowing the logger to be used in the necessary methods of other classes 
        // and allowing me to use various methods of loggers for different triggers. warning / debug etc..
        private static Logger currentLogger = null;
        public static Logger GetLogger()
        {
            
            return currentLogger;
        }

        static bool customerIsChanged = false;

        
        static void Main(string[] args)
        {
            if (Validation.GetBool("Would you like to delete the previous store logs(Y/N)? "))
            {
                File.Delete(@"..\..\IOFiles\StoreLogs.txt");
            }
            
            //change this to a DoNotLog object and the program will stop logging..
            LogToFile currentlyLogging = new LogToFile();
            currentLogger = currentlyLogging;
            
            // current customer & comparison customer variables
            Customer currentCustomer = null;
            StoreManager storeManager = new StoreManager();
            LoadInventory(storeManager);


            bool customerIsChanged = false;
            bool programIsRunning = true;
            while (programIsRunning)
            {
                
                if (customerIsChanged)
                {
                    GetLogger().LogW($"Customer Changed to {currentCustomer.Name}");
                    customerIsChanged = false;
                }

                string usersMenuChoice = MainMenu(currentCustomer);
                
                
                
                
                // Do what the user asks with a switch
                //Menu must handle numeric selection “1, 2, 3, etc” as well as typed out options.
                switch (usersMenuChoice)
                {
                    case "1":
                    case "select current shopper":
                        {
                            SelectCustomer(ref currentCustomer, storeManager, ref customerIsChanged);
                        }

                        break;
                    case "2":
                    case "view store inventory":
                        {
                            
                            ViewInventory(storeManager);
                        }
                        break;
                    case "3":
                    case "view cart":
                    case "view":
                        {
                            ViewCart(currentCustomer, storeManager);
                        }
                        break;
                    case "4":
                    case "add item to cart":
                    case "add":
                        {
                            AddToCart(currentCustomer, storeManager);
                        }
                        break;
                    case "5":                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                    case "remove item from cart":
                    case "remove":
                        {
                            RemoveFromCart(currentCustomer, storeManager);
                        }
                        break;
                    case "6":
                    case "complete purchase":
                    case "complete":
                        {
                            CashOut(ref 
                                currentCustomer, storeManager);
                        }
                        break;
                    case "7":
                    case "exit":
                        {
                            //Exit - stop the program
                            programIsRunning = false;
                            
                        }
                        break;
                    default:
                        Utility.ColoredConsole("red", "Please choose a valid Menu Option!");
                        break;

                        
                }
                Console.WriteLine();
                Utility.PauseBeforeContinuing();
            }
        }
        static string MainMenu(Customer currentCustomer)
        {
            Console.Clear();
            // display a list of options
            // monitoring current customer for logging && notifications..
            if (currentCustomer != null)
            {
                Utility.ColoredConsole("yellow", $"Current Customer: {currentCustomer.Name}\n");
                //Console.WriteLine($"Current Customer: {currentCustomer.Name}\n\n");
            }
            else
            {
                Utility.ColoredConsole("yellow", "Current Customer: None \n");
            }
            Console.Write(
                "1. Select Current Customer\n" +
                "2. View Store Inventory\n" +
                "3. View Cart\n" +
                "4. Add Item to cart\n" +
                "5. Remove Item from cart\n" +
                "6. Complete Purchase\n" +
                "7. Exit\n" +
                "Select a menu option: ");

            // take input from the user
            string input = Console.ReadLine().ToLower();

            return input;
        }

        static void SelectCustomer(ref Customer currentCustomer, StoreManager storeManager, ref bool customerIsChanged)
        {
            int customerCounter = 0;
            if (currentCustomer != null && storeManager.CurrentCustomers.Count > 0)
            {
                List<Customer> customers = storeManager.CurrentCustomers;
                foreach (Customer c in customers)
                {

                    Console.WriteLine($"{customerCounter + 1}. {c.Name}");
                    customerCounter++;
                }
                Console.WriteLine($"{customerCounter+1}. Create a new Customer.");
                int usersChoice = Validation.GetIntGreaterThanEqualToMin(1, storeManager.CurrentCustomers.Count+1, "Choose an Option: ");
                if (usersChoice == storeManager.CurrentCustomers.Count+1)
                {
                    string name = Validation.CheckForBlank("Customers Name: ");
                    Customer newCustomer = new Customer(name);
                    currentCustomer = newCustomer;
                    storeManager.AddToCurrentCustomerList(newCustomer);
                    customerIsChanged = true;
                    
                }
                else
                {
                    if (currentCustomer.Name != customers[usersChoice-1].Name)
                    {
                        customerIsChanged = true;
                    }

                    currentCustomer = customers[usersChoice-1];
                }
                
            }
            else if (currentCustomer != null)
            {
                Console.WriteLine($"{customerCounter + 1}. {currentCustomer.Name}");
                Console.WriteLine($"{customerCounter + 2}. Create a new Customer.");
                int usersChoice = Validation.GetIntGreaterThanEqualToMin(1, 2, "Choose an Option: ");
                if (usersChoice == 2)
                {
                    string name = Validation.CheckForBlank("Customers Name: ");
                    Customer newCustomer = new Customer(name);
                    currentCustomer = newCustomer;
                    storeManager.AddToCurrentCustomerList(newCustomer);
                    customerIsChanged = true;
                }
                else
                {
                    //user chose the same person
                    Utility.PauseBeforeContinuing("Keeping current customer press any key to continue.");
                }
            }
            else
            {
                string name = Validation.CheckForBlank("Customers Name: ");
                Customer newCustomer = new Customer(name);
                currentCustomer = newCustomer;
                storeManager.AddToCurrentCustomerList(newCustomer);
                customerIsChanged = true;
                
            }
            
        }

        static void ViewInventory(StoreManager storeManager)
        {
            List<InventoryItem> viewingList = storeManager.GetInventoryList;
            if (viewingList.Count > 0)
            {
                int viewCounter = 0;
                foreach (InventoryItem item in viewingList)
                {
                    Console.Write($"||=============================================||\n" +
                        $"\t{item.ItemType}: {viewCounter + 1}\n" +
                        $"\tName: {item.ItemDescription}\n" +
                        $"\tPrice: {item.Price.ToString("C")}\n");
                    viewCounter++;
                    Console.WriteLine("||=============================================||\n");
                }
            }
            else
            {
                Utility.ColoredConsole("red", "Store is out of Cards Please restart the application. ");
            }

        }

        static void ViewCart(Customer currentCustomer, StoreManager storeManager)
        {
            if (currentCustomer != null)
            {
                storeManager.GetCartItems(currentCustomer.Name);
            }
            else
            {
                Utility.ColoredConsole("red", "Please create a Customer first.");
            }
        }

        static void AddToCart(Customer currentCustomer, StoreManager storeManager)
        {
            if (currentCustomer != null)
            {
                bool addingItems = true;
                while (addingItems)
                {
                    List<InventoryItem> viewingList = storeManager.GetInventoryList;
                    int viewCounter = 0;
                    foreach (InventoryItem item in viewingList)
                    {
                        Console.Write($"||=============================================||\n" +
                            $"\t{item.ItemType}: {viewCounter + 1}\n" +
                            $"\tName: {item.ItemDescription}\n" +
                            $"\tPrice: {item.Price.ToString("C")}\n");
                        viewCounter++;
                    }
                    Console.WriteLine("||=============================================||\n\n");
                    Utility.ColoredConsole("yellow", $"{viewCounter + 1}. Exit without adding additional items");
                    int userSelection = Validation.GetIntGreaterThanEqualToMin(1, viewingList.Count() + 1, "Choose a Item to add or the exit option:");
                    userSelection--;
                    if (userSelection == viewingList.Count())
                    {
                        addingItems = false;
                    }
                    else
                    {
                        storeManager.AddToCart(currentCustomer.Name, viewingList[userSelection]);
                        storeManager.RemoveInventory(userSelection);
                    }
                }
            }
            else
            {
                Utility.ColoredConsole("red", $"Please Create a Customer First! ");
            }

        }

        static void RemoveFromCart(Customer currentCustomer, StoreManager storeManager)
        {
            if (currentCustomer != null)
            {
                bool removingItems = true;
                while (removingItems)
                {
                    int maxIndex = storeManager.GetCartItems(currentCustomer.Name); // this is a count of items that the view cart is iterating
                    //storeManager.GetCartItems(currentCustomer.Name);
                    Console.WriteLine();
                    Utility.ColoredConsole("yellow", $"{maxIndex + 1}. Exit without removing items\n");
                    int userInput = Validation.GetIntGreaterThanEqualToMin(1, maxIndex + 1, "Choose and Item to Remove: ");
                    if (userInput == maxIndex + 1)
                    {
                        Utility.ColoredConsole("red", "Exiting without removing more items from the cart. ");
                        removingItems = false;
                    }
                    else
                    {
                        Utility.ColoredConsole("yellow", $"Item was removed from the cart. ");
                        Utility.PauseBeforeContinuing();
                        storeManager.RemoveFromCart(currentCustomer.Name, userInput - 1);
                        
                        
                    }
                }
            }
            else
            {
                Utility.ColoredConsole("red", "Please add a customer first. ");
            }
        }

        static void CashOut(ref Customer currentCustomer, StoreManager storeManager)
        {
            if (storeManager.CashOut(currentCustomer))
            {
                currentCustomer = null;
            }
            
        }

        static void LoadInventory(StoreManager storeManager)
        {
            List<string> inventoryList = new List<string>();
            string outPutFolder = @"..\..\IOFiles";
            using (StreamReader inventoryLoader = new StreamReader(outPutFolder + @"\CardList1.txt"))
            {

                while (inventoryLoader.Peek() > -1)
                {
                    inventoryList.Add(inventoryLoader.ReadLine());
                }
            }
            
            for (int i = 0; i < inventoryList.Count; i++)
            {
                string rawData = inventoryList[i].ToString();
                string[] items = rawData.Split(',');
                string description = items[0];
                string type = "Card";
                decimal price = Convert.ToDecimal(items[1].ToString());
                InventoryItem newItem = new InventoryItem(description,type,price);
                storeManager.AddInventory(newItem);
            }
        }
    }
}
