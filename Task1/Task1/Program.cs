using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое значение: ");
            string input = Console.ReadLine();
            
            int num;

            bool isConverted = int.TryParse(input, out num);

            if (isConverted == false)
            {
                Console.WriteLine("Конвертация не удалась!");
            }
        }
    }
}
