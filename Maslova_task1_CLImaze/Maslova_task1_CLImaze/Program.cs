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
            TextOutput.ConsoleWriteListStringBuilder(Maze.GenerateMaze(79, 25));
            Console.ReadKey();
        }
    }
}
