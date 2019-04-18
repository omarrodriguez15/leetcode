using System;

public class DecodeWaysTests 
{
   public static void Run()
   {
      Console.WriteLine("Starting testing");
      AssertAndLog("226", 3);
      AssertAndLog("12", 2);
      AssertAndLog("1", 1);
      AssertAndLog("10", 1);
      AssertAndLog("26", 2);
      AssertAndLog("27", 1);
      AssertAndLog("00", 0);
      AssertAndLog("01", 0);
      AssertAndLog("9992699", 2);
      AssertAndLog("100", 0);
      AssertAndLog("101", 1);
      AssertAndLog("110", 1);
      AssertAndLog("230", 0);
      AssertAndLog("7206", 1);
      AssertAndLog("26", 2);
      AssertAndLog("1212", 5);
      AssertAndLog("47575625458", 2);
      AssertAndLog("47575625458228", 4);
      AssertAndLog("756254229169", 8);
      AssertAndLog("4757562545844617494555774581341211511296816786586787755257741178599337186486723247528324612117156948", 589824);
      Console.WriteLine("Done testing");
   }

   public static void AssertAndLog(string s, int expectation)
   {
      var solution = new DecodeWays();
      var output = solution.NumDecodings(s);
      if (output != expectation) 
      {
         Console.WriteLine($"{s} -> expected={expectation} output={output}");
      }
   }
}