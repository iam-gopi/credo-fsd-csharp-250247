using System.Collections.Concurrent;

namespace Credo_fsd;

public class ThreadExample
{
    static object threadLock = new object();
    
    public static void Main(string[] args)
    {
        ThreadExample pobj = null;

        lock (threadLock)
        {
            if (pobj == null)
            {
                pobj = new ThreadExample();
            }
        }

        Console.WriteLine(pobj);

        // Thread a = new Thread(Test);
        // a.Start();
        // a.Join(); // waiting fr the main thread to complete its execution


        // if (a.IsAlive)
        // {
        //     Console.WriteLine("completed");
        // }


        // unstarted, running, sleep, abort, suspend, background, stopped 
        // Thread a = new Thread(Test);
        // Thread a1 = new Thread(() => Test1(3));
        // a.Start();
        // a1.Start();
        // // Console.WriteLine(a.ThreadState);
        // // Console.WriteLine(a.IsThreadPoolThread);
        // // Console.WriteLine(a.IsBackground);
        // // Console.WriteLine(a.ManagedThreadId);
        // Console.WriteLine("completed");
    }

    static void Test()
    {
        Console.WriteLine("Welcome to thread");
        Console.WriteLine("waiting...");
        Thread.Sleep(5000);
    }

    // static void Test1(int p)
    // {
    //     for (int i = 0; i < p; i++)
    //     {
    //         Console.WriteLine(i);
    //         // Thread.Sleep(3000);
    //     }
    //
    //     Console.WriteLine("test 1 completed");
    // }
}