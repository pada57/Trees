using Ardalis.GuardClauses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> root;
        private TreePrinter printer = new TreePrinter();
               
        public BinarySearchTree<T> Insert(T value)
        {
            Guard.Against.Null(value, nameof(value));

            if (root == null)
            {
                root = new Node<T>(value);
            }
            else
            {
                root.Insert(value);
            }

            return this;
        }    

        public bool Delete(T value)
        {
            Guard.Against.Null(value, nameof(value));

            return false;
        }


        public bool Contains(T value)
        {
            Guard.Against.Null(value, nameof(value));

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void PrintToConsole()
        {
            printer.Print<T>(root);
        }



        public void Accept(IVisitor<T> visitor)
        {
            visitor.Visit(this);
        }

    }
}
