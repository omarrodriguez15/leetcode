using System;
using System.Text;

public class SetMatrixZeroTests 
{
   public static void Run()
   {
      Console.WriteLine("Starting SetMatrixZero testing");

      AssertAndLog(
         "test 1 ", 
         BuildMatrix("[[1,1,1],[1,0,1],[1,1,1]]"), 
         BuildMatrix("[[1,0,1],[0,0,0],[1,0,1]]"));

      AssertAndLog(
         "test 2 ", 
         BuildMatrix("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]"), 
         BuildMatrix("[[0,0,0,0],[0,4,5,0],[0,3,1,0]]"));

      Console.WriteLine("Done SetMatrixZero testing");
   }

   private static int[][] BuildMatrix(string s)
   {
      var rows = s.TrimStart('[').Split('[');
      var matrix = new int[rows.Length][];

      for (int i=0;i<rows.Length;i++)
      {
         var cols = rows[i].TrimEnd(']',',').Split(',');
         matrix[i] = new int[cols.Length];

         for (int j=0;j<cols.Length;j++)
         {
            matrix[i][j] = int.Parse(cols[j]);
         }
      }
      return matrix;
   }

   private static void AssertAndLog(string msg, int[][] input, int[][] expectation)
   {
      var b4 = input.Stringify();

      var solution = new Solution();
      solution.SetZeroes(input);
      
      var after = input.Stringify();
      
      if (after != expectation.Stringify()) 
      {
         Console.WriteLine("Before: ");
         Console.WriteLine(b4);
         Console.WriteLine("After: ");
         Console.WriteLine(after);

         Console.WriteLine($"{msg} failed expected: ");
         expectation.PrettyPrint();
      }
   }
}

public static class MatrixExt 
{
   public static void PrettyPrint(this int[][] matrix)
   {
      Console.WriteLine(matrix.Stringify());
   }
   public static string Stringify(this int[][] matrix)
   {
      var sb = new StringBuilder();
      for (int i=0; i<matrix.Length; i++)
      {
         var row = matrix[i];
         for (int j=0; j<row.Length; j++)
         {
            var element = row[j];
            sb.Append($"{element}");
         }
         sb.AppendLine();
      }
      var pretty = sb.ToString();
      return pretty;
   }
}