using System;
using System.Numerics;

namespace ConsoleApp
{
    class Day6
    {
        static void Main()
        {
            var s = new _Stack< int >(5);

            s._Push(3);
            Console.WriteLine($"top: {s._GetTop()} length:{s._Length()}");

            for ( int i = 0; i < 5;  i++ )
            {
                s._Push(i);
            }
            
            Console.WriteLine($"top: {s._GetTop()} length:{s._Length()}");


            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                    Console.WriteLine($"top: {s._GetTop()} length:{s._Length()}");

                s._Pop();
            }

            Console.WriteLine(s._Head);

            Console.ReadKey();
        }

        public class _Stack<T>
        {
            public _Stack(int id)
            {
                Console.WriteLine($"Id: {id}   构造函数");
             
                this._head = 0;
                this._id = id;

                if (this._stack == null)
                {
                    this._stack = new List<T>();
                }
            }

            ~_Stack() => Console.WriteLine($"Id: {this._id}   构造函数");

            public void _Push(T value)
            {
                this._stack.Add(value);
                this._head += 1;
            }

            public T _GetTop()
            {
                return this._stack[this._head - 1];
            }

            public void _Pop()
            {
                if (this._head <= 0)
                {
                    Console.WriteLine("Error for the empty stack!");
                    return;
                }
                this._stack.RemoveAt(this._head - 1);
                _head -= 1;
            }

            public int _Length()
            {
                return this._head;
            }

            private int _head;
            public int _Head
            {
                get => _head;               
            }

            private int _id;

            private List<T> _stack;
        }
    }
}
