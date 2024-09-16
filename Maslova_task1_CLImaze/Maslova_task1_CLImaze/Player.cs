using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace Maslova_task1_CLImaze
{
    /// <summary>
    /// The player class
    /// </summary>
    /// <remarks>Класс игрока</remarks>
    internal class Player
    {

        /// <summary>
        /// The current Row of the player
        /// </summary>
        /// <remarks>Текущая строка игрока</remarks>
        public static int Row = 0;
        /// <summary>
        /// The current col of the player
        /// </summary>
        /// <remarks>Текущая колонка игрока</remarks>
        public static int Col = 3;

        /// <summary>
        /// Move the player or prevent it from moving
        /// </summary>
        /// <remarks>Переместить игрока или помешать ему двигаться</remarks>
        public static void Move(int direction, List<StringBuilder> maze)
        {
            (var addRow, var addCol) = Misc.DirectionToRowCol(direction);
            var newRow = addRow + Row;
            var newCol = addCol + Col;
            if (CanMove(direction, maze))
            {
                Console.SetCursorPosition(Col, Row);
                Console.Write(Cnst.Air);
                Row = newRow;
                Col = newCol;
            }
        }
        private static bool CanMove(int direction, List<StringBuilder> maze)
        {
            (var addRow, var addCol) = Misc.DirectionToRowCol(direction);
            var newRow = addRow + Row;
            var newCol = addCol + Col;
            if (newRow > -1 && newCol > -1)
            {
                if (newRow < maze.Count && newCol < maze[0].Length - 1)
                {
                    if (maze[newRow][newCol] != Cnst.Wall)
                    {
                        return true;
                    }
                }
                else if (newCol < maze[0].Length - 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Render the player onto the field
        /// </summary>
        /// <remarks>Вывод игрока на поле</remarks>
        public static void RenderPlayer(char image)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Col, Row);
            Console.Write(image);
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
