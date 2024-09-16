using System.Text;

namespace Maslova_task1_CLImaze
{
    /// <summary>
    /// Class for outputting text with various properties
    /// </summary>
    /// <remarks>Класс для вывода текста с различными свойствами</remarks>
    internal class TextOutput
    {
        /// <summary>
        /// The distance of fog from the player
        /// </summary>
        /// <remarks>Расстояние от тумана до игрока</remarks>
        public static int FogDistance;

        /// <summary>
        /// Write a list of string builders to the console
        /// </summary>
        /// <remarks>Вывести в консоль список string builder-ов</remarks>
        private static void ConsoleWriteListStringBuilder(List<StringBuilder> listStr)
        {
            foreach (StringBuilder sb in listStr)
            {
                Console.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// Write a list of string builders to the console, but replace a sertain symbol
        /// </summary>
        /// <remarks>Вывести список string builder-ов в консоль, но заменить определенный символ</remarks>
        private static void ConsoleWriteListStringBuilder(List<StringBuilder> listStr, char SymbolToHide, char ReplacementSymbol)
        {
            foreach (StringBuilder sb in listStr)
            {
                for (var i = 0; i < sb.Length; i++)
                {
                    if (sb[i] == SymbolToHide)
                    {
                        Console.Write(ReplacementSymbol);
                    }
                    else
                    {
                        Console.Write(sb[i]);
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Write a list of string builders to the console, but color a specific symnol
        /// </summary>
        /// <remarks>Вывести список построителей строк в консоль, но выделить определенный символ цветом</remarks>
        public static void ConsoleWriteListStringBuilder(List<StringBuilder> listStr, char SymbolToColor, ConsoleColor symbColor, ConsoleColor mainColor)
        {
            foreach (StringBuilder sb in listStr)
            {
                for (var i = 0; i < sb.Length; i++)
                {
                    Console.ForegroundColor = sb[i] == SymbolToColor ? symbColor : mainColor;
                    Console.Write(sb[i]);
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Render the maze with fog
        /// </summary>
        /// <remarks>Редер лабиринта с туманом</remarks>
        public static void RenderMazeWithFog(List<StringBuilder> maze, bool showSolution)
        {
            var saveMaze = new List<StringBuilder>();
            saveMaze.AddRange(maze.ToList());

            var output = new List<StringBuilder>();
            for (var row = 0; row < maze.Count; row++)
            {
                var newStringBuilder = new StringBuilder();
                for (var col = 0; col < maze[0].Length; col++)
                {
                    if (Misc.Distance(Player.Row, Player.Col, row, col) > FogDistance)
                    {
                        newStringBuilder.Append(Cnst.Fog);
                    }
                    else
                    {
                        newStringBuilder.Append(saveMaze[row][col]);
                    }
                }
                output.Add(newStringBuilder);
            }
            if (showSolution)
            {
                ConsoleWriteListStringBuilder(output, Cnst.SolutionPath, Cnst.SolutionColor, Cnst.MazeColor);
            }
            else
            {
                ConsoleWriteListStringBuilder(output, Cnst.SolutionPath, Cnst.Air);
            }
        }
    }
}
