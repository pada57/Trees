using System;

namespace DataStructure
{
    internal class Node<T>
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

        public T Value { get; private set; }

        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public Node<T> Insert(T value)
        {
            return this.Insert(this, value);
        }

        private Node<T> Insert(Node<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                currentNode = new Node<T>(value);
            }
            else if (value.CompareTo(currentNode.Value) < 0)
            {
                currentNode.Left = Insert(currentNode.Left, value);
            }
            else
            {
                currentNode.Right = Insert(currentNode.Right, value);
            }

            return currentNode;
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


    }
}
