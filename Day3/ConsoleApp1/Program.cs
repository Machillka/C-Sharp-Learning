//#define ROOPTEST
//#define WKN
#define Animal
using System;

namespace Day3
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Running");

#if ROOPTEST
            Program instance = new Program();
            instance.RoopTest();
#endif
#if WKN
            Person wkn = new Person();
            wkn._Name = "so1ve";
            wkn._Age = null;
            Console.WriteLine("name: " + wkn._Name);
            Console.WriteLine("age : {0}", wkn._Age);
#endif
#if Animal
            var dog = new Dog();
            dog._Age = 1;
            dog.PrintAtt();
            dog.PrintAge();

            Console.WriteLine();

            Cat cat = new Cat();
            cat._Age = 2;
            cat.PrintAtt();
            cat.PrintAge();
#endif
            Console.ReadKey();
        }

        public void RoopTest()
        {
            int[] a = { 1, 2, 3, 4, 5, };

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
        }
    }

    class Person
    {
        public Person() => Console.WriteLine("Person");
        ~Person() => Console.WriteLine("~Person");


        private string? _name;
        public string? _Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;
        public int? _Age
        {
            get { return _age; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("age can't be null");
                    _age = 0;
                }
                else
                {
                    _age = (int)value;
                }
            }
        }
    }

    // 定义抽象类
    abstract class Animal
    {
        abstract public void PrintAtt();
        public void PrintAge() => Console.WriteLine($"My age is :{_Age}");

        public int _Age { get; set; }
    }


    class Dog : Animal
    {
        public override void PrintAtt()
        {
            Console.WriteLine("dog desi");
        }
    }

    class Cat : Animal
    {
        public override void PrintAtt()
        {
            Console.WriteLine("cat desi");
        }
    }
}