using Common;
using System;

namespace UI
{
    public class ConsoleManager : IConsoleManager
    {
        public void PrintInfo(string info)
        {
            Console.WriteLine(info);
        }

        public double GetUserDouble(string userMessage, double? minValue = null, double? maxValue = null)
        {
            Console.Write(userMessage);

            double result;

            while (!double.TryParse(Console.ReadLine(), out result) || (minValue != null && result < minValue) || (maxValue != null && result > maxValue))
            {
                Console.Write("Error. Re-enter please: ");
            }

            return result;
        }

        public int GetUserInt(string userMessage, int? minValue = null, int? maxValue = null)
        {
            double result = GetUserDouble(userMessage, minValue, maxValue);

            while (result - (int)result != 0)
            {
                Console.Write("Error. Re-enter please: ");
                result = GetUserDouble(null, minValue, maxValue);
            }

            return (int)result;
        }

        public string GetUserString(string userMessage)
        {
            Console.Write(userMessage);

            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
