using System.Reflection.Metadata;
using System.Text;

namespace Maslova_task1_CLImaze
{
    /// <summary>
    /// Class for generating the maze
    /// </summary>
    /// <remarks>Класс для генерации лабиринта</remarks>
    internal class Maze
    {
        /// <summary>
        /// Constructor: Generate a maze
        /// </summary>
        public Maze(int mazeWidt, int mazeHeigh)
        {
            mazeWidth = mazeWidt;
            mazeHeight = mazeHeigh;

            maze = GenerateBaseLayout();
            maze = GenerateRooms(maze);
            maze = SaltTheMaze(maze, Cnst.Wall, 0.125);
            maze = SaltTheMaze(maze, Cnst.Air, 0.125);
            for (var i = 0; i < 2; i++)
            {
                maze = DigPath(maze, Cnst.Air);
            }
            maze = DigPath(maze, Cnst.SolutionPath);
        }


        /// <summary>
        /// Step of the main walls
        /// </summary>
        /// <remarks>Шаг главных стен</remarks>
        private const int WallStep = 4;

        /// <summary>
        /// The width of the maze
        /// </summary>
        /// <remarks>Ширина лабиринта</remarks>
        private readonly int mazeWidth;
        /// <summary>
        /// The height of the maze
        /// </summary>
        /// <remarks>Высота лабиринта</remarks>
        private readonly int mazeHeight;

        /// <summary>
        /// The maze itself
        /// </summary>
        /// <remarks>Сам лабиринт</remarks>
        public readonly List<StringBuilder> maze;

        #region generation
        /// <summary>
        /// Generate the base maze layout that will be modified further
        /// </summary>
        /// <remarks>Создать базовый макет лабиринта, который будет изменён в дальнейшем</remarks>
        private List<StringBuilder> GenerateBaseLayout()
        {
            var output = new List<StringBuilder>();

            var topWall = new StringBuilder($"{Cnst.Wall}{Cnst.Wall}   ");
            for (var i = 5; i < mazeWidth; i++)
            {
                topWall.Append(Cnst.Wall);
            }
            output.Add(topWall);


            for (var row = 1; row < mazeHeight - 2; row++)
            {
                var newString = new StringBuilder();
                newString.Append(Cnst.Wall);
                for (var col = 0; col < mazeWidth - 3; col++)
                {
                    if (col % WallStep == 0)
                    {
                        newString.Append(Cnst.Wall);
                    }
                    else
                    {
                        newString.Append(Cnst.Air);
                    }
                }
                newString.Append(Cnst.Wall, 2);
                output.Add(newString);
            }


            var bottomWall = new StringBuilder();
            for (var i = 0; i < mazeWidth - 5; i++)
            {
                bottomWall.Append(Cnst.Wall);
            }
            bottomWall.Append($"   {Cnst.Wall}{Cnst.Wall}");

            output.Add(bottomWall);
            return output;
        }

        /// <summary>
        /// Generate semi-random rooms in the base layout
        /// </summary>
        /// <remarks>Генерация полуслучайных комнат в базовой разметке</remarks>
        private List<StringBuilder> GenerateRooms(List<StringBuilder> listStr)
        {
            var newListStr = listStr;

            for (var colStart = 2; colStart < mazeWidth; colStart += WallStep)
            {
                for (var i = 0; i < 5; i++)
                {
                    var roomHeight = (int)(Misc.NiceRandomDouble(1) * (mazeHeight - 2));
                    for (var col = colStart; col < mazeWidth && col < WallStep + colStart; col++)
                    {
                        maze[roomHeight][col] = Cnst.Wall;
                    }
                }
            }

            return newListStr;
        }

        /// <summary>
        /// Put chars randomly across the maze
        /// </summary>
        /// <remarks>Разместить символы в случайном порядке по лабиринту</remarks>
        private List<StringBuilder> SaltTheMaze(List<StringBuilder> listStr, char symbol, double chance)
        {
            var newListStr = listStr;
            for (var row = 1; row < mazeHeight - 2; row++)
            {
                for (var col = 0; col < mazeWidth - 3; col++)
                {
                    if (Misc.NiceRandomDouble(1) < chance)
                    {
                        newListStr[row][col] = symbol;
                    }
                }
            }
            return newListStr;
        }

        /// <summary>
        /// Dig a solution path in the base layout
        /// </summary>
        /// <remarks>Выкопать путь решения в базовой разметке</remarks>
        private List<StringBuilder> DigPath(List<StringBuilder> listStr, char path)
        {
            var vertChangeChance = 0.5;
            var horizChangeChance = 0.3;

            var newListStr = listStr;
            var directionChangeChance = vertChangeChance;

            var currRow = 0;
            var currCol = 3;
            var currDirection = Cnst.Down;

            while (currCol < mazeWidth)
            {
                if (currCol >= mazeWidth - 2)
                {
                    for (var row = currRow; row < mazeHeight - 1; row++)
                    {
                        newListStr[row][currCol] = path;
                    }
                    break;
                }

                if (Misc.NiceRandomDouble(1) < directionChangeChance)
                {
                    currDirection = new Random().Next(4);
                }

                if (currRow <= 1)
                {
                    currDirection = Cnst.Down;
                }
                if (currRow >= mazeHeight - 3)
                {
                    currDirection = Cnst.Up;
                }


                newListStr[currRow][currCol] = path;

                if (currDirection == Cnst.Down)
                {
                    currRow++;
                    directionChangeChance = vertChangeChance;
                }
                else if (currDirection == Cnst.Left)
                {
                    currCol++;
                    directionChangeChance = horizChangeChance;
                }
                else if (currDirection == Cnst.Up)
                {
                    currRow--;
                    directionChangeChance = vertChangeChance;
                }

            }
            return newListStr;
        }
        #endregion
    }
}
