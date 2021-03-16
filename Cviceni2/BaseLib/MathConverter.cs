using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fei
{
    namespace BaseLib
    {
        public class MathConverter
        {
            public static string DecToBin(int dec)
            {
                var result = dec;

                var sb = new StringBuilder();

                while (dec > 0)
                {
                    sb.Append(dec % 2);
                    dec /= 2;
                }

                return Reverse(sb.ToString());
            }


            public static string BinToDec(string bin)
            {
                int result = 0;

                for (int i = 0; i < bin.Length; i++)
                {
                    if (!Int32.TryParse(bin[bin.Length - 1 - i].ToString(), out int num))
                    {
                        throw new FormatException();
                    }

                    result += (int) Math.Pow(2 * num, i);
                }

                return result.ToString();
            }

            public static string DecToRomeOrCrash(int dec)
            {
                var index = 0;
                var sb = new StringBuilder();
                while (dec > 0)
                {
                    //this line might trow exception
                        var romeNumNumValAndCount = FindFirstMatchingRomeNumberOrCrash(dec);

                        for (int j = 0; j < romeNumNumValAndCount.Item3; j++)
                        {
                            sb.Append(romeNumNumValAndCount.Item1);
                        }

                        dec -= romeNumNumValAndCount.Item2 * romeNumNumValAndCount.Item3;
                    
                }

                return sb.ToString();
            }

            /// <summary>
            /// Function finds first matching tuple from <value>romeNumbers</value>,starting with given index. 
            /// </summary>
            /// <param name="totalValue"></param>
            /// <param name="index"></param>
            /// <param name="resultIndex"></param>
            /// <returns>returns found rome Number, val of rome number,  number of times </returns>
            private static Tuple<string, int, int> FindFirstMatchingRomeNumberOrCrash(int totalValue)
            {
                var index = 0;
                var length = romeNumbers.Count;
                int timesValFits = 0;
                while (timesValFits == 0)
                {
                    timesValFits = totalValue / romeNumbers[index].Item2;


                    if (index >= romeNumbers.Count)
                    {
                        throw new ArithmeticException("No rome number can be formed from this");
                    }
                    index++;

                }

                return Tuple.Create(romeNumbers[index - 1].Item1, romeNumbers[index - 1].Item2, timesValFits);
            }


            public static int RomeToDec(string romeNum)
            {
                var result = 0;
                var resultString = romeNum;
                while (resultString != "")
                {
                    var substring = resultString.Length != 1
                        ? resultString.Substring(0, 2)
                        : resultString.Substring(0, 1);
                    var tupleNum = romeNumbers.Find(tuple => tuple.Item1 == substring);

                    if (tupleNum == null)
                    {
                        substring = resultString.Substring(0, 1);
                        tupleNum = romeNumbers.Find(tuple => tuple.Item1 == substring);
                        if (tupleNum == null)
                        {
                            throw new FormatException("Wrong format of rome number");
                        }
                    }

                    result += tupleNum.Item2;
                    resultString = resultString.Substring(substring.Length);
                }

                return result;
            }

            static private List<Tuple<string, Int32>> romeNumbers = new List<Tuple<string, Int32>>
            {
                Tuple.Create("M", 1000),
                Tuple.Create("CM", 900),
                Tuple.Create("D", 500),
                Tuple.Create("CD", 400),
                Tuple.Create("C", 100),
                Tuple.Create("XC", 90),
                Tuple.Create("L", 50),
                Tuple.Create("XL", 40),
                Tuple.Create("X", 10),
                Tuple.Create("IX", 9),
                Tuple.Create("V", 5),
                Tuple.Create("IV", 4),
                Tuple.Create("I", 1)
            };

            private static string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
    }
}