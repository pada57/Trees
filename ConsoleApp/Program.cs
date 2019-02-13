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
            TreePrinter.Print(root);

            Console.ReadKey();
        }

        public static void PrettyPrint<T>(INode<T> node, int padding = 4)
        {
            if (node != null)
            {
                if (node.Right != null)
                {
                    PrettyPrint(node.Right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (node.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(node.Value.ToString() + "\n ");
                if (node.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    PrettyPrint(node.Left, padding + 4);
                }
            }
        }
    }
}
