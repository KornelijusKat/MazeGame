using GameRunner.MazeConverter;
using GameRunner.MazePathfinder;

namespace GameRunner.UnitTests
{
    public class UnitTests
    {
        public IGame game = new Game();
        public IMazeArray mazeArray = new MazeArray();
        [Fact]
        public void CheckIfRunMethodReturnsZeroWhenMapHasNoExit()
        {
            var result = game.Run(@"TestData\noExitMap.txt");
            var expected = 0;
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestRunMethodWhenFileIsNull()
        {
            var result = game.Run(null);
            Assert.Equal(0, result);
        }
        [Fact]
        public void TestRunMethodWhenTextFileIsEmpty()
        {
            var result = game.Run(@"TestData\emptyMap.txt");
            Assert.Equal(0, result);
        }
        [Fact]
        public void TestIfConvertToMazeArrayMethodConvertsStringToJaggedArray()
        {
            var testString = "11111\r\n1   1\r\n1 1 1\r\n1 1 1\r\n1  X1\r\n1   1";
            var result = mazeArray.ConvertToMazeArray(testString);
            int[][] expected = {
    new int[] { -1,-1,-1,-1,-1},
    new int[] { -1,0,0,0,-1 },
    new int[] { -1,0,-1,0,-1 },
    new int[] { -1,0,-1,0,-1 },
    new int[] { -1, 0,0,1,-1 },
    new int[] {-1,-2,-2,-2,-1} };
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestIfConvertToMazeArrayMethodConvertNotDefinedCharsIntoZeroButNotMakeThemExits()
        {
            var testStringWithZ = "11Z11\r\n1   1\r\n1 1 1\r\n1 1 1\r\n1  X1\r\n1   1";
            var result = mazeArray.ConvertToMazeArray(testStringWithZ);
            int[][] expected = {
    new int[] { -1,-1,0,-1,-1},
    new int[] { -1,0,0,0,-1 },
    new int[] { -1,0,-1,0,-1 },
    new int[] { -1,0,-1,0,-1 },
    new int[] { -1, 0,0,1,-1 },
    new int[] {-1,-2,-2,-2,-1} };
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestIfConvertToMazeArrayMethodConvertsEmptyStringToEmptyJaggedArray()
        {
            var testString = "";
            var result = mazeArray.ConvertToMazeArray(testString);
            int[][] expected = {
    new int[] { -1,-1,-1,-1,-1},
    new int[] { -1,0,0,0,-1 },
    new int[] { -1,0,-1,0,-1 },
    new int[] { -1,0,-1,0,-1 },
    new int[] { -1, 0,0,1,-1 },
    new int[] {-1,-3,-3,-3,-1} };
            Assert.Empty(result);
        }
        [Fact]
        public void TestRunMethodIfNonSquareRectangleMapWorks()
        {
            var result = game.Run(@"TestData\rectangleMap.txt");
            var expected = 37;
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestRunMethodWithSquareMap()
        {
            var result = game.Run(@"TestData\squareMap.txt");
            var expected = 5;
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestRunMethodWithMultipleExitMap()
        {
            var result = game.Run(@"TestData\multipleExitMap.txt");
            var expected = 4;
            Assert.Equal(expected, result);
        }
    }
}