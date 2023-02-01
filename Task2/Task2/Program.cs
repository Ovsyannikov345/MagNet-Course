using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1-е число");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите 2-е число");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите 3-е число");
            int thirdNumber = int.Parse(Console.ReadLine());

            int maxValue = 0;

            int minValue = 0;

            int avgValue = 0;
            
            bool firstNumberUsed = false;

            bool secondNumberUsed = false;

            bool thirdNumberUsed = false;

            //Поиск максимального числа
            if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
            {
                maxValue = firstNumber;
                firstNumberUsed = true;
            }
            
            else
            {
                if (secondNumber >= firstNumber && secondNumber >= thirdNumber)
                {
                    maxValue = secondNumber;
                    secondNumberUsed = true;
                }
                
                else
                {
                    if (thirdNumber >= firstNumber && thirdNumber >= secondNumber)
                    {
                        maxValue = thirdNumber;
                        thirdNumberUsed = true;
                    }
                }
            }

            //Поиск минимального числа
            if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
            {
                minValue = firstNumber;
                firstNumberUsed = true;
            }
            
            else
            {
                if (secondNumber <= firstNumber && secondNumber <= thirdNumber)
                {
                    minValue = secondNumber;
                    secondNumberUsed = true;
                }
                
                else
                {
                    if (thirdNumber <= firstNumber && thirdNumber <= secondNumber)
                    {
                        minValue = thirdNumber;
                        thirdNumberUsed = true;
                    }
                }
            }

            //Поиск среднего числа
            if (firstNumberUsed == false)
            {
                avgValue = firstNumber;
            }
            
            else
            {
                if (secondNumberUsed == false)
                {
                    avgValue = secondNumber;
                }
                
                else
                {
                    if (thirdNumberUsed == false)
                    {
                        avgValue = thirdNumber;
                    }
                }
            }

            Console.WriteLine("В порядке возрастания: {0} {1} {2}", minValue, avgValue, maxValue);
            Console.WriteLine("В порядке убывания: {0} {1} {2}", maxValue, avgValue, minValue);
            Console.WriteLine("Максимальное: {0}", maxValue);
            Console.WriteLine("Минимальное: {0}", minValue);
        }
    }
}
