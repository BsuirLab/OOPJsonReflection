using System.IO;
using System.Text.Json;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Lab3OOP
{
    class MainConstruct
    {
        public void DisplayMammalsType()
        {
            Console.WriteLine(" [Mammals List]");
            Type ourtype = typeof(Mammals); // Базовый тип
            IEnumerable<Type> list = Assembly.GetAssembly(ourtype).GetTypes().Where((type) => type.IsSubclassOf(ourtype) &&
                                                                                              !type.IsAbstract);  // using System.Linq

            foreach (Type itm in list)
            {
                Console.WriteLine(itm.Name);
            }
            Console.WriteLine("{0}", string.Concat(Enumerable.Repeat("_", 20)));
        }

        public List<Mammals> ChooseMammals()
        {
            List<Mammals> mammals = new List<Mammals>();
            int count = 0;
            bool isNumeric = false;

            do
            {
                Console.WriteLine(" Input correct numeric count");
                isNumeric = int.TryParse(Console.ReadLine(), out count);
            }
            while (isNumeric == false || count <= 0);

            for (int i = 0; i < count; i++)
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Console.WriteLine("Choose mammal");
                Type myType = Type.GetType(assemblyName + "." + Console.ReadLine());
                if (myType != null)
                {
                    var constructors = myType.GetConstructors();
                    int? constructorsCount = 0;
                    foreach (var constructor in constructors)
                    {
                        Console.WriteLine("{0}", string.Concat(Enumerable.Repeat("#", 20)));
                        Console.WriteLine($"Constructor №{constructorsCount++} with " + constructor.GetParameters().Count() + " params\nFields:");
                        var constructorParams = constructor.GetParameters();
                        foreach (var param in constructorParams)
                        {
                            Console.Write("[" + param.ParameterType + "] " + param.Name + "\n");
                        }
                        Console.WriteLine("{0}", string.Concat(Enumerable.Repeat("#", 20)));
                    }
                    int constrNum = 0;
                    do
                    {
                        Console.WriteLine("Choose correct constructor number");
                        isNumeric = int.TryParse(Console.ReadLine(), out constrNum);
                    }
                    while (isNumeric == false || constrNum < 0);
                    object[] parameters = new object[constructors[constrNum].GetParameters().Count()];

                    for (int j = 0; j < constructors[constrNum].GetParameters().Count(); j++)
                    {
                        Type currentType = constructors[constrNum].GetParameters()[j].ParameterType;
                        Console.WriteLine("[" + constructors[constrNum].GetParameters()[j].ParameterType + "] " + constructors[constrNum].GetParameters()[j].Name + ":");
                        parameters[j] = Convert.ChangeType(Console.ReadLine(), currentType);


                    }
                    mammals.Add((Mammals)Activator.CreateInstance(myType, parameters));
                }
                else
                {
                    Console.WriteLine("mammal not found");
                    i--;
                }
            }
            return mammals;
        }

        public List<Mammals> DeleteMammal(List<Mammals> mammalsList,int index)
        {
            mammalsList.RemoveAt(index);
            return mammalsList;
        }

        public void DisplayMammals(List<Mammals> mammals)
        {
            int? mammalNum = 0;
            Console.WriteLine("{0}", string.Concat(Enumerable.Repeat("#", 20)));
            foreach (var item in mammals)
            {
                Console.WriteLine("Type = {0} | Number in list = {1}", item.GetType().Name, mammalNum++);
                foreach (var prop in item.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(item, null));
                }

            }
        }
    }
}
