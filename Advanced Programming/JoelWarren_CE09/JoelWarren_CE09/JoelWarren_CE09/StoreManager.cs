using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE09
{
    class StoreManager
    {
        private List<InventoryItem> _InventoryList;
        private List<Customer> _Customers;
        private Dictionary<string, List<InventoryItem>> _ShoppingCart;

        public StoreManager()
        {
            _InventoryList = new List<InventoryItem>();
            _Customers = new List<Customer>();
            _ShoppingCart = new Dictionary<string, List<InventoryItem>>();
        }
        public List<InventoryItem> GetInventoryList
        {
            get
            {
                return _InventoryList;
            }
        }

        public List<Customer> CurrentCustomers
        {
            get
            {
                return _Customers;
            }
        }



        public void AddInventory(InventoryItem newItem)
        {
                _InventoryList.Add(newItem);
                Program.GetLogger().LogW($"Item: {newItem.ItemDescription} was added to store inventory.");
        }

        public void RemoveInventory(int index)
        {
            if (!Validation.CollectionIsNullOrEmpty(_InventoryList))
            {
                if (index < _InventoryList.Count)
                {
                    Program.GetLogger().LogW($"Item: {_InventoryList[index].ItemDescription} was removed from store inventory.");
                    _InventoryList.RemoveAt(index);
                }
                else
                {
                    Utility.ColoredConsole("red", "Index was out of range try index-1;");
                }
            }
            else
            {
                Utility.ColoredConsole("Inventory has not been added to the store yet.");
            }
        }

        public void AddToCurrentCustomerList(Customer newCustomer)
        {
            bool exists = false;
            foreach (Customer c in _Customers)
            {
                if (c.Name == newCustomer.Name)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                Utility.ColoredConsole("red","Customer found please create a differnt customer!");
                string usersInput = Validation.CheckForBlank("Customers Name: ");
                Customer nextTry = new Customer(usersInput);
                AddToCurrentCustomerList(nextTry);
            }
            else
            {
                _Customers.Add(newCustomer);
            }
        }

        public Customer SetCurrentCustomer(int index)
        {
            if (_Customers?.Count > 0)
            {
                return _Customers[index];
            }
            else { return null; }
        }

        public void AddToCart(string customer, InventoryItem newItem)
        {

            if (_ShoppingCart.Keys.Contains(customer))
            {
                _ShoppingCart[customer].Add(newItem);
                Program.GetLogger().LogW($"Item: {newItem.ItemDescription} was added to {customer}'s cart.");
            }
            else
            {
                _ShoppingCart[customer] = new List<InventoryItem> { newItem };
                Program.GetLogger().LogW($"Item: {newItem.ItemDescription} was added to {customer}'s cart.");

            }

        }

        public void RemoveFromCart(string customer, int index)
        {
            if (_ShoppingCart.Keys.Contains(customer))
            {
                InventoryItem itemRemoved;

                if (_ShoppingCart.TryGetValue(customer, out List<InventoryItem> thisList))
                {
                    itemRemoved = thisList[index];
                    Program.GetLogger().LogW($"Item: {itemRemoved.ItemDescription} was removed from {customer}'s cart.");
                    Program.GetLogger().LogW($"Item: {itemRemoved.ItemDescription} was added to store inventory.");
                    _ShoppingCart[customer].RemoveAt(index);
                    _InventoryList.Add(itemRemoved);
                }
                else
                {
                    Utility.ColoredConsole("red", $"The item you chose does not exist in {customer}'s cart!");
                }
            }
            else
            {
                Utility.ColoredConsole("red", $"The customer does not exist!");
            }

        }

        public int GetCartItems(string customer)
        {
            if (!string.IsNullOrEmpty(customer))
            {
                List<InventoryItem> returnedList = new List<InventoryItem>();
                
                if (_ShoppingCart.TryGetValue(customer, out returnedList))
                {
                    if (returnedList.Count > 0)
                    {
                        int viewCounter = 0;
                        foreach (InventoryItem item in returnedList)
                        {
                            Console.Write($"||=============================================||\n" +
                            $"\t{item.ItemType}: {viewCounter + 1}\n" +
                            $"\tName: {item.ItemDescription}\n" +
                            $"\tPrice: {item.Price.ToString("C")}\n");
                            viewCounter++;
                            Console.WriteLine("||=============================================||\n");
                        }
                        return viewCounter;
                    }
                    else
                    {
                        Utility.ColoredConsole("red", "Current Customer has no items in the cart please add items first.");
                        
                    }
                }
                else
                {
                    Utility.ColoredConsole("red", "Current Customer has no items in the cart please add items first.");

                }
            }
            else
            {
                Utility.ColoredConsole("red", "Please create a customer first!.");
                
            }
            return 0;
        }

        public bool CashOut(Customer customer)
        {
            bool successful = false;
            decimal total = 0;
            if (customer != null)
            {
                if (_ShoppingCart.TryGetValue(customer.Name, out List<InventoryItem> returnedList))
                {
                    if (returnedList.Count > 0)
                    {
                        foreach (InventoryItem item in returnedList)
                        {
                            total += item.Price;
                        }
                        Utility.ColoredConsole("yellow",$"Customer: {customer.Name} has checked out of the store.\n{customer.Name}'s carts Totals: {total.ToString("C")}.");
                        Program.GetLogger().LogW($"Customer: {customer.Name} has checked out of the store.\n {customer.Name}'s carts Totals: {total.ToString("C")}.");
                        _ShoppingCart.Remove(customer.Name);
                        int indexToRemove = -1;
                        int loopCounter = 0;
                        foreach (Customer c in _Customers)
                        {
                            
                            if (customer.Name == c.Name)
                            {
                                indexToRemove = loopCounter;
                            }
                            loopCounter++;
                        }
                        //Console.WriteLine($"Test Line - {_Customers[indexToRemove].Name} was removed from the list of customers..");
                        _Customers.RemoveAt(indexToRemove);
                        successful = true;
                        return successful;
                    }
                    else
                    {
                        Utility.ColoredConsole("red", "Current Customer has no items in the cart. Please add items to continue.");
                    }

                }
                else
                {
                    Utility.ColoredConsole("red", "Current Customer has no items in the cart. Please add items to continue.");
                }
            }
            else
            {
                Utility.ColoredConsole("red","Please create a customer first and add items to a cart first.");

            }
            return successful;
        }
    }
    
}
