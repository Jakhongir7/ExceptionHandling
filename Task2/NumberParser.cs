using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("Please provide some number.");
            }

            stringValue = stringValue.Replace(" ", String.Empty);

            if (stringValue == "")
            {
                throw new FormatException("Input string is not a sequence of digits.");
            }

            try
            {
                if (stringValue.First() == '-')
                {
                    return TransformStringToInt(stringValue.Skip(1), -1);
                }
                if (stringValue.First() == '+')
                {
                    return TransformStringToInt(stringValue.Skip(1), 1);
                }

                return TransformStringToInt(stringValue, 1);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ArgumentNullException("Please provide some number.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw new FormatException("Input string is not a sequence of digits.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
                throw new OverflowException();
            }
        }
        private static int TransformStringToInt(IEnumerable<char> source, int sign)
        {
            int result = 0;

            foreach (var value in source)
            {
                var digit = TransformCharToDigit(value);
                result = AddDigitToResult(result, digit, sign);
            }

            return result;
        }
        private static int TransformCharToDigit(char value)
        {
            if (!(value >= '0' && value <= '9'))
            {
                throw new FormatException("Source string contains non digit chars");
            }

            return value - '0';
        }
        private static int AddDigitToResult(int result, int digit, int sign)
        {
            checked
            {
                result = result * 10 + sign * digit;
            }

            return result;
        }
    }
}