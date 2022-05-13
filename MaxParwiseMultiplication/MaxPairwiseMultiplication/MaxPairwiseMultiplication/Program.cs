using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MaxPairwiseMultiplication
{
  class Program
  {

    public static long MaxPairwiseMultiplication(List<int> list)
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      long maxVal = 0;
      long secondMaxVal = 0;
  
      foreach(int val in list)
      {
        if (val > maxVal)
        {
          secondMaxVal = maxVal;
          maxVal = val;
        }else if (val > secondMaxVal)
        {
          secondMaxVal = val;
        }
      }
      Console.WriteLine(String.Format("Fast Max Pairwise took {0}ms", watch.Elapsed));
      return maxVal * secondMaxVal;
    }

    public static long SlowMaxPairwiseMultiplication(List<int> list )
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      long result = 0;

      for(int i = 0; i < list.Count; i++)
      {
        for(int j = i + 1; j < list.Count; j++)
        {
          if (list[i] * list[j] > result)
            result = list[i] * list[j];
        }
      }
      Console.WriteLine(String.Format("Slow Max Pairwise took {0}ms", watch.Elapsed));
      return result;
    }

    static void Main(string[] args)
    {

      Random rand = new Random();

      while (true)
      {
        List<int> parameter = new List<int>();
        int len = rand.Next(0, 10000);
        for (int i = 0; i < len; i++)
        {
          parameter.Add(rand.Next(0, 10000));
        }
        long resultSlow = SlowMaxPairwiseMultiplication(parameter);
        long resultFast = MaxPairwiseMultiplication(parameter);
        if (resultSlow != resultFast)
          Console.WriteLine("Wrong");
        else
          Console.WriteLine("Correct");
      } 
    }
  }
}
