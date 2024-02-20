using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void FirstThread(string filename)
    {
        string data = File.ReadAllText(filename);
        Console.WriteLine("Data from file '" + filename + "': " + data);
    }

    static void SecondThread(int n, ref int result)
    {
        result = CalculateFactorial(n);
    }

    static int CalculateFactorial(int n)
    {
        int result = 1;
        for (int i = 2; i <= n; ++i)
        {
            result *= i;
        }
        return result;
    }

    static void ThirdThread(string message, int durationInSeconds)
    {
        for (int i = 1; i <= durationInSeconds; ++i)
        {
            Console.WriteLine(message + " - " + i);
            Thread.Sleep(1000);
        }
    }

    static async Task FirstAsync(string filename)
    {
        string data = await File.ReadAllTextAsync(filename);
        Console.WriteLine("Data from file '" + filename + "': " + data);
    }

    static async Task<int> SecondAsync(int n)
    {
        return await Task.Run(() => CalculateFactorial(n));
    }

    static async Task ThirdAsync(string message, int durationInSeconds)
    {
        for (int i = 1; i <= durationInSeconds; ++i)
        {
            Console.WriteLine(message + " - " + i);
            await Task.Delay(1000);
        }
    }

    static async Task Main()
    {
        Console.WriteLine("Start of first Thread\n");
        Thread thread1 = new Thread(() => FirstThread("Lorem.txt"));
        thread1.Start();
        thread1.Join();
        Console.WriteLine("\nEnd of first Thread\n");

        Console.WriteLine("Start of second Thread\n");
        int result = 1;
        Thread thread2 = new Thread(() => SecondThread(10, ref result));
        thread2.Start();
        thread2.Join();
        Console.WriteLine("Factorial of 10 = " + result);
        Console.WriteLine("\nEnd of second Thread\n");

        Console.WriteLine("Start of third Thread\n");
        Thread thread3 = new Thread(() => ThirdThread("This message will repeat -", 5));
        thread3.Start();
        thread3.Join();
        Console.WriteLine("\nEnd of third Thread\n");

        Console.WriteLine("Start of first Async\n");
        await FirstAsync("Lorem.txt");

        int resultAsync = await SecondAsync(10);
        Console.WriteLine("Second Async result = " + resultAsync);

        await ThirdAsync("This message will repeat async - ", 5);
    }
}
