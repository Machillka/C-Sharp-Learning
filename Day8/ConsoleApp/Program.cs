using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    class ProgramDay8
    {
        static void Main()
        {
            Console.WriteLine("Running!");

            var so1ve = new Person();

            Icontrol icontrol = so1ve;
            Isurface isurface = so1ve;

            icontrol.Print();
            isurface.Print();
            icontrol.Test();

            Icontrol testFoo = new Person() as Icontrol;
            testFoo.Print();
            testFoo.Test();
        }
    }

    interface Icontrol
    {
        void Print();
        void Test() => Console.WriteLine("Icontrol Test");
    }

    interface Isurface
    {
        void Print();
    }

    class Person : Icontrol, Isurface
    {
        public Person()
        {
            Console.WriteLine("Person Start");
        }

        ~Person()
        {
            Console.WriteLine("Person deleted");
        }

        //
        private string _name;
        private int _age;
        
        //
        public string _Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public int _Age
        {
            get { return _age; }
            set { _age = value; }
        }

        // 显式接口实现
        void Icontrol.Print()
        {
            Console.WriteLine("Person, IControl");
        }

        void Isurface.Print()
        {
            Console.WriteLine("Person, Isurface");
        }

        void Icontrol.Test()
        {
            Console.WriteLine("OverRider the Icontrol.Test()");
        }
    }
}

namespace AttTest
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class AuthorAttribute : System.Attribute
    {
        private string? _name;
        private double? _version;
    
        public AuthorAttribute(string? name, double version)
        {
            _name = name;
            _version = version;
        }
    }

    [Author("Machillka", 1.1)]
    class Person
    { }

}