using DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Visitors
{
    public class PrefixVisitor<T> : IVisitor<T>
        where T : IComparable<T>
    {
        public void Visit(BinarySearchTree<T> node)
        {
            //Console.WriteLine(node.Value);
            //if (node.Left != null)
            //{
            //    node.Left.Accept(this);
            //}
            //if (node.Right != null)
            //{
            //    node.Right.Accept(this);
            //}
        }
    }
}
