using GameRunner.MazeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRunner.MazePathfinder
{
    public class MazeTraverse :IMazeTraverse
    {
       public void Traverse(int[][] mazeArray, int rowIndex, int columnIndex, int count, ref int fewestSteps)
        {
            int[][] possibleMoves = {
              new int[] { -1, 0 },
              new int[] { 0, -1 },
              new int[] { 0, 1 },
              new int[] { 1, 0 } };
            var tempMaze = MakeCopyTempArray(mazeArray);
            int value = tempMaze[rowIndex][columnIndex];
            if (value >= 1)
            {
                foreach (var movePair in possibleMoves)
                {
                    int newRow = rowIndex + movePair[0];
                    int newColumn = columnIndex + movePair[1];
                    if (IsValidPosition(tempMaze, rowIndex, newRow, newColumn))
                    {
                        int testPosition = tempMaze[newRow][newColumn];
                        if (testPosition == 0)
                        {
                            tempMaze[newRow][newColumn] = value + 1;
                            Traverse(tempMaze, newRow, newColumn, count + 1, ref fewestSteps);
                        }
                        else if (testPosition == -2)
                        {
                            if (fewestSteps == 0)
                            {
                                fewestSteps = int.MaxValue;
                            }
                            if (count + 1 < fewestSteps)
                            {
                                fewestSteps = count + 1;
                            }
                        }
                    }
                   
                }             
            }
           
        }
        private bool IsValidPosition(int[][] array, int row, int newRow, int newColumn)
        {
            if (newRow < 0)
            {
                return false;

            }
            else if (newRow >= array.Length)
            {
                return false;
            }
            else if (newColumn < 0)
            {
                return false;
            }
         
            else if (newColumn >= array[row].Length)
            {
                return false;
            }
            return true;
        }
        private int[][] MakeCopyTempArray(int[][] mazeArray)
        {
            int[][] array = new int[mazeArray.Length][];
            for (int i = 0; i < mazeArray.Length; i++)
            {
                var row = mazeArray[i];
                array[i] = new int[row.Length];
                for (int x = 0; x < row.Length; x++)
                {
                    array[i][x] = row[x];
                }
            }
            return array;
        }
    }
}
