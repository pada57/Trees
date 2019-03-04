using DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    internal class TreePrinter
    {
        class NodeInfo<T>
            where T : IComparable<T>
        {
            public Node<T> Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo<T> Parent, Left, Right;
        }

        internal void Print<T>(Node<T> root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
            where T : IComparable<T>
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo<T>>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo<T> { Node = next, Text = typeof(T) is int ? ((int)(object)(next.Value)).ToString(textFormat) : next.Value.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        #region Old version

        //public static void PrettyPrint<T>(INode<T> node, int padding = 4)
        //    where T : IComparable<T>
        //{
        //    if (node != null)
        //    {
        //        if (node.Right != null)
        //        {
        //            PrettyPrint(node.Right, padding + 4);
        //        }
        //        if (padding > 0)
        //        {
        //            Console.Write(" ".PadLeft(padding));
        //        }
        //        if (node.Right != null)
        //        {
        //            Console.Write("/\n");
        //            Console.Write(" ".PadLeft(padding));
        //        }
        //        Console.Write(node.Value.ToString() + "\n ");
        //        if (node.Left != null)
        //        {
        //            Console.Write(" ".PadLeft(padding) + "\\\n");
        //            PrettyPrint(node.Left, padding + 4);
        //        }
        //    }
        //}

        #endregion
    }
}
