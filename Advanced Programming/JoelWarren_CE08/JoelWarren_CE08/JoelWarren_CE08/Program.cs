using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace JoelWarren_CE08
{
    class Program
    {
        MySqlConnection _con =  null;

        static void Main(string[] args)
        {
            List<DVD> inventory = new List<DVD>();
            List<DVD> shoppingCart = new List<DVD>();

            Program instance = new Program();

            instance._con = new MySqlConnection();
            instance.Connect();
            DataTable data = instance.QueryDB("SELECT DVD_Title, Price, publicRating FROM dvd LIMIT 20");
            DataRowCollection rows = data.Rows;

            foreach (DataRow row in rows)
            {
                string title = row["DVD_Title"].ToString();
                decimal price = Convert.ToDecimal(row["Price"].ToString());
                float publicRating = Convert.ToSingle(row["publicRating"].ToString());
                DVD currentDvd = new DVD(title, price, publicRating);
                inventory.Add(currentDvd);
            }

            bool programIsRunning = true;
            while (programIsRunning)
            {
                string userInput = MainMenu();
                // Do what the user asks with a switch
                switch (userInput)
                {
                    case "1":
                    case "view inventory":
                        {
                            if (Validation.CollectionIsNullOrEmpty(inventory))
                            {
                                Utility.ColoredConsole("red", "Sold Out Thanks for shopping!");
                            }
                            else
                            {
                                ViewInventory(inventory);
                            }
                        }
                        break;
                    case "2":
                    case "view shopping cart":
                        {
                            if (Validation.CollectionIsNullOrEmpty(shoppingCart))
                            {
                                Utility.ColoredConsole("red", "The Shopping Cart is empty please add items first.");
                            }
                            else
                            {
                                ViewInventory(shoppingCart); // the view inventory doesn't care which list its looking at..
                            }
                        }
                        break;
                    case "3":
                    case "add dvd to cart":
                    case "add":
                        {
                            if (Validation.CollectionIsNullOrEmpty(inventory))
                            {
                                Utility.ColoredConsole("red", "Sold Out Thanks for shopping!");
                            }
                            else
                            {
                                int addedItem = AddToCart(inventory);
                                shoppingCart.Add(inventory[addedItem]);
                                inventory.RemoveAt(addedItem);
                            }
                        }
                        break;
                    case "4":
                    case "remove dvd from cart":
                    case "remove":
                        {
                            if (Validation.CollectionIsNullOrEmpty(shoppingCart))
                            {
                                Utility.ColoredConsole("red", "The Shopping Cart is empty please add items first.");
                            }
                            else
                            {
                                int removedItem = RemoveFromCart(shoppingCart);
                                inventory.Add(shoppingCart[removedItem]);
                                shoppingCart.RemoveAt(removedItem);
                                
                            }
                        }
                        break;

                    case "5":
                    case "exit":
                    case "quit":
                    case "done":
                        {
                            programIsRunning = false;
                        }
                        break;
                    default:
                        Utility.ColoredConsole("red", "Please choose a valid menu option.");
                        break;

                }
                Utility.PauseBeforeContinuing();
            }
           
            
        }

        void Connect()
        {
            BuildConString();

            try
            {
                _con.Open();
                Utility.ColoredConsole("yellow","Connection was Successful!");
                Utility.PauseBeforeContinuing();
            }
            catch(MySqlException e)
            {
                string msg = "";
                switch (e.Number)
                {
                    case 0:
                        {
                            msg = e.ToString();
                            break;
                        }
                    case 1042:
                        {
                            msg = "Can't resolve host address.\n" + _con.ConnectionString;
                            break;
                        }
                    case 1045:
                        {
                            msg = "Invalid username/password";
                            break;
                        }
                    default:
                        {
                            msg = e.ToString();
                            break;
                        }
                }

                Console.WriteLine(msg);
            }

        }

        void BuildConString()
        {
            string ip = "";

            // "c:\\VFW\\connect.txt" - escapes the \ character
            // @"c:\VFW\connect.txt" - uses the @ literal eliminating the use of special chars and reading the line as is
            using (StreamReader sr = new StreamReader("c:/VFW/connect.txt"))
            {
                ip = sr.ReadLine();
            }
            string conString;
            bool decided = Validation.GetBool("Travis would you like to change the conString to match the video settings instead of my own strings?(Y/N): ");
            if (decided)
            {
                conString = $"Server={ip};";
                conString += "uid=dbsAdmin;";
                conString += "pwd=password;";
                conString += "database=exampleDB;";
                conString += "port=8889";
            }
            else
            {
                conString = $"Server={ip};";
                conString += "uid=dbremoteuser;";
                conString += "pwd=password;";
                conString += "database=example_0818;";
                conString += "port=8889";
            }

            _con.ConnectionString = conString;
        }

        DataTable QueryDB(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _con);
            DataTable data = new DataTable();

            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(data);

            return data;

        }

        static string MainMenu()
        {
            Console.Clear();
            // display a list of options
            Console.Write(
                "1. View Inventory\n" +
                "2. View shopping cart\n" +
                "3. Add DVD to cart\n" +
                "4. Remove DVD from cart\n" +
                "5. Exit Program\n" +
                "Choose a selection: ");

            // take input from the user
            string input = Console.ReadLine().ToLower();
            return input;
        }

        static void ViewInventory(List<DVD> inventory)
        {
            int iCounter = 0;
            foreach (DVD i in inventory)
            {
                Console.WriteLine();
                Console.WriteLine($"{iCounter+1}:\n\r{i.ToString()}");
                iCounter++;
            }
            
        }

        static int  AddToCart(List<DVD> inventory)
        {
            
            Console.Clear();
            ViewInventory(inventory);
            int usersInput = Validation.GetIntGreaterThanEqualToMin(1,inventory.Count(),"Choose an Item to add: ");
            usersInput--;
            return  usersInput;
        }
        static int RemoveFromCart(List<DVD> cart)
        {

            Console.Clear();
            ViewInventory(cart);
            int usersInput = Validation.GetIntGreaterThanEqualToMin(1, cart.Count(), "Choose an Item to remove: ");
            usersInput--;
            return usersInput;
        }
    }
}
