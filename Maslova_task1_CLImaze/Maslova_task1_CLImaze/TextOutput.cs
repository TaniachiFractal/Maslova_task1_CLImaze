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

        /// <summary>
        /// Write a list of string builders to the console, but replace a sertain symbol
        /// </summary>
        /// <remarks>Вывести список string builder-ов в консоль, но заменить определенный символ</remarks>
        public static void ConsoleWriteListStringBuilder(List<StringBuilder> listStr, char SymbolToHide, char ReplacementSymbol)
        {
            foreach (StringBuilder sb in listStr)
            {
                sb.Replace(SymbolToHide, ReplacementSymbol);
                Console.WriteLine(sb.ToString());
            }
        }

    }
}
