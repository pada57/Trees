using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonStuff
{
    public static class Generator
    {
        public static BinarySearchTree<int> GenerateTree(int size)
        {
            var tree = new BinarySearchTree<int>();

            foreach (var value in NewRandomArray(size))
            {
                tree.Insert(value);
            }

            return tree;
        }

        public static IEnumerable<int> NewRandomArray(int size)
        {
            Random r = new Random();
            return Enumerable.Range(0, size).Select(i => r.Next(size));
        }
    }
}
