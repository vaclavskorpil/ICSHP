using System;
using System.Linq;

namespace Fei
{
    namespace BaseLib
    {
        public class Reading
        {
            static string ReadString(string message)
            {
                Console.WriteLine(message + ": ");
                return Console.ReadLine();
            }

            static int ReadInt(string message, int defaultValue)
            {
                var input = ReadString(message);
                if (int.TryParse(input, out int result))
                {
                    return result;
                }

                return defaultValue;
            }

            static double ReadDouble(string message, double defaultValue)
            {
                var input = ReadString(message);
                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                return defaultValue;
            }

            static char ReadChar(string message)
            {
                var input = ReadString(message);
                return input[0];
            }
        }
    }
}