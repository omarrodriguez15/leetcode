using System;
using System.Collections.Generic;
using System.Text;

/*
Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.
*/
public class Solution 
{
   public void SetZeroes(int[][] matrix) 
   {
      Slowest(matrix);
   }

   private void Slowest(int[][] matrix)
   {
      var skipRows = new HashSet<int>();
      var skipColumns = new HashSet<int>();
      for (int i=0; i<matrix.Length; i++)
      {
         var row = matrix[i];
         for (int j=0; j<row.Length; j++)
         {
            if (row[j] == 0)
            {
               skipRows.Add(i);
               skipColumns.Add(j);
               continue;
            }
         }
      }

      foreach(var row in skipRows)
      {
         var orig = matrix[row];
         matrix[row] = new int[orig.Length];
      }

      for (int i=0; i<matrix.Length; i++)
      {
         var row = matrix[i];
         foreach(var columnNdx in skipColumns)
         {
            row[columnNdx] = 0;
         }
      }
   }
}