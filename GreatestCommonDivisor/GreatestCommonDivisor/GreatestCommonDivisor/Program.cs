using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
  class Program
  {

    public static int SlowGreatestCommonDivisor(int a, int b)
    {
      int best = 0;

      for(int i = 1; i < a + b; i++)
      {
        if (a % i == 0 && b % i == 0)
          best = i;
      }
      return best;
    }

    public static int FastGreatestCommonDivisor(int a, int b)
    {
      if (b == 0)
        return a;

      int remainder = a % b;
      return FastGreatestCommonDivisor(b, remainder);
    }

    static void Main(string[] args)
    {
      Random rand = new Random();
      while (true)
      {

        int a = rand.Next(0, 1000000000);
        int b = rand.Next(0, 1000000000);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        int resSlow = SlowGreatestCommonDivisor(a, b);
        Console.WriteLine(String.Format("Slow algorithm took {0}ms to compute", watch.ElapsedMilliseconds));
        Stopwatch watchFast = new Stopwatch();
        watchFast.Start();
        int resFast = FastGreatestCommonDivisor(a, b);
        Console.WriteLine(String.Format("Fast algorithm took {0}ms to compute", watchFast.ElapsedMilliseconds));

        if (resSlow != resFast)
          Console.WriteLine("Error");
        else
          Console.WriteLine("Ok");
      }
    }
  }
}
