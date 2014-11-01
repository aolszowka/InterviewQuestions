using System;
using System.Collections.Generic;

namespace ConvertingStringAndInts
{
    class Program
    {
        static void Main(string[] args)
        {
            string testValue = (Int32.MinValue).ToString();

            int parsedValue = ParseNeg(testValue);
            Console.WriteLine(parsedValue);
            string parsedValueStr = ToStringNeg(parsedValue);
            Console.WriteLine(parsedValueStr);
        }

        public static int Parse(string s)
        {
            int parsedValue = 0;

            foreach (char c in s.ToCharArray())
            {
                parsedValue = parsedValue * 10;
                parsedValue = parsedValue + (c - 48);
            }

            return parsedValue;
        }

        // Non-Negative
        public static string ToString(int i)
        {
            Stack<char> parsedValue = new Stack<char>();

            do
            {
                int mod = i % 10;
                i = i / 10;
                char c = (char)((mod) + 48);
                parsedValue.Push(c);
            } while (i != 0);

            return new string(parsedValue.ToArray());
        }

        // Negative
        public static string ToStringNeg(int i)
        {
            bool isNegative = false;
            bool isMinValue = false;

            if (i < 0)
            {
                isNegative = true;
                isMinValue = i == Int32.MinValue;

                if (isMinValue)
                {
                    i = i + 1;
                }

                i = -i;
            }

            Stack<char> parsedValue = new Stack<char>();

            do
            {
                int mod = i % 10;
                i = i / 10;
                char c = (char)((mod) + 48);
                parsedValue.Push(c);
            } while (i != 0);

            if (isNegative)
            {
                parsedValue.Push('-');
            }

            char[] parsedString = parsedValue.ToArray();

            if (isMinValue)
            {
                parsedString[parsedString.Length - 1] = (char)((int)parsedString[parsedString.Length - 1] + 1);
            }

            return new string(parsedString);
        }

        public static int ParseNeg(string s)
        {
            int offsetForNegative = 0;

            bool isNegative = s.StartsWith("-");

            if (isNegative)
            {
                offsetForNegative = 1;
            }

            int parsedValue = 0;

            foreach (char c in s.Substring(offsetForNegative).ToCharArray())
            {
                parsedValue = parsedValue * 10;
                parsedValue = parsedValue + (c - 48);
            }

            if (isNegative)
            {
                parsedValue = -parsedValue;
            }

            return parsedValue;
        }
    }
}
