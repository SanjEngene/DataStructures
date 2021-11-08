using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCircularLinkedList
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            Data = data;
        }
    }
    class CircularLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;
        
        public CircularLinkedList()
        {
            this._head = null;
            this._tail = null;
            this._count = 0;
        }

        public void AppendToStart(T data)
        {
            Node<T> node = new Node<T>(data);

            if (_head == null)
                FirstAppend(node);
            else
            {
                node.Next = _head;
                _head = node;
                _tail.Next = node;
            }

            _count++;
        }

        public void AppendToEnd(T data)
        {
            Node<T> node = new Node<T>(data);

            if (_tail == null)
                FirstAppend(node);
            else
            {
                _tail.Next = node;
                _tail = node;
                _tail.Next = _head;
            }

            _count++;
        }

        private void FirstAppend(Node<T> node)
        {
            _head = node;
            _tail = node;
        }

        public void Remove()
        {
            if (_count == 0)
                throw new InvalidOperationException();

            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;

                if (_head == _tail)
                    _tail.Next = null;
                else
                    _tail.Next = _head;
            }

            _count--;
        }

        public bool Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;
            int counter = 0;
            while (counter != this._count)
            {
                if (current.Data.Equals(data))
                {
                    if (previous == null)
                    {
                        if (_count > 1)
                        {
                            _head = _head.Next;

                            if (current.Next == _tail)
                                _tail.Next = null;
                            else
                                _tail.Next = _head;
                        }
                        else
                        {
                            _head = null;
                            _tail = null;
                        }
                    }
                    else
                    {
                        if (current == _tail)
                        {
                            _tail = previous;

                            if (_count > 2)
                                previous.Next = _head;
                            else
                                previous.Next = null;
                        }
                        else
                            previous.Next = current.Next;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
                counter++;
            }

            return false;
        }

        public bool Insert(int index, T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> current = _head;
            Node<T> previous = null;
            int counter = 0;
            while (counter != this._count)
            {
                if (counter == index)
                {
                    node.Next = current;

                    if (previous == null)
                    {
                        _head = node;
                        _tail.Next = node;
                    }
                    else
                        previous.Next = node;

                    _count++;
                    return true;
                }

                previous = current;
                current = current.Next;
                counter++;
            }

            return false;
        }

        public bool Contains(T data)
        {
            Node<T> current = _head;
            int counter = 0;
            while (counter != _count)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
                counter++;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            int counter = 0;
            while (counter != _count)
            {
                yield return current.Data;

                current = current.Next;
                counter++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<int> circularLinkedList = new CircularLinkedList<int>();
            Random rnd = new Random();

            circularLinkedList.AppendToEnd(25);
            Console.WriteLine(circularLinkedList.Insert(0, 1));
            circularLinkedList.AppendToStart(39);

            Console.WriteLine(circularLinkedList.Remove(1));

            foreach (int i in circularLinkedList)
                Console.WriteLine(i);

        }
    }
}
