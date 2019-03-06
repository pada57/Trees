using CommonStuff;
using DataStructure;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###############################");
            Console.WriteLine($"##### Tree &# algorithms #####");
            Console.WriteLine("###############################");

            var root = Generator.GenerateTree(20);

            Console.WriteLine("Tree generated:");
            //PrettyPrint(root);
            root.PrintToConsole();

            foreach (var item in root)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("enter value to delete :");
            var value = Console.ReadLine();
            
            root.Delete(Convert.ToInt32(value));

            root.PrintToConsole();

            Console.WriteLine("enter value contains :");
            value = Console.ReadLine();
            Console.WriteLine($"{root.Contains(Convert.ToInt32(value))}");

            Console.ReadKey();
        }

        
    }
}
