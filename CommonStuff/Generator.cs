using DataStructure;
using System;
using System.Linq;

namespace CommonStuff
{
    public static class Generator
    {
        public static INode<int> GenerateTree(int size)
        {
            return new Node<int>(NewRandomArray(size));
        }

        public static int[] NewRandomArray(int size)
        {
            Random r = new Random();
            return Enumerable.Range(0, size).Select(i => r.Next(size)).ToArray();
        }
    }
}
