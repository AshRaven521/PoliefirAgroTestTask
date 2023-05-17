using System;
using System.IO;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1\n");
            string fullPath = Path.GetFullPath("test.txt");
            Console.WriteLine($"Файл с тестовыми значениями: {fullPath}");
            try
            {
                TaskOne.Do("test.txt");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("\nЗадание №2\n");
            Console.Write("Введите выражение в виде обратной польской записи: ");
            string input = Console.ReadLine();

            try
            {
                var result = TaskTwo.Calculate(input);
                Console.WriteLine($"Результат вычисления выражения в обратной польской записи: {result}");
                string infixForm = TaskTwo.GetInfixForm(input);
                Console.WriteLine($"Инфиксная форма: {infixForm} = {result}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    
    }
}
