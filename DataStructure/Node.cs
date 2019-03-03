using System;

namespace DataStructure
{
    public class Node<T> : INode<T>
        where T : IComparable<T>
    {
        public Node(T value, Node<T> left = null, Node<T> right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public Node(T[] values, int index = 0)
        {
            Load(this, values, index);
        }


        void Load(Node<T> tree, T[] values, int index)
        {
            this.Value = values[index];
            if (index * 2 + 1 < values.Length)
            {
                Left = new Node<T>(values, index * 2 + 1);
            }
            if (index * 2 + 2 < values.Length)
            {
                Right = new Node<T>(values, index * 2 + 2);
            }
        }

        public T Value { get; private set; }
        public INode<T> Left { get; private set; }
        public INode<T> Right { get; private set; }

        public void Accept(IVisitor<T> visitor)
        {
            visitor.Visit(this);
        }
    }
}
