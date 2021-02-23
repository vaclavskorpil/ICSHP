using System;
using System.Linq;

namespace Fei
{
    namespace BaseLib
    {
        public class Reading
        {
            public static string ReadString(string message)
            {
                Console.WriteLine(message + ": ");
                return Console.ReadLine();
            }

            public static int ReadInt(string message)
            {
                var input = ReadString(message);
                return int.Parse(input);
            }

            public static double ReadDouble(string message) 
            {
                var input = ReadString(message);
                return double.Parse(input);

            }

            public static char ReadChar(string message)
            {
                var input = ReadString(message);
                return input[0];
            }
        }
    }
}