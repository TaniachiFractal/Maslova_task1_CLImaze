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
            Console.WriteLine();
            Console.WriteLine();
            TextOutput.ConsoleWriteListStringBuilder(new Maze(79, 20).maze);
            Console.ReadKey();
        }
    }
}
