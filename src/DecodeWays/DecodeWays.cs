using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

public class DecodeWays {
   private static Dictionary<string, int> _cache = new Dictionary<string, int>();

   public int NumDecodings(string s) 
   {
      return NumDecodings(StringToInts(s));
   }

   private List<int> StringToInts(string s)
   {
      var ints = new List<int>();
      var last = 0;
      for(int i=0;i<s.Length;i++)
      {
         var curr = int.Parse(s[i].ToString());
         if (curr == 0 && (last <= 0 || last > 2 )) return new List<int>();
         last = curr;
         ints.Add(curr);
      }

      if (ints.Count > 0)
      {
         var first = ints[0];
         if (first < 1 || first > 26) ints.Clear();
      }
      return ints;
   }

   private string ConvertToKey(List<int> ints)
   {
      var sb = new StringBuilder();
      foreach(var i in ints) sb.Append(i);
      return sb.ToString();
   }
      
   private int NumDecodings(List<int> ints, int num = 1) 
   {
      var intsCount = ints.Count;
      if (intsCount < 1) return 0;

      var cacheKey = ConvertToKey(ints);
      if (_cache.ContainsKey(cacheKey)) 
      {
         return _cache[cacheKey] + num;
      }
      var numOfDecodings = num;
      for(int i=0;i<intsCount;i++)
      {
         var curr = ints[i];
         var nextNdx = i + 1;

         if (curr < 1 || curr > 26) continue;

         var hasNext = nextNdx < intsCount;
         if (!hasNext) continue;

         var next = ints[nextNdx];
         var pivotPoint = next != 0 && (curr == 1 || (curr == 2 && next <= 6));
         var nextNextNdx = nextNdx + 1;
         var possibleMorePivots = nextNextNdx < intsCount;

         if (possibleMorePivots && ints[nextNextNdx] == 0) pivotPoint = false;

         if (pivotPoint && possibleMorePivots)
         {
            var endNdx = intsCount - nextNdx;
            num++;
            num = Math.Max(num, NumDecodings(ints.GetRange(nextNdx, endNdx), num));
            i++;
         }
         else if (pivotPoint && next > 0)
         {
            num++;
         }
      }
      var change = num - numOfDecodings;
      if (change > 0) _cache[cacheKey] = change;
      return num;
   }
}