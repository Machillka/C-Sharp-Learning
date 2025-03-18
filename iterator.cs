using System;


class DataStruct
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public DataStruct()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }
    public DataStruct(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
class Database
{
    public List<DataStruct> dataList = new List<DataStruct>();
    public int DataSize {get => dataList.Count;}

    public Database()
    {

    }

    public Database(int size)
    {
        for (int i = 1; i < size; i++)
        {
            dataList.Add(new DataStruct(i, i, i));
        }
    }

    public void PushData(DataStruct data)
    {
        dataList.Add(data);
    }

    public void PushData(double x, double y, double z)
    {
        dataList.Add(new DataStruct(x, y, z));
    }
}

class DataFunctions
{
    /// <summary>
    /// 从数据库中获取数据
    /// </summary>
    /// <param name="db">传入的数据库</param>
    /// <param name="size">返回的数据条数</param>
    /// <returns>打包数据成一个小Database</returns>
    public static IEnumerable<Database> GetData(Database db, int size)
    {
        for (int i = 0; i < db.DataSize; i += size)
        {
            Database temp = new Database();
            for (int j = i; j < i + size; j++)
            {
                if (j >= db.DataSize)
                    break;
                temp.PushData(db.dataList[j]);
            }
            yield return temp;
        }
    }
}

class IterTest
{
    /*
    * 实现一个迭代器加载数据集的效果
    * 每次使用迭代器的时候返回一个小的集合
    */
    public static IEnumerable<int> GetNumbers(int maxNumber)
    {
        for (int i = 2; i < maxNumber; i += 2)
        {
            if (i % 7 == 0)
                yield break;
            yield return i;
        }
    }

    static void Main()
    {
        foreach (var number in GetNumbers(100))
        {
            Console.WriteLine(number);
        }

        Database db = new Database(50);

        foreach (var datas in DataFunctions.GetData(db, 10))
        {
            Console.WriteLine("DataPop -> X:{0}, Y:{1}, Z:{2}", datas.dataList[0].X, datas.dataList[0].Y, datas.dataList[0].Z);
        }
    }
}