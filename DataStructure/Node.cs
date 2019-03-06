using System;
using System.Collections.Generic;

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

        public IEnumerable<T> TraverseInOrder()
        {
            IList<T> nodes = new List<T>();
            

            var stack = new Stack<Node<T>>();
            stack.Push(this);

            var visited = new HashSet<Node<T>>();

            while (stack.Count > 0)
            {
                // peek first, if need, continue to push left child to the stack
                var current = stack.Peek();
                var left = current.Left;

                // push left to the end because it is downwarding process
                while (left != null && !visited.Contains(left))
                {
                    stack.Push(left);
                    left = left.Left;
                }

                var visit = stack.Pop();

                nodes.Add(visit.Value);

                visited.Add(visit);

                if (visit.Right != null)
                {
                    stack.Push(visit.Right);
                }
            }

            return nodes;
        }

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
        

        public Node<T> Delete(Node<T> currentNode, T value)
        {
            if (currentNode == null) return currentNode;

            /* Otherwise, recur down the tree */
            if (value.CompareTo( currentNode.Value) < 0)
                currentNode.Left = Delete(currentNode.Left, value);
            else if (value.CompareTo( currentNode.Value) > 0)
                currentNode.Right = Delete(currentNode.Right, value);

            // if key is same as root's key, then This is the node  
            // to be deleted  
            else
            {
                // node with only one child or no child  
                if (currentNode.Left == null)
                    return currentNode.Right;
                else if (currentNode.Right == null)
                    return currentNode.Left;

                // node with two children: Get the 
                // inorder successor (smallest  
                // in the right subtree)  
                currentNode.Value = MinValue(currentNode.Right);

                // Delete the inorder successor  
                currentNode.Right = Delete(currentNode.Right, currentNode.Value);
            }
            return currentNode;
        }

        public T MinValue(Node<T> root)
        {
            T minv = root.Value;
            while (root.Left != null)
            {
                minv = root.Left.Value;
                root = root.Left;
            }
            return minv;
        }

        public bool Contains(T value)
        {
            if (value.CompareTo(Value) == 0)
                return true;

            if (value.CompareTo(Value) < 0 && Left != null)
                return Left.Contains(value);

            return Right != null && Right.Contains(value);
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
