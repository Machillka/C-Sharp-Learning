using System;
using System.Threading.Tasks;

class Material
{
    public string? Name { get; set; }
    // 单位 ms Time -> 烘培时间; Temperature -> 烘培温度
    public int Time { get; set; }
    public int Temperature { get; set; }

    public Material(string name, int time, int temperature)
    {
        Name = name;
        Time = time;
        Temperature = temperature;
    }
    public Material()
    {

    }
}

class Async
{
    static async Task AsyncMain(string[] args)
    {
        List<Material> materials = new List<Material>
        {
            new Material("potato", 2000, 100),
            new Material("egg", 1000, 100),
            new Material("tomato", 2000, 100),
            new Material("beef", 3000, 100),
            new Material("onion", 1000, 100),
        };

        /*
        * 可以理解为 await 是顺序执行每一个任务
        * 但是Task.WhenAll是并行执行多个任务
        */

        // 逐个执行每一个 Cook 方法, 总时间是所有 Cook 方法的时间之和

        // int index = 0;
        // foreach (var material in materials)
        // {
        //     await Cook(material);
        //     Console.WriteLine("This is {0}", index);
        //     index += 1;
        // }

        // await Cook(materials[0]);
        // await Cook(materials[1]);

        Task task1 = Task.Run(async () =>
        {
            Console.WriteLine("Waiting Player 1 for one second");
            await Task.Delay(1000);
            Console.WriteLine("Waited Player 1 for one second had done");
        });

        Task task2 = Task.Run(async () =>
        {
            Console.WriteLine("Waiting Player 2 for two seconds");
            await Task.Delay(2000);
            Console.WriteLine("Waited Player 2 for two seconds had done");
        });

        // 任务1和任务2 同时执行（并行）, 但是await会等待两个任务都执行完毕后才会执行后续代码
        await Task.WhenAll(task1, task2);
        // 等待 await 执行之后才会执行后续代码
        Console.WriteLine("I love Kayoko!");
    }

    static async Task Heat(Material material)
    {
        Console.WriteLine("Heating...");
        await Task.Delay(material.Temperature);
        Console.WriteLine("Heating done");
    }

    static async Task Cook(Material material)
    {
        Console.WriteLine("I'm cooking " + material.Name);
        await Heat(material);
        await Task.Delay(material.Time);
        Console.WriteLine(material.Name + " done");
    }
}