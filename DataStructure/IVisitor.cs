using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public interface IVisitor<T>
        where T : IComparable<T>
    {
        void Visit(INode<T> node);
    }
}
