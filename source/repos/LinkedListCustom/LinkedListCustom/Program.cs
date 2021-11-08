using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListCustom
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T Data)
        {
            this.Data = Data;
        }
    }
    class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;
        private bool _isChecked;
        public LinkedList()
        {
            _count = 0;
            _isChecked = false;
        }

        public void Append(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head == null)
                _head = node;
            else
                _tail.Next = node;
           _tail = node;

            _count++;
        }

        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = _head;
            _head = node;
            if (_count == 0)
                _tail = _head;

            _count++;
        }

        public bool Remove()
        {
            if (_head == null)
                return false;

            else if (_head == _tail && _head != null)
            {
                _head = null;
                _tail = null;   
            }
            else
                _head = _head.Next;

            _count--;
            return true;
        }
        
        public bool Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;
            if (current != null)
            {
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                                _tail = previous;
                        }
                        else
                        {
                            _head = _head.Next;

                            if (_head == null)
                                _tail = null;
                        }
                        _count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
            }

            return false;
        } 

        public bool Insert(int index, T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;
            Node<T> node = new Node<T>(data);

            int counter = 0;
            while (current != null)
            {
                if (counter == index)
                {
                    if (previous != null)
                        previous = node;
                    else
                        _head = node;

                    node.Next = current;

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
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = null;
            if (!_isChecked)
            {
                current = _head;
                _isChecked = true;
            }
            else
            {
                current = _tail; 
            }
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Reverse()
        {
            if (_count > 1)
            {
                Node<T> previous = _head;
                Node<T> current = _head.Next;
                Node<T> next = current.Next;
                previous.Next = null;
                while (true)
                {
                    current.Next = previous;
                    if (next != null)
                    {
                        previous = current;
                        current = next;
                        next = next.Next;
                    }
                    else
                        break;
                }
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            Random rnd = new Random();
            list.AppendFirst(0);
            for (int i = 0; i < 9; i++)
                list.Append(rnd.Next(-100, 100));

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

            list.Reverse();
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
