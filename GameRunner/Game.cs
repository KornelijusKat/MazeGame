using GameRunner.MazeConverter;
using GameRunner.MazePathfinder;
namespace GameRunner
{
    public class Game : IGame
    {
        public int Run(string filePath)
        {
            IMazeArray _maze = new MazeArray();
            try
            {
                string text = File.ReadAllText(filePath);
                var array = _maze.ConvertToMazeArray(text);
                return MazeSolver(array);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        internal int MazeSolver(int[][] mazeArray)
        { 
            IMazeTraverse _traverse = new MazeTraverse();
            for (int i = 0; i < mazeArray.Length; i++)
            {
                var row = mazeArray[i];
                for (int x = 0; x < row.Length; x++)
                {
                    if (row[x] == 1)
                    {
                        int fewestSteps = 0;
                        _traverse.Traverse(mazeArray, i, x, 0, ref fewestSteps);
                        return fewestSteps;
                    }
                }
            }
            return 0;
        }
    }
}
