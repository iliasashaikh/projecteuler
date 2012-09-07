using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  public static class MathHelper
  {
    public static bool IsPrime(this double i)
    {
      IEnumerable<double> l = null;
      
      // test for composite
      // composite if input is divisible by any number other than itself and 1
      // 1 is composite
      var r = l.Range(1, Math.Floor(Math.Sqrt(i)))
               .Any(x => (i % x == 0 && i != x && x > 1) || i == 1);
      return !r;
    }

    public static bool IsPrime(this int i)
    {
      return ((double)i).IsPrime();
    }

    public static IEnumerable<double> Range(this IEnumerable<double> l, double start, double count)
    {
      for (double i = start; i < start + count; i++)
      {
        yield return i;
      }
    }

    public static IEnumerable<double> RangeTillStop(this IEnumerable<double> l, double start, Func<bool> stop)
    {
      while (!stop())
      {
        yield return start++;
      }
    }

    public static IEnumerable<double> RangeDown(this IEnumerable<double> l, double start, double count)
    {
      double s = start;
      for (double i = 0; i < count; i++)
      {
        yield return start--;
      }
    }

    public static IEnumerable<int> RangeDown(this IEnumerable<int> l, int start, int count)
    {
      int s = start;
      for (int i = 0; i < count; i++)
      {
        yield return start--;
      }
    }

    public static int[] ToIntArray(this string s, char separator)
    {
      s.Split(new char[] { separator });
      var l = s.Select(c => Int32.Parse(c.ToString())).ToArray();
      return l;
    }

    /// <summary>
    /// Convert a 2d string into an array of ints
    /// </summary>
    public static int[,] To2dArray(string input, string lineSeparator, string colSeparator)
    {
      //e.g. string s = @"1 2
      //                  3 4"
      // to a corres int[,]
      int[,] a = null;
      input = input.Trim();
      var rows = input.Split(new string[] { lineSeparator }, StringSplitOptions.RemoveEmptyEntries);
      for (int i = 0; i < rows.Length; i++)
      {
        var row = rows[i];
        var cols = row.Split(new string[] { colSeparator }, StringSplitOptions.RemoveEmptyEntries);
        for (int j = 0; j < cols.Length; j++)
        {
          if (a == null)
          {
            a = new int[rows.Length, cols.Length];
          }
          if (a.GetUpperBound(1) < cols.Length)
          {
            var newA = new int[rows.Length, cols.Length];
            Array.Copy(a, newA, a.Length);
            a = newA;
          }
          int.TryParse(cols[j], out a[i, j]);
        }
      }

      return a;
    }
  }
}
