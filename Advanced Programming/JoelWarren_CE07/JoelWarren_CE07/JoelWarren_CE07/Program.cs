using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JoelWarren_CE07
{
    class Program
    {
        //Output Location for our Files
        private static string outPutFolder = @"..\..\IOFiles";
        private static List<string> layout = new List<string>();
        private static List<string> data = new List<string>();
        private static List<string> formattedData = new List<string>();

        static void Main(string[] args)
        {
            // verifying the directory exists and if it does not we will create it.
            Directory.CreateDirectory(outPutFolder);
            // verifying the file exists and if it does not we will create it.
            //File.Create(outPutFolder + @"\finalJsonOutput.json");
            File.Create(outPutFolder + @"\finalJsonOutput.json").Close();

            bool programIsRunning = true;
            while (programIsRunning)
            {
                string userInput = MainMenu();
                // Do what the user asks with a switch
                switch (userInput)
                {
                    case "1":
                    case "choose a file to load and convert":
                    case "choose":
                        {
                            LoadTheLayout(layout);
                            string fileChosen = ChooseAFile();
                            ConvertToJson(fileChosen, data, formattedData);
                        }
                        break;

                    case "2":
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

        static string MainMenu()
        {
            Console.Clear();
            // display a list of options
            Console.Write(
                "1. Choose a file to load and convert\n" +
                "2. Exit Program\n" +
                "Choose a selection: ");

            // take input from the user
            string input = Console.ReadLine().ToLower();
            return input;
        }
        
        static void LoadTheLayout(List<string> layout)
        {
            using (StreamReader layOutReader = new StreamReader(outPutFolder + @"\DataFieldsLayout.txt"))
            {
                
                while (layOutReader.Peek() > -1)
                {
                    layout.Add("\""+layOutReader.ReadLine()+"\""); 
                }
            }
        }
        static string ChooseAFile()
        {
            bool choosingAFile = true;
            string chosenFile = "none";
            Console.Clear();
            // display a list of options
            Console.Write(
                "1. DataFile 1\n" +
                "2. DataFile 2\n" +
                "3. DataFile 3\n" +
                "Choose a selection: ");

            // take input from the user
            string input = Console.ReadLine().ToLower();
            while (choosingAFile)
            { 
                switch (input)
                { 
                    case "1":
                    case "datafile 1":
                        {
                            chosenFile = outPutFolder + @"\DataFile1.txt";
                            Utility.ColoredConsole("yellow","Data File 1 Chose.");
                            Utility.PauseBeforeContinuing();
                            choosingAFile = false;
                        }
                    break;
                    case "2":
                    case "datafile 2":
                        {
                            chosenFile = outPutFolder + @"\DataFile2.txt";
                            Utility.ColoredConsole("yellow","Data File 2 Chose.");
                            Utility.PauseBeforeContinuing();
                            choosingAFile = false;

                        }
                        break;
                    case "3":
                    case "datafile 3":
                        {
                            chosenFile = outPutFolder + @"\DataFile3.txt";
                            Utility.ColoredConsole("yellow","Data File 3 Chose.");
                            Utility.PauseBeforeContinuing();
                            choosingAFile = false;
                        }
                        break;
                    
                    default:
                    Utility.ColoredConsole("red", "Please choose a valid menu option.");
                    break;
                }
            }
            return chosenFile;
            
        }
        static void ConvertToJson(string fileName, List<string> data, List<string> formattedData)
        {
            // creating a list of the entire record to be parsed by newline characters so one whole record is each item in the list
            using (StreamReader dataReader = new StreamReader(fileName))
            {

                while (dataReader.Peek() > -1)
                {
                    data.Add(dataReader.ReadLine());
                }
                int totalRows = data.Count();
                data.RemoveAt(totalRows - 1);
                data.RemoveAt(0);
            }
            // using a temporary array to split the data up by the | symbol
            foreach (string item in data)
            {
                string[] tempArray = item.Split('|');
                foreach (string singleEntry in tempArray)
                {
                    formattedData.Add("\"" + singleEntry + "\"");
                }
            }
           
            Console.WriteLine($"FileChosen: {fileName}");
            
            // creating a final list of combined list strings plus a beginning and ending set of syntax
            List<string> finalOutput = new List<string>();
            int layoutCounter = 0;
            int dataCounter = 0;
            finalOutput.Add("{\"array\":[{");
            do
            {
                
                finalOutput.Add(layout[layoutCounter] + ":" + formattedData[dataCounter] + ",");
                if (formattedData[dataCounter] == "\"!end\"") { finalOutput.Add("},{"); }
                
                layoutCounter++;
                dataCounter++;
                if (layoutCounter == 150 && dataCounter == 15000)
                {
                    break;
                }
                else if (layoutCounter == 150) { layoutCounter = 0; }
            } while (layoutCounter != layout.Count);
            finalOutput.Add("}]}");
            int finalCounter = 0;
            do
            {

                //Console.WriteLine(finalOutput[finalCounter]);
                //Utility.PauseBeforeContinuing();
                if (finalOutput[finalCounter] == "\"END OF RECORD INDICATOR\":\"!end\",")
                {
                    //Console.WriteLine(finalCounter);
                    finalOutput[finalCounter] = "\"END OF RECORD INDICATOR\":\"!end\"";
                    //Console.WriteLine(finalOutput[finalCounter]);
                }
                finalCounter++;
            } while (finalCounter != finalOutput.Count);
            //Utility.PauseBeforeContinuing();

            finalOutput.RemoveAt(15100);
            //foreach (string i in finalOutput) { Console.WriteLine($"{i}"); }
            using (StreamWriter outStream = new StreamWriter(outPutFolder + @"\finalJsonOutput.json"))
            {
                foreach (string listItem in finalOutput)
                { 
                    outStream.WriteLine(listItem);
                }
            }
            Utility.ColoredConsole("yellow","The json file has been created!");
            
        }
    }
}
