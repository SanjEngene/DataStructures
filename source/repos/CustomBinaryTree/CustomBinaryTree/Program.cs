using System;
using System.Diagnostics.CodeAnalysis;

namespace CustomBinaryTree
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public int Id { get; set; }

        public Node(int id, T data)
        {
            Id = id;
            Data = data;
        }
    }
    class BinaryTree<T>
    {
        private Node<T> _head;
        private int _count;
        public BinaryTree()
        {
            _head = null;
            _count = 0;
        }

        public Node<T> Head => _head;

        public void Add(int id, T data)
        {
            Node<T> node = new Node<T>(id, data);
            Node<T> current = _head;

            if (_head == null)
                _head = node;
            else
            {
                while (true)
                {
                    if (node.Id > current.Id)
                    {
                        if (current.Right != null)
                            current = current.Right;
                        else
                        {
                            current.Right = node;
                            _count++;
                            break;
                        }
                    }
                    else if(node.Id < current.Id)
                    {
                        if (current.Left != null)
                            current = current.Left;
                        else
                        {
                            current.Left = node;
                            _count++;
                            break;
                        }
                    }
                    
                }
            }   
        }

        enum BinaryTreeSide
        {
            None = 0,
            Left,
            Right
        }
        
        public bool Remove(int index)
        {
            Node<T> previous = null;
            Node<T> current = _head;
            BinaryTreeSide side = BinaryTreeSide.None;
            while (current != null)
            {
                if (index == current.Id)
                {
                    if (side == BinaryTreeSide.None)
                    {
                        if (current.Right != null && current.Left != null)
                        {
                            Node<T> next = current.Right;
                            while (next.Left != null)
                                next = next.Left;

                            next.Left = current.Left;
                            this._head = current.Right;
                        }
                        else if (current.Right != null && current.Left == null)
                            this._head = current.Right;
                        else if (current.Right == null && current.Left != null)
                            this._head = current.Left;
                        else if (current.Right == null && current.Left == null)
                            this._head = null;
                    }
                    else if (side == BinaryTreeSide.Left)
                    {
                        if (current.Right != null && current.Left != null)
                        {
                            Node<T> next = current.Right;
                            while (next.Left != null)
                                next = next.Left;

                            next.Left = current.Left;
                            previous.Left = current.Right;
                        }
                        else if (current.Left == null && current.Right != null)
                            previous.Left = current.Right;
                        else if (current.Left != null && current.Right == null)
                            previous.Left = current.Left;
                        else if (current.Left == null && current.Right == null)
                            previous.Left = null;
                    }
                    else if (side == BinaryTreeSide.Right)
                    {
                        if (current.Right != null && current.Left != null)
                        {
                            Node<T> next = current.Left;
                            while (next.Right != null)
                                next = next.Right;

                            next.Right = current.Right;
                            previous.Right = current.Left;
                        }
                        else if (current.Right != null && current.Left == null)
                            previous.Right = current.Right;
                        else if (current.Right == null && current.Left != null)
                            previous.Right = current.Left;
                        else if (current.Left == null && current.Right == null)
                            previous.Right = null;
                    }

                    _count--;
                    return true;
                }
                else if (index > current.Id)
                {
          
                    side = BinaryTreeSide.Right;
                        
                    previous = current;
                    current = current.Right;
                }
                else if (index < current.Id)
                {
                    side = BinaryTreeSide.Left;

                    previous = current;
                    current = current.Left;
                }

            }

            return false;
        }

        public static void BinaryTreeIteration(Node<T> current)
        {
            Console.WriteLine(current.Id);
            if (current.Right != null) 
                BinaryTreeIteration(current.Right);
            if (current.Left != null)
                BinaryTreeIteration(current.Left);
        }

        public static void InvertingBinaryTree(Node<T> current)
        {
            Node<T> temp = current.Left;
            current.Left = current.Right;
            current.Right = temp;

            if (current.Right != null)
                InvertingBinaryTree(current.Right);
            if (current.Left != null)
                InvertingBinaryTree(current.Left);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            int[] indexes = { 11, 33, 1, 9, 7, 15, 16, 24 };
            for (int i = 0; i < indexes.Length; i++)
                binaryTree.Add(indexes[i], i);


            BinaryTree<int>.BinaryTreeIteration(binaryTree.Head);
            binaryTree.Remove(15);
            binaryTree.Remove(11);
            BinaryTree<int>.BinaryTreeIteration(binaryTree.Head);
            BinaryTree<int>.InvertingBinaryTree(binaryTree.Head);
            BinaryTree<int>.BinaryTreeIteration(binaryTree.Head);
        }
    }
}
