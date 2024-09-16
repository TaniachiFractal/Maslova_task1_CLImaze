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
    }
}
