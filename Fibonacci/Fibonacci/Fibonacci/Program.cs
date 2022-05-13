using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fibonacci
{
  class Program
  {

    public static long RecursiveFibonacci(int n)
    {
    
      if (n <= 1)
        return n;
      else
        return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
    }

    static Dictionary<int, long> fibResults = new Dictionary<int, long>();
    
    public static long OptimizedRecursiveFibonacci(int n)
    {
      if (n <= 1)
        return n;

      if (fibResults.ContainsKey(n))
        return fibResults[n];

      long res = OptimizedRecursiveFibonacci(n - 1) + OptimizedRecursiveFibonacci(n - 2);
      fibResults[n] = res;
      return res;
    }

    static void Main(string[] args)
    {
      Random rand = new Random();
      while (true)
      {
        int n = rand.Next(1, 40);
        Console.WriteLine(string.Format("Compute Fibonacci of {0}", n));
        Stopwatch watch = new Stopwatch();
        watch.Start();
        long resultFibSlow = RecursiveFibonacci(n);
        Console.WriteLine(String.Format("Slow Fibonacci took {0}ms to compute", watch.ElapsedMilliseconds));
        Stopwatch watchFibFast = new Stopwatch();
        long resultFibFast = OptimizedRecursiveFibonacci(n);
        Console.WriteLine(String.Format("Fast Fibonacci took {0}ms to compute", watchFibFast.ElapsedMilliseconds));
        if (resultFibFast != resultFibSlow)
          Console.WriteLine("Error");
        else
          Console.WriteLine("Ok");

        fibResults = new Dictionary<int, long>();
      }
    }
  }
}
