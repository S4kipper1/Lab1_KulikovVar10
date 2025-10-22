using System;
using System.Linq;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Ввод размера массива с проверкой корректности ввода
        int arraySize;
        while (true)
        {
            Console.Write("Введите размер массива: ");
            if (int.TryParse(Console.ReadLine(), out arraySize) && arraySize > 0) break;
            Console.WriteLine("Ошибка: введите целое положительное число!");
        }
        // Заполнение массива числами с проверкой корректности ввода
        double[] array = new double[arraySize];
        bool isLetter = true;
        for (int i = 0; i < arraySize; i++)
            while (isLetter)
            {
                Console.Write($"Введите элемент {i + 1}: ");
                string input = Console.ReadLine();
                input = input.Replace(',', '.'); // Замена запятой на точку для корректного ввода
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out array[i]))  isLetter = false;
                Console.WriteLine("Ошибка: введите число!");
            }
        // Вычисление суммы элементов с нечетными индексами
        double sumOdd = 0;
        for (int i = 1; i < arraySize; i += 2)
            sumOdd += array[i];
        // Поиск первого и последнего отрицательных элементов
        int firstNeg = -1, lastNeg = -1;
        for (int i = 0; i < arraySize; i++)
            if (array[i] < 0)
            {
                if (firstNeg == -1) firstNeg = i;
                lastNeg = i;
            }
        // Вычисление суммы между первым и последним отрицательными элементами
        double sumMezhdu = 0;
        if (firstNeg != -1 && lastNeg != -1 && firstNeg != lastNeg)
            for (int i = firstNeg + 1; i < lastNeg; i++)
                sumMezhdu += array[i];
        else
            Console.WriteLine("В массиве меньше двух отрицательных элементов.");
        // Преобразование массива: все нули перемещаются в конец
        array = array.Where(x => x != 0).Concat(array.Where(x => x == 0)).ToArray();
        // Вывод результатов
        Console.WriteLine($"Сумма нечетных: {sumOdd}");
        if (firstNeg != -1 && lastNeg != -1 && firstNeg != lastNeg)
            Console.WriteLine($"Сумма между отрицательными: {sumMezhdu}");
        Console.WriteLine(string.Join(" ", array));
    }
}