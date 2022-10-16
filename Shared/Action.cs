using System.Collections.Generic;

namespace LasmartTest.Shared
{
    public class Action
    {
        public const char Move = 'M';

        public const char RotateLeft = 'L';

        public const char RotateRight = 'R';


        public static Dictionary<char, string> ActionMap = new()
        {
            { 'M', "Move" },
            { 'L', "Rotate Left" },
            { 'R', "Rotate Right" }
        };
    }
}
