using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRunner.MazePathfinder
{
    public interface IMazeTraverse
    {
        void Traverse(int[][] arrayTemp, int rowIndex, int columnIndex, int count, ref int fewestSteps);
    }
}
