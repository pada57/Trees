using DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Visitors
{
    public class PrefixVisitor<T> : IVisitor<T>
    {
        public void Visit(INode<T> node)
        {
            Console.WriteLine(node.Value);
            if (node.Left != null)
            {
                node.Left.Accept(this);
            }
            if (node.Right != null)
            {
                node.Right.Accept(this);
            }
        }
    }
}
