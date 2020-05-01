using System;

namespace Lab3OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<Mammals> mammalList = null;
            MainConstruct main = new MainConstruct();
            JsonConverter jsonObj = new JsonConverter();


            do
            {
                Console.WriteLine("Choose action");
                Console.WriteLine("F1 Clear Console\n" +
                    "1) Display mammals types\n" +
                    "2) Fill mammals list\n" +
                    "3) Display mammals list\n" +
                    "4) Read mammals from file\n" +
                    "5) Write mammals list to file\n" +
                    "6) Delete mammal by id\n" +
                    "7) Exit");
                switch (Console.ReadKey().Key)
                {
                   case ConsoleKey.F1:
                        Console.Clear();
                        break;
                    case ConsoleKey.D1:
                        main.DisplayMammalsType();
                        break;
                    case ConsoleKey.D2:
                        mammalList = main.ChooseMammals();
                        break;
                    case ConsoleKey.D3:
                        main.DisplayMammals(mammalList);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine(" Path to file");
                       mammalList = jsonObj.DeserializeStringIntoList(jsonObj.ReadJsonFromFile(Console.ReadLine()));
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine(" Path to file");
                        jsonObj.WriteJsonToFile(Console.ReadLine(), jsonObj.SerializeListIntoString(mammalList));
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine(" Mammal id to delete");
                        mammalList = main.DeleteMammal(mammalList, int.Parse(Console.ReadLine()));
                        break;
                    case ConsoleKey.D7:
                        Environment.Exit(0);
                        break;
                }
            }
            while (true);



            
        }
    }


}
