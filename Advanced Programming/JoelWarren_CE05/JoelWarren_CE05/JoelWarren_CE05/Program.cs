using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE05
{
    class Program
    {
        static private int numOfUnusedCards = 0;
        static void Main(string[] args)
        {
            CollectionManager currentManager = null;


            bool programIsRunning = true;

            // while loop for program starting the menu
            while (programIsRunning)
            {

                string userInput = MainMenu();
                // Do what the user asks with a switch
                switch (userInput)
                {
                    case "1":
                    case "create collection":
                        {
                            if (currentManager != null)
                            {

                                Utility.ColoredConsole("red", "Preforming this action will delete any previous collections: ");
                                bool usersResponse = Validation.GetBool("\nContinue ?: (y / n)");


                                if (usersResponse)
                                {
                                    //Console.WriteLine("Previous Collcetion Destroyed!");
                                    Utility.ColoredConsole("red", "Previous Collection Destroyed!");
                                    numOfUnusedCards = 0;
                                    currentManager = CreateCollection();

                                }
                                else
                                {
                                    //Console.WriteLine("Collection not destroyed!");
                                    Utility.ColoredConsole("yellow", "Collection not destroyed!");
                                }

                            }
                            else
                            {
                                currentManager = CreateCollection();
                                //Console.WriteLine("Collection Created.");
                                Utility.ColoredConsole("yellow", "Collection Created.");
                            }

                        }
                        break;
                    case "2":
                    case "create a card":
                        {
                            if (currentManager != null)
                            {
                                CreateCard(currentManager);
                            }
                            else
                            {
                                Utility.ColoredConsole("red", "Please create a collection first!");
                            }
                        }
                        break;
                    case "3":
                    case "add a card to a collection":
                    case "add":
                    case "a":
                        {
                            if (currentManager != null)
                            {
                                AddToCollection(currentManager);
                            }
                            else
                            {
                                //Console.WriteLine("Please create a collection first!");
                                Utility.ColoredConsole("red", "Please create a collection first!");
                            }

                        }
                        break;
                    case "4":
                    case "remove a card from a collection":
                    case "remove":
                    case "r":
                        {
                            if (currentManager != null)
                            {
                                RemoveFromCollection(currentManager);
                            }
                            else
                            {
                                Utility.ColoredConsole("red", "Please create a collection first!");
                            }

                        }
                        break;
                    case "5":
                    case "display a collection":
                    case "display":
                    case "print":
                        {
                            if (currentManager != null)
                            {
                                DisplayACollection(currentManager);
                            }
                            else
                            {
                                Utility.ColoredConsole("red", "Please create a collection first!");
                            }
                        }
                        break;
                    case "6":
                    case "display all collections":
                    case "display all":
                    case "print all":
                        {
                            if (currentManager != null)
                            {
                                DisplayAllCollections(currentManager);
                            }
                            else
                            {
                                Utility.ColoredConsole("red", "Please create a collection first!");
                            }
                        }
                        break;
                    case "7":
                    case "exit":
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
        static string MainMenu()
        {
            Console.Clear();
            // display a list of options
            Console.Write(
                "1. Create collection\n" +
                "2. Create a card\n" +
                "3. Add a card to a collection\n" +
                "4. Remove a card from a collection\n" +
                "5. Display a collection\n" +
                "6. Display all collections\n" +
                "7. Exit\n" +
                $"Current Number of Unused Cards: {numOfUnusedCards} " + "\r\n" +
                "Select your selection: ");


            // take input from the user
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static CollectionManager CreateCollection()
        {
            CollectionManager currentManager = new CollectionManager();
            return currentManager;
        }

        static void CreateCard(CollectionManager currentManager)
        {

            Console.WriteLine("\n");
            Console.Write("Please enter a card name: ");
            string name = Validation.CheckForBlank(Console.ReadLine());
            Console.Write("PLease enter a card description: ");
            string description = Validation.CheckForBlank(Console.ReadLine());
            decimal value = Validation.GetDecimalGreaterThanEqualToMin(0, decimal.MaxValue, "Please enter an estimated value: $ ");
            Card addedCard = new Card(name, description, value);
            numOfUnusedCards += 1;
            currentManager.AddToList(addedCard);
        }

        static void AddToCollection(CollectionManager currentManager)
        {

            Console.WriteLine("\n");
            List<Card> cards = currentManager.GetList();
            if (cards.Count > 0)
            {
                string ownersName;
                List<string> currentOwnersNames = currentManager.GetDictionaryKeys();
                if (currentOwnersNames != null)
                {
                    int indexCounter = 0;
                    foreach (string i in currentOwnersNames)
                    {
                        Console.WriteLine($"{indexCounter + 1}. {i}");
                        indexCounter++;
                    }
                    Console.WriteLine($"{indexCounter + 1}. Create a new collection owner");
                    int userSelectedOwner = Validation.GetIntGreaterThanEqualToMin(1, indexCounter + 1, "Choose a card owner: ");
                    if (userSelectedOwner == indexCounter + 1)
                    {
                        Console.Write("Please enter the collection owners name: ");
                        ownersName = Validation.CheckForBlank(Console.ReadLine());
                    }
                    else
                    {
                        ownersName = currentOwnersNames[userSelectedOwner - 1];
                    }
                }
                else
                {
                    Console.Write("Please enter the collection owners name: ");
                    ownersName = Validation.CheckForBlank(Console.ReadLine());
                }


                Console.WriteLine("Available Cards:");

                int counter = 0;
                for (int i = 0; i < cards.Count; i++)
                {
                    Console.WriteLine($"\t         Card {i + 1}:\n {cards[i].ToString()}");
                    counter++;
                }
                int userChose = Validation.GetIntGreaterThanEqualToMin(1, counter, $"Please Choose a card to add to {ownersName}'s Collection: ");
                userChose--;
                currentManager.AddToDictionary(ownersName, cards[userChose]);
                Utility.ColoredConsole("yellow", $"Added The Card:\n\n{cards[userChose].ToString()}\n\nTo: {ownersName}'s collection!");
                currentManager.RemoveFromList(userChose);
                numOfUnusedCards -= 1;
            }
            else
            {

                Utility.ColoredConsole("red", "We have used all the availabe cards please create more cards!");
            }

        }

        static void RemoveFromCollection(CollectionManager currentManager)
        {
            Console.WriteLine("\n");
            List<string> currentOwnersNames = currentManager.GetDictionaryKeys();
            Dictionary<string, List<Card>> collection = currentManager.GetDictionary();
            
            if (collection?.Count > 0)
            {
                int counter = 0;
                foreach (string name in currentOwnersNames)
                {
                    Console.WriteLine($"{counter + 1}: {name}");
                    counter++;
                }
                int usersChoice = Validation.GetIntGreaterThanEqualToMin(1,counter + 1, "Choose a collection owner to remove cards from: ");
                usersChoice--;
                string key = currentOwnersNames[usersChoice];
                
                int counter2 = 0;
                if (collection.ContainsKey(key) && collection?[key].Count > 0)
                {
                    Console.WriteLine("Available Cards:");
                    foreach (Card currentCard in collection[key])
                    {
                        
                        Console.WriteLine($"\t         Card {counter2 + 1}:");
                        Console.WriteLine(currentCard.ToString());
                        counter2++;
                    }
                    int removeThisCard = Validation.GetIntGreaterThanEqualToMin(1, counter2 + 1, "Choose a Card to Remove: ");
                    removeThisCard--;
                    Card selectedCard = currentManager.GetCard(key, removeThisCard);
                    currentManager.AddToList(selectedCard);
                    numOfUnusedCards++;
                    currentManager.RemoveFromDictionary(key, counter2);
                    Utility.ColoredConsole("yellow",$"Card:\n{selectedCard.ToString()}\nRemoved from {key}'s collection and added to available cards list. ");

                }
                else
                {
                    Utility.ColoredConsole("red","Current Owner does not have any cards to display add more to their collection.");
                }

            }
            else
            {
                Utility.ColoredConsole("red","Please add cards to a collection first!");
            }
            
        }

        static void DisplayACollection(CollectionManager currentManager)
        {
            Console.WriteLine("\n");
            List<string> currentOwnersNames = currentManager.GetDictionaryKeys();
            Dictionary<string, List<Card>> collection = currentManager.GetDictionary();

            if (collection?.Count > 0)
            {
                int counter = 0;
                foreach (string name in currentOwnersNames)
                {
                    Console.WriteLine($"{counter + 1}: {name}");
                    counter++;
                }
                int usersChoice = Validation.GetIntGreaterThanEqualToMin(1, counter + 1, "Choose a collection owner to view their cards: ");
                usersChoice--;
                string key = currentOwnersNames[usersChoice];

                int counter2 = 0;
                if (collection.ContainsKey(key) && collection?[key].Count > 0)
                {
                    Console.WriteLine("Available Cards:");
                    foreach (Card currentCard in collection[key])
                    {

                        Console.WriteLine($"\t         Card {counter2 + 1}:");
                        Console.WriteLine(currentCard.ToString());
                        counter2++;
                    }
                    
                }
                else
                {
                    Utility.ColoredConsole("red","Current Owner does not have any cards to display add more to their collection.");
                }

            }
            else
            {
                Utility.ColoredConsole("red", "Please add cards to a collection first!");
            }
        }
        static void DisplayAllCollections(CollectionManager currentManager)
        {
            List<string> currentOwnersNames = currentManager.GetDictionaryKeys();
            Dictionary<string, List<Card>> collection = currentManager.GetDictionary();
            int counter2 = 0;
            foreach (string name in currentOwnersNames)
            {
                Console.WriteLine("\n*******************************************************************");
                Console.WriteLine($"\n{name}'s Current Cards are:");
                foreach (Card currentCard in collection[name])
                {

                    Console.WriteLine($"\t         Card {counter2 + 1}:");
                    Console.WriteLine(currentCard.ToString());
                    counter2++;
                }

            }

        }
    }
}
