
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Лабораторная 6");
            Console.WriteLine("1 - Упражнение 6.1");
            Console.WriteLine("2 - Упражнение 6.2");
            Console.WriteLine("3 - Упражнение 6.3");
            Console.WriteLine("4 - Домашнее задание 6.1");
            Console.WriteLine("5 - Домашнее задание 6.2");
            Console.WriteLine("6 - Домашнее задание 6.3");
            Console.WriteLine("0 - Выход");
            string choice = Console.ReadLine();
            if (choice == "0") { break; }
            if (choice == "1") { Task61(args); }
            if (choice == "2") { Task62(); }
            if (choice == "3") { Task63(); }
            if (choice == "4") { TaskDZ61(args); }
            if (choice == "5") { TaskDZ62(); }
            if (choice == "6") { TaskDZ63(); }
            Console.WriteLine();
        }
    }

    static void Task61(string[] args)
    {
        Console.WriteLine("Упражнение 6.1. Подсчет гласных и согласных букв в файле.");
        string fileName = args.Length > 0 ? args[0] : "text.txt";
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден: " + fileName);
            return;
        }
        char[] chars = File.ReadAllText(fileName).ToCharArray();
        int vowels;
        int consonants;
        CountLetters(chars, out vowels, out consonants);
        Console.WriteLine("Гласных: " + vowels);
        Console.WriteLine("Согласных: " + consonants);
    }

    static void CountLetters(char[] chars, out int vowels, out int consonants)
    {
        string vowelLetters = "аеёиоуыэюяАЕЁИОУЫЭЮЯaeiouAEIOU";
        string consonantLetters = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩbcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        vowels = 0;
        consonants = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            if (vowelLetters.IndexOf(chars[i]) >= 0) { vowels++; }
            else if (consonantLetters.IndexOf(chars[i]) >= 0) { consonants++; }
        }
    }

    static void Task62()
    {
        Console.WriteLine("Упражнение 6.2. Умножение двух матриц.");
        int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] b = { { 7, 8 }, { 9, 10 }, { 11, 12 } };
        int[,] c = Multiply(a, b);
        Console.WriteLine("Матрица A:");
        PrintMatrix(a);
        Console.WriteLine("Матрица B:");
        PrintMatrix(b);
        Console.WriteLine("Матрица C = A * B:");
        PrintMatrix(c);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int[,] Multiply(int[,] a, int[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0)) { return new int[0, 0]; }
        int[,] result = new int[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                int sum = 0;
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    sum = sum + a[i, k] * b[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    static void Task63()
    {
        Console.WriteLine("Упражнение 6.3. Средняя температура за год.");
        Random random = new Random();
        int[,] temperature = new int[12, 30];
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                temperature[i, j] = random.Next(-30, 31);
            }
        }
        double[] averages = AverageTemperature(temperature);
        for (int i = 0; i < averages.Length; i++)
        {
            Console.WriteLine("Месяц " + (i + 1) + ": " + averages[i]);
        }
        Array.Sort(averages);
        Console.WriteLine("Средние температуры по возрастанию:");
        for (int i = 0; i < averages.Length; i++)
        {
            Console.WriteLine(averages[i]);
        }
    }

    static double[] AverageTemperature(int[,] temperature)
    {
        double[] averages = new double[temperature.GetLength(0)];
        for (int i = 0; i < temperature.GetLength(0); i++)
        {
            double sum = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                sum = sum + temperature[i, j];
            }
            averages[i] = sum / temperature.GetLength(1);
        }
        return averages;
    }

    static void TaskDZ61(string[] args)
    {
        Console.WriteLine("Домашнее задание 6.1. Подсчет букв с List<char>.");
        string fileName = args.Length > 0 ? args[0] : "text.txt";
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден: " + fileName);
            return;
        }
        List<char> chars = new List<char>();
        foreach (char ch in File.ReadAllText(fileName))
        {
            chars.Add(ch);
        }
        int vowels;
        int consonants;
        CountLettersList(chars, out vowels, out consonants);
        Console.WriteLine("Гласных: " + vowels);
        Console.WriteLine("Согласных: " + consonants);
    }

    static void CountLettersList(List<char> chars, out int vowels, out int consonants)
    {
        string vowelLetters = "аеёиоуыэюяАЕЁИОУЫЭЮЯaeiouAEIOU";
        string consonantLetters = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩbcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        vowels = 0;
        consonants = 0;
        for (int i = 0; i < chars.Count; i++)
        {
            if (vowelLetters.IndexOf(chars[i]) >= 0) { vowels++; }
            else if (consonantLetters.IndexOf(chars[i]) >= 0) { consonants++; }
        }
    }

    static void TaskDZ62()
    {
        Console.WriteLine("Домашнее задание 6.2. Умножение матриц через LinkedList.");
        int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] b = { { 7, 8 }, { 9, 10 }, { 11, 12 } };
        LinkedList<LinkedList<int>> linkedA = ToLinkedListMatrix(a);
        LinkedList<LinkedList<int>> linkedB = ToLinkedListMatrix(b);
        LinkedList<LinkedList<int>> linkedC = MultiplyLinkedList(linkedA, linkedB);
        Console.WriteLine("Матрица A:");
        PrintLinkedListMatrix(linkedA);
        Console.WriteLine("Матрица B:");
        PrintLinkedListMatrix(linkedB);
        Console.WriteLine("Матрица C = A * B:");
        PrintLinkedListMatrix(linkedC);
    }

    static LinkedList<LinkedList<int>> ToLinkedListMatrix(int[,] matrix)
    {
        LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            LinkedList<int> row = new LinkedList<int>();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                row.AddLast(matrix[i, j]);
            }
            result.AddLast(row);
        }
        return result;
    }

    static void PrintLinkedListMatrix(LinkedList<LinkedList<int>> matrix)
    {
        foreach (LinkedList<int> row in matrix)
        {
            foreach (int value in row)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }

    static LinkedList<LinkedList<int>> MultiplyLinkedList(LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
    {
        List<List<int>> listA = new List<List<int>>();
        foreach (LinkedList<int> row in a) { listA.Add(new List<int>(row)); }
        List<List<int>> listB = new List<List<int>>();
        foreach (LinkedList<int> row in b) { listB.Add(new List<int>(row)); }
        LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();
        if (listA.Count == 0 || listB.Count == 0) { return result; }
        if (listA[0].Count != listB.Count) { return result; }
        for (int i = 0; i < listA.Count; i++)
        {
            LinkedList<int> newRow = new LinkedList<int>();
            for (int j = 0; j < listB[0].Count; j++)
            {
                int sum = 0;
                for (int k = 0; k < listB.Count; k++)
                {
                    sum = sum + listA[i][k] * listB[k][j];
                }
                newRow.AddLast(sum);
            }
            result.AddLast(newRow);
        }
        return result;
    }

    static void TaskDZ63()
    {
        Console.WriteLine("Домашнее задание 6.3. Средняя температура через Dictionary.");
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        Random random = new Random();
        Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();
        for (int i = 0; i < months.Length; i++)
        {
            int[] days = new int[30];
            for (int j = 0; j < days.Length; j++)
            {
                days[j] = random.Next(-30, 31);
            }
            temperature.Add(months[i], days);
        }
        Dictionary<string, double> averages = AverageByMonth(temperature);
        foreach (KeyValuePair<string, double> pair in averages)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
        List<KeyValuePair<string, double>> sorted = new List<KeyValuePair<string, double>>(averages);
        sorted.Sort(delegate (KeyValuePair<string, double> x, KeyValuePair<string, double> y) { return x.Value.CompareTo(y.Value); });
        Console.WriteLine("Средние температуры по возрастанию:");
        foreach (KeyValuePair<string, double> pair in sorted)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }

    static Dictionary<string, double> AverageByMonth(Dictionary<string, int[]> temperature)
    {
        Dictionary<string, double> result = new Dictionary<string, double>();
        foreach (KeyValuePair<string, int[]> pair in temperature)
        {
            double sum = 0;
            for (int i = 0; i < pair.Value.Length; i++)
            {
                sum = sum + pair.Value[i];
            }
            result.Add(pair.Key, sum / pair.Value.Length);
        }
        return result;
    }
}