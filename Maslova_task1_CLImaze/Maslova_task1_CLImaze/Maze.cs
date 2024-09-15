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
        /// Step of the main walls
        /// </summary>
        /// <remarks>Шаг главных стен</remarks>
        private const int WallStep = 4;

        /// <summary>
        /// The height/width of the maze
        /// </summary>
        /// <remarks>Длина/ширина лабиринта</remarks>
        private static int mazeWidth, mazeHeight;

        private 

        /// <summary>
        /// Return a newly generated maze
        /// </summary>
        public static Maze(int mazeWidt, int mazeHeigh)
        {
            mazeWidth = mazeWidt;
            mazeHeight = mazeHeigh;

            var output = Maze.GenerateBaseLayout();
            output = Maze.GenerateRooms(output);
            return output;
        }

        /// <summary>
        /// Generate the base maze layout that will be modified further
        /// </summary>
        /// <remarks>Создать базовый макет лабиринта, который будет изменён в дальнейшем</remarks>
        private static List<StringBuilder> GenerateBaseLayout()
        {
            var output = new List<StringBuilder>();

            var topWall = new StringBuilder("▓▓   ");
            for (var i = 5; i < mazeWidth; i++)
            {
                topWall.Append(Constants.Wall);
            }
            output.Add(topWall);


            for (var row = 1; row < mazeHeight - 2; row++)
            {
                var newString = new StringBuilder();
                newString.Append(Constants.Wall);
                for (var col = 0; col < mazeWidth - 3; col++)
                {
                    if (col % WallStep == 0)
                    {
                        newString.Append(Constants.Wall);
                    }
                    else
                    {
                        newString.Append(Constants.Air);
                    }
                }
                newString.Append(Constants.Wall, 2);
                output.Add(newString);
            }


            var bottomWall = new StringBuilder();
            for (var i = 0; i < mazeWidth - 5; i++)
            {
                bottomWall.Append(Constants.Wall);
            }
            bottomWall.Append("   ▓▓");

            output.Add(bottomWall);
            return output;
        }

        /// <summary>
        /// Generate semi-random rooms in the base layout
        /// </summary>
        /// <remarks>Генерация полуслучайных комнат в базовой разметке</remarks>
        private static List<StringBuilder> GenerateRooms(List<StringBuilder> listStr)
        {
            var rnd = new Random();
            var newListStr = listStr;

            var newWallCount = mazeWidth / 3 * 2;

            for (var i = 0; i < newWallCount; i++)
            {

            }

            return newListStr;
        }
    }
}
