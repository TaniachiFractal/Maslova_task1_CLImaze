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
        /// Write a list of string builders to the console
        /// </summary>
        /// <remarks>Вывести в консоль список string builder-ов</remarks>
        public static void ConsoleWriteListStringBuilder(List<StringBuilder> listStr)
        {
            foreach (StringBuilder sb in listStr)
            {
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
