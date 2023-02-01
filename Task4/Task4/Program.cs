using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLength];

            Console.WriteLine("Введите элементы массива");

            for (var i = 0; i < arrayLength - 1; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Исходный массив: ");

            for (var i = 0; i < arrayLength; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Введите значение: ");
            int additionalNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите позицию(начиная с 0): ");
            int position = int.Parse(Console.ReadLine());

            //Перемещение всех элементов вправо на 1
            var firstTempValue = numbers[position];

            var secondTempValue = numbers[position + 1];

            for (var i = position; i < arrayLength - 2; i++)
            {
                numbers[i + 1] = firstTempValue;
                firstTempValue = secondTempValue;
                secondTempValue = numbers[i + 2];
            }
            numbers[arrayLength - 1] = firstTempValue;

            //Подстановка дополнительного элемента
            numbers[position] = additionalNumber;

            Console.WriteLine("Конечный массив: ");

            for (var i = 0; i < arrayLength; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
