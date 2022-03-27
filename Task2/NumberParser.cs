using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            stringValue = stringValue.Replace(" ", String.Empty);
            if (stringValue == null)
            {
                throw new ArgumentNullException("You should provide some text");
            }
            if (stringValue == "")
            {
                throw new FormatException("You should provide some text");
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
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to convert. Input string is not a sequence of digits.");
                throw new FormatException();
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
                throw new OverflowException();
            }
            catch (NotImplementedException)
            {
                throw new NotImplementedException();
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