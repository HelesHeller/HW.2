using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Обмін розрядів у шестизначному числі");
        Console.WriteLine("2. Визначення пори року та дня тижня за датою");
        Console.WriteLine("3. Виведення парних чисел в діапазоні");
        Console.Write("Виберіть завдання (1/2/3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ExchangeDigits();
                break;
            case "2":
                DetermineSeasonAndDayOfWeek();
                break;
            case "3":
                DisplayEvenNumbersInRange();
                break;
            default:
                Console.WriteLine("Невірний вибір завдання.");
                break;
        }
    }

    static void ExchangeDigits()
    {
        Console.WriteLine("Завдання 1 - Обмін розрядів у шестизначному числі");
        Console.Write("Введіть 6-значне число: ");
        string inputNumber = Console.ReadLine();

        if (inputNumber.Length != 6 || !int.TryParse(inputNumber, out int number))
        {
            Console.WriteLine("Помилка: Число не є 6-значним або цілим.");
        }
        else
        {
            Console.Write("Введіть номер першого розряду для обміну: ");
            int firstDigitIndex = int.Parse(Console.ReadLine());

            Console.Write("Введіть номер другого розряду для обміну: ");
            int secondDigitIndex = int.Parse(Console.ReadLine());

            if (firstDigitIndex < 1 || firstDigitIndex > 6 || secondDigitIndex < 1 || secondDigitIndex > 6)
            {
                Console.WriteLine("Помилка: Номери розрядів повинні бути від 1 до 6.");
            }
            else
            {
                char[] numberArray = inputNumber.ToCharArray();
                char temp = numberArray[firstDigitIndex - 1];
                numberArray[firstDigitIndex - 1] = numberArray[secondDigitIndex - 1];
                numberArray[secondDigitIndex - 1] = temp;

                string resultNumber = new string(numberArray);
                Console.WriteLine($"Змінене число: {resultNumber}");
            }
        }
    }

    static void DetermineSeasonAndDayOfWeek()
    {
        Console.WriteLine("Завдання 2 - Визначення пори року та дня тижня за датою");
        Console.Write("Введіть дату у форматі dd.MM.yyyy: ");
        string inputDate = Console.ReadLine();

        if (DateTime.TryParseExact(inputDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            string season = GetSeason(date.Month);
            string dayOfWeek = date.DayOfWeek.ToString();

            Console.WriteLine($"Пора року: {season}, День тижня: {dayOfWeek}");
        }
        else
        {
            Console.WriteLine("Помилка: Некоректний формат дати.");
        }
    }

    static void DisplayEvenNumbersInRange()
    {
        Console.WriteLine("Завдання 3 - Виведення парних чисел в діапазоні");
        Console.Write("Введіть початкове число діапазону: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("Введіть кінцеве число діапазону: ");
        int end = int.Parse(Console.ReadLine());

        int a = Math.Min(start, end);
        int b = Math.Max(start, end);

        Console.WriteLine($"Парні числа в діапазоні від {a} до {b}:");

        for (int i = a; i <= b; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }

    static string GetSeason(int month)
    {
        switch (month)
        {
            case 12:
            case 1:
            case 2:
                return "Winter";
            case 3:
            case 4:
            case 5:
                return "Spring";
            case 6:
            case 7:
            case 8:
                return "Summer";
            case 9:
            case 10:
            case 11:
                return "Autumn";
            default:
                return "Некоректна пора року";
        }
    }
}
