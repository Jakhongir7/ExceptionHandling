using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
            Console.WriteLine("Enter some text: ");
            var inputLine = Console.ReadLine();
            try
            {
                PrintFirstChar(inputLine);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("You have not entered a text.");
                Console.WriteLine(ex.Message);
            }

            void PrintFirstChar(string inputString)
            {
                if (inputString == "") throw new ArgumentNullException("You should provide some text.");
                string[] split = inputString.Split();
                Console.Write(split[0].Substring(0, 1));
            }
        }
    }
}