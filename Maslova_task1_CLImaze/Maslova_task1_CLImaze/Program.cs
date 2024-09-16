using System.Numerics;
using System;
using System.Text;
using System.Globalization;

namespace Maslova_task1_CLImaze
{
    /// <summary>
    /// Main() holder
    /// </summary>
    /// <remarks>Содержит Main()</remarks>
    static internal class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <remarks>Точка входа в программу</remarks>
        private static void Main()
        {
        Re:
            Console.Write("Введите размер тумана вокруг игрока (целое число в районе 5): \n >_");
            try
            {
                TextOutput.FogDistance = int.Parse(Console.ReadLine());
            }
            catch { goto Re; }
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;

            var maze = new Maze(79, 20).maze;

            var stillPlaying = true;
            var showSolution = false;
            while (stillPlaying)
            {
                Console.SetCursorPosition(0, 0);
                TextOutput.RenderMazeWithFog(maze, showSolution);

                Player.RenderPlayer(Cnst.Player);
                var action = Console.ReadKey(true).Key;
                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        Player.Move(Cnst.Up, maze);
                        break;
                    case ConsoleKey.DownArrow:
                        Player.Move(Cnst.Down, maze);
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.Move(Cnst.Left, maze);
                        break;
                    case ConsoleKey.RightArrow:
                        Player.Move(Cnst.Right, maze);
                        break;
                    case ConsoleKey.X:
                        stillPlaying = false;
                        break;
                    case ConsoleKey.S:
                        showSolution = !showSolution;
                        break;
                    default:
                        break;

                }
                if (Player.Row >= maze.Count - 1)
                {
                    Console.SetCursorPosition(0, 0);
                    TextOutput.ConsoleWriteListStringBuilder(maze, Cnst.SolutionPath, Cnst.SolutionColor, Cnst.MazeColor);
                    Player.RenderPlayer(Cnst.Player);
                    break;
                }
            }
            Console.SetCursorPosition(0, maze.Count + 1);
            Console.WriteLine("Игра окончена. ");
            Thread.Sleep(1500);
            Console.ReadKey();
        }
    }
}
