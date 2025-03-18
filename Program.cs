using System;
using System.Threading.Tasks;

namespace Test01
{
    class Person
    {
        public Person()
        {
            Idx = 0;
        }
        public Person(string? name, int age)
        {
            Name = name;
            Age = age;
            Idx = 0;
        }

        public string? Name{ get; set; }
        private int _age;
        public int Age
        {
            get {return _age;}
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be greater than 0");
                }
                _age = value;
            }
        }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get => Weight / (Height * Height); }
        public int Idx { get; private set; }

        private void FixIndex(int idx)
        {
            Idx = idx;
        }
    }

    class LoveFunction
    {
        public delegate void ShowLove();
        public static void FirstLove()
        {
            Console.WriteLine("My love is Kayoko");
        }
        public static void SecondLove()
        {
            Console.WriteLine("My love is also Kayoko");
        }
        public static void ThirdLove()
        {
            Console.WriteLine("My love is Kayoko, forever");
        }

        public void PrintLove()
        {
            // 多播委托
            ShowLove showLove = FirstLove;
            showLove += SecondLove;
            showLove += ThirdLove;
            showLove();
        }
    }

    public class Button
    {
        // EventHandler 本身是同步事件，所以即使使用了异步处理 依旧是同步执行
        public event EventHandler? Click;
        public event Func<Task>? ClickAsync;
        public void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        public async Task OnClickAsync()
        {
            if (ClickAsync != null)
            {
                foreach (Func<Task> handler in ClickAsync.GetInvocationList())
                {
                    Console.WriteLine("Before Click");
                    await handler.Invoke();
                    Console.WriteLine("After Click");
                }
            }
        }
    }

    public class GameCalculate
    {
        private static GameCalculate? _instance = new GameCalculate();
        public static GameCalculate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameCalculate();
                }
                return _instance;
            }
        }
        public async Task CalculateDamage()
        {
            Console.WriteLine("Calculating Damage......");
            await Task.Delay(5000);
            Console.WriteLine("Damage Calculated !");
        }
    }

    class Program
    {
        static async Task ProgramMain(string[] args)
        {
            Person smith = new Person();
            smith.Name = "Smith";
            smith.Age = 30;
            smith.Height = 1.7;
            smith.Weight = 59.8;
            Console.WriteLine("Hello {0}", smith.Name);
            Console.WriteLine("Your BMI is {0:F2}", smith.BMI);

            var MaxNum = (int a, int b) => a > b ? a : b;
            Console.WriteLine("MaxNum(3, 5) = {0}", MaxNum(3, 5));

            Func<int, int, int> MinNum = (a, b) => a < b ? a : b;
            Console.WriteLine("MinNum(3, 5) = {0}", MinNum(3, 5));

            LoveFunction lf = new LoveFunction();
            lf.PrintLove();

            Button space = new Button();
            space.Click += (sender, e) => {
                Console.WriteLine("Space Clicked");
            };
            space.Click += (sender, e) => {
                Console.WriteLine("Player Jump!");
            };
            space.OnClick();

            Button attack = new Button();
            // attack.Click += (sender, e) => {
            //     Console.WriteLine("Attack Clicked");
            // };
            attack.ClickAsync += async () => {
                Console.WriteLine("Player Attacking......");
                // await GameCalculate.Instance.CalculateDamage();
                await Task.Delay(2000);
                Console.WriteLine("Player Attack Finished!");
            };
            await attack.OnClickAsync();
            // var asyncTest = GameCalculate.Instance.CalculateDamage();
            // await asyncTest;

            Console.WriteLine("Game Over");
        }
    }
}