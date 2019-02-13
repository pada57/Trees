using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public interface INode<T>
    {
        T Value { get; }
        INode<T> Left { get; }
        INode<T> Right { get; }

        void Accept(IVisitor<T> visitor);
    }
}
