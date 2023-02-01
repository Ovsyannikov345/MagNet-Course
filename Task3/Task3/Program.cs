using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива");
            int arrLength = int.Parse(Console.ReadLine());
            
            int[] numbers = new int[arrLength];

            Console.WriteLine("Введите элементы массива");
            
            for(var i = 0; i < arrLength; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            //Сортировка массива
            int tempValue = 0;
            
            for(var j = 0; j < arrLength - 1; j++)
            {
                for (var i = 0; i < arrLength - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        tempValue = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = tempValue;
                    }
                }
            }

            //Поиск чаще всего встречающихся чисел и их значений
            int maxValueCount = 1;

            int valueCount = 1;

            int value = numbers[0];
            
            for (var i = 1; i < arrLength; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    valueCount++;
                }
                
                else
                {
                    if (valueCount > maxValueCount)
                    {
                        maxValueCount = valueCount;
                        valueCount = 1;
                        value = numbers[i-1];
                    }
                    
                    else
                    {
                        valueCount = 1;
                    }

                }
            }

            Console.WriteLine("Чаще всего встречается: " + value);
        }
    }
}
