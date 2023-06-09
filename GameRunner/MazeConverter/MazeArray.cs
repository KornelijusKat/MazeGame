

namespace GameRunner.MazeConverter
{
    public class MazeArray : IMazeArray
    {
        public int[][] ConvertToMazeArray(string maze)
        {
            string[] lines = maze.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[][] mazeArray = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                var row = new int[line.Length];
                for (int x = 0; x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case '1':
                            row[x] = -1;
                            break;
                        case 'X':
                            row[x] = 1;
                            break;
                        case ' ':
                            if (x == line.Length - 1)
                            {
                                row[x] = -2;
                                break;
                            }
                            else if (i == 0)
                            {
                                row[x] = -2;
                                break;
                            }
                            else if(x ==0)
                            {
                                row[x] = -2;
                                break;

                            }
                            else if (i == mazeArray.Length - 1)
                            {
                                row[x] = -2;
                                break;
                            }
                            else if (i == lines.Length)
                            {
                                row[x] = -2;
                                break;
                            }
                            break;
                        default:
                            row[x] = 0;
                            break;
                    }
                }
                mazeArray[i] = row;
            }
            return mazeArray;
        }
    }
}
