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

            Console.ReadKey();
        }

        
    }
}
