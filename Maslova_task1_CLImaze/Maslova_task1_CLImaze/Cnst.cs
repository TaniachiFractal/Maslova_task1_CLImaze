namespace Maslova_task1_CLImaze
{
    /// <summary>
    /// Class for various constants
    /// </summary>
    /// <remarks>Класс для различных констант</remarks>
    internal class Cnst
    {
        /// <summary>
        /// The char for walls
        /// </summary>
        /// <remarks>Символ стены</remarks>
        public const char Wall = '▓';

        /// <summary>
        /// The char for air
        /// </summary>
        /// <remarks>Символ воздуха</remarks>
        public const char Air = ' ';

        /// <summary>
        /// The char for solution path
        /// </summary>
        /// <remarks>Символ пути решения</remarks>
        public const char SolutionPath = '▪';

        /// <summary>
        /// The char for the player
        /// </summary>
        /// <remarks>Символ игрока</remarks>
        public const char Player = 'ꭥ';

        /// <summary>
        /// The directions of moving
        /// </summary>
        /// <remarks>Направления движения</remarks>
        public const int Up = 0, Right = 1, Down = 2, Left = 3;
    }
}
