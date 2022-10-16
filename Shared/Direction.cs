using System.Collections.Generic;

namespace LasmartTest.Shared
{
    public class Direction
    {
        public const char North = 'N';

        public const char East = 'E';

        public const char South = 'S';

        public const char West = 'W';

        public const char Unknown = 'X';

        public static Dictionary<char, string> DirectionMap = new()
        {
            { 'N', "North" },
            { 'E', "East" },
            { 'S', "South" },
            { 'W', "West" }
        };
    }
}
