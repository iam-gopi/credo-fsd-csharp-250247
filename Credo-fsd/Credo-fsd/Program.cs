// extension method

class Program
{
    static void Main(string[] args)
    {
        StringExt.Add(1,2, 2,3,4);
    }
}

static class StringExt
{
    public static void Multiple(int m = 10)
    {
        Console.WriteLine(m * 10);
    }

    public static void Add(int a, int b, params int[] values)
    {
        int t = a + b;
        foreach (int v in values)
        {
            t += v;
        }   
        Console.WriteLine(t);
    }
}