using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maslova_task1_CLImaze
{
    /// <summary>
    /// Class for miscellaneous methods
    /// </summary>
    /// <remarks>Класс для разных методов</remarks>
    internal class Misc
    {
        private static double previousRandom = 0;
        /// <summary>
        /// Returns numbers in range between 0 and 1 that "feel" more random and nice
        /// </summary>
        /// <remarks>Возвращает числа в диапазоне от 0 до 1, которые «ощущаются» более случайными и приятными</remarks>
        public static double NiceRandomDouble(double max)
        {
            var newRandom = new Random().NextDouble();
            if (newRandom == previousRandom)
            {
                newRandom = Math.Abs(previousRandom - newRandom);
            }
            if (newRandom < 0.1)
            {
                newRandom += 0.1;
            }
            if (newRandom > 0.9)
            {
                newRandom -= 0.1;
            }

            newRandom *= max;

            previousRandom = newRandom;
            return newRandom;
        }

        /// <summary>
        /// Returns the amount of rows or cols to add according to the direction
        /// </summary>
        /// <remarks>Возвращает количество строк или столбцов для добавления в соответствии с направлением</remarks>
        public static (int row, int col) DirectionToRowCol(int direction)
        {
            return direction switch
            {
                Cnst.Up => (-1, 0),
                Cnst.Down => (1, 0),
                Cnst.Left => (0, -1),
                Cnst.Right => (0, 1),
                _ => (0, 0),
            };
        }

        /// <summary>
        /// Distance between 2 points
        /// </summary>
        /// <returns>Расстояние между 2 точками</returns>
        public static int Distance(int row1, int col1, int row2, int col2)
        {
            return (int)(Math.Sqrt((row2 - row1) * (row2 - row1) + (col2 - col1) * (col2 - col1)));
        }
    }
}
