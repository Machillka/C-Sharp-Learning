// Delegate

// create a delegate inorder to imitate the click button
delegate void Clicked();
// 含参委托
delegate int SingleNumberTranser(int value);

namespace ConsoleApp
{
    class Day7
    {
        // 创建泛型委托
        public delegate void Print<T>(T value);


        static Clicked? clickBtn;
        static SingleNumberTranser? snt;
        static Print<int>? pt;

        static void Main()
        {
            Console.WriteLine("Running!");

            // 类似函数指针的添加
            clickBtn += PrintHelloWorld;
            // 实例化添加方式
            clickBtn += new Clicked(PrintClick);
            // 无参 匿名函数
            clickBtn += delegate { Console.WriteLine("Lambda"); };

            // 按照添加委托的顺序执行
            clickBtn();

            snt += Plus;
            snt += Mult;
            // 含参匿名函数, 使用弃元
            snt += delegate (int _) { return 1145; };
            // 表达式 lambda, 相当于 input a l, then return l + 4
            snt += l => l + 4;

            // 返回值默认最后一个函数的返回值
            Console.WriteLine(snt(5));

            pt += PrintInt0;
            pt += PrintInt1;

            pt(4);
        }

        static void PrintClick()
        {
            Console.WriteLine("PrintClick!");
        }

        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello world!");
        }

        static int Plus(int value)
        {
            return value + 7;
        }

        static int Mult(int value)
        {
            return value * 3;
        }

        static void PrintInt0(int value)
        {
            Console.WriteLine(value);
        }

        static void PrintInt1(int value)
        {
            Console.WriteLine(value + 1);
        }
    }
}