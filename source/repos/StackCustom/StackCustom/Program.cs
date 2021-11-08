using System;
using System.Collections;
using System.Collections.Generic;

namespace StackCustom
{
    /*class Node<T> 
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            Data = data;
        }
    }
    class Stack<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private int _count;
        public Stack()
        {
            _count = 0;
        }
        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head != null)
            {
                node.Next = _head;
            }

            _head = node;
        }

        public T Pop()
        {
            Node<T> node = _head;
            if (node != null)
            {
                _head = _head.Next;

                return node.Data;
            }

            return default(T);
        }

        public T Peek()
        {
            Node<T> node = _head;
            if (node != null)
                return node.Data;

            return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
    class Stack<T> : IEnumerable<T>
    {
        private T[] _data;
        public int Capacity { get; set; }
        private int _count;
        public Stack(int capacity)
        {
            Capacity = capacity;
            _count = 0;
        }

        public bool IsEmpty
        {
            get => this._count == 0;
        }

        public int Count
        {
            get => this._count;
        }

        public void Push(T data)
        {
            if (Capacity < _count + 1)
                throw new StackOverflowException();

            if (_data == null)
            {
                _data = new T[] { data };
            }
            else
            {
                T[] temp = new T[_data.Length + 1];
                for (int i = 0; i < _data.Length; i++)
                    temp[i] = _data[i];

                temp[_data.Length] = data;
                _data = temp;
            }

            _count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            T current = _data[_data.Length - 1];

            if (_data.Length > 1)
            {
                T[] temp = new T[_data.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                    temp[i] = _data[i];

                _data = temp;
            }
            else
                _data = null;

            _count--;

            return current;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            T current = _data[_data.Length - 1];
            return current;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
                yield return _data[i];
        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            /*Stack<int> stack = new Stack<int>();
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                stack.Push(rnd.Next(-100, 100));
            }

            foreach(int i in stack)
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < 9; i++)
                Console.WriteLine(stack.Pop());
            

            Stack<int> stack = new Stack<int>(10);
            Random rnd = new Random();
            for (int i = 0; i < stack.Capacity; i++)
                stack.Push(rnd.Next(-100, 100));

            stack.Push(0);

            foreach (int i in stack)
                Console.WriteLine(i);

            for (int i = 0; i < stack.Capacity; i++)
                Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Peek());
            */




        }
    }
}
