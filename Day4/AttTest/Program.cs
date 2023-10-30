using System;

namespace AttTest
{
     class AttTestProgram
    {

        static async Task Main()
        {
            Console.WriteLine("Start");

            // 已经开始运行 TestDelay, 并且得到返回
            Task<int> getRes1 = TestDelay(1, 7);
            Console.WriteLine("GetRes1 Started");
            Task<int> getRes2 = TestDelay(2, 5);
            Console.WriteLine("GetRes2 Started");

            Console.WriteLine("Do some other things Here");

            // 读取TestDelay 的返回值 或 调用result 的时候 此时需要异步进程结束之后才能继续执行 执行中间事件的时候异步正在运行
            int res1 = await getRes1;
            int res2 = await getRes2;
            //int res1 = 0, res2 = 0;
            //int res1 = getRes1.Result;
            //int res2 = getRes2.Result; 调用 result 不需要主方法为异步方法 (用 async 修饰)

            Console.WriteLine("Do some other things Here");

            // 调用 result 的时候也会
            Console.WriteLine($"res1 = {res1}, GetRes = {getRes1.Result}");
            Console.WriteLine($"res2 = {res2}, GetRes = {getRes2.Result}");
        }

        async static Task< int > TestDelay(int idx, int res)
        {
            Console.WriteLine($"Delay:{res} Start!");
            // 运行到 await 的时候进入后台运行, 返回调用处继续运行
            //await Task.Delay(res);

            for (int i = 0; i < res; i += 1)
            {
                Console.WriteLine($"idx = {idx}, second = {i}");
                await Task.Delay(1);
            }

            Console.WriteLine($"Delay:{res} end!");

            return res;
        }
    }
}