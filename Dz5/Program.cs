
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Дополнительные задачи");
            Console.WriteLine("1 - Задача 1");
            Console.WriteLine("2 - Задача 2");
            Console.WriteLine("3 - Задача 3");
            Console.WriteLine("4 - Задача 4");
            Console.WriteLine("0 - Выход");
            string choice = Console.ReadLine();
            if (choice == "0") { break; }
            if (choice == "1") { Task1(); }
            if (choice == "2") { Task2(); }
            if (choice == "3") { Task3(); }
            if (choice == "4") { Task4(); }
            Console.WriteLine();
        }
    }

    static void Task1()
    {
        Console.WriteLine("Задача 1. List из 64 картинок, 32 пары, перемешивание.");
        List<string> pictures = new List<string>();
        for (int i = 1; i <= 32; i++)
        {
            pictures.Add("картинка_" + i + ".jpg");
            pictures.Add("картинка_" + i + ".jpg");
        }
        Console.WriteLine("Изначальный List:");
        for (int i = 0; i < pictures.Count; i++)
        {
            Console.WriteLine(i + " - " + pictures[i]);
        }
        Shuffle(pictures);
        Console.WriteLine("Перемешанный List:");
        for (int i = 0; i < pictures.Count; i++)
        {
            Console.WriteLine(i + " - " + pictures[i]);
        }
    }

    static void Shuffle(List<string> list)
    {
        Random random = new Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    static void Task2()
    {
        Console.WriteLine("Задача 2. Студенты группы.");
        Dictionary<string, Student> students = LoadStudents();
        while (true)
        {
            Console.WriteLine("1 - Новый студент");
            Console.WriteLine("2 - Удалить");
            Console.WriteLine("3 - Сортировать");
            Console.WriteLine("4 - Показать");
            Console.WriteLine("0 - Назад");
            string choice = Console.ReadLine();
            if (choice == "0") { break; }
            if (choice == "1")
            {
                Console.Write("Фамилия: ");
                string surname = Console.ReadLine();
                Console.Write("Имя: ");
                string name = Console.ReadLine();
                Console.Write("Год рождения: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Экзамен: ");
                string exam = Console.ReadLine();
                Console.Write("Баллы: ");
                int balls = int.Parse(Console.ReadLine());
                Student student = new Student(surname, name, year, exam, balls);
                students[student.GetKey()] = student;
                SaveStudents(students);
            }
            else if (choice == "2")
            {
                Console.Write("Фамилия: ");
                string surname = Console.ReadLine();
                Console.Write("Имя: ");
                string name = Console.ReadLine();
                students.Remove(surname + " " + name);
                SaveStudents(students);
            }
            else if (choice == "3")
            {
                List<Student> list = new List<Student>(students.Values);
                list.Sort(delegate (Student a, Student b) { return a.Balls.CompareTo(b.Balls); });
                foreach (Student student in list)
                {
                    student.Print();
                }
            }
            else if (choice == "4")
            {
                foreach (KeyValuePair<string, Student> pair in students)
                {
                    pair.Value.Print();
                }
            }
        }
    }

    static Dictionary<string, Student> LoadStudents()
    {
        Dictionary<string, Student> students = new Dictionary<string, Student>();
        string fileName = "students.txt";
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length == 5)
                {
                    Student student = new Student(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]));
                    students[student.GetKey()] = student;
                }
            }
        }
        if (students.Count == 0)
        {
            for (int i = 1; i <= 10; i++)
            {
                Student student = new Student("Фамилия" + i, "Имя" + i, 2005, "Математика", 50 + i);
                students[student.GetKey()] = student;
            }
            SaveStudents(students);
        }
        return students;
    }

    static void SaveStudents(Dictionary<string, Student> students)
    {
        List<string> lines = new List<string>();
        foreach (KeyValuePair<string, Student> pair in students)
        {
            Student student = pair.Value;
            lines.Add(student.Surname + ";" + student.Name + ";" + student.Year + ";" + student.Exam + ";" + student.Balls);
        }
        File.WriteAllLines("students.txt", lines);
    }

    static void Task3()
    {
        Console.WriteLine("Задача 3. Бабули и больницы.");
        Stack<Hospital> hospitals = new Stack<Hospital>();
        hospitals.Push(new Hospital("Городская", new List<string> { "простуда", "грипп", "кашель" }, 3));
        hospitals.Push(new Hospital("Центральная", new List<string> { "давление", "сердце", "суставы" }, 2));
        hospitals.Push(new Hospital("Сельская", new List<string> { "простуда", "давление", "аллергия" }, 4));
        Queue<Grandma> queue = new Queue<Grandma>();
        List<Grandma> allGrandmas = new List<Grandma>();
        List<Grandma> street = new List<Grandma>();
        while (true)
        {
            Console.WriteLine("1 - Добавить бабулю");
            Console.WriteLine("2 - Распределить очередь");
            Console.WriteLine("3 - Показать информацию");
            Console.WriteLine("0 - Назад");
            string choice = Console.ReadLine();
            if (choice == "0") { break; }
            if (choice == "1")
            {
                Console.Write("Имя: ");
                string name = Console.ReadLine();
                Console.Write("Возраст: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Количество болезней: ");
                int count = int.Parse(Console.ReadLine());
                Dictionary<string, string> diseases = new Dictionary<string, string>();
                for (int i = 0; i < count; i++)
                {
                    Console.Write("Болезнь: ");
                    string disease = Console.ReadLine();
                    Console.Write("Лекарство: ");
                    string medicine = Console.ReadLine();
                    diseases[disease] = medicine;
                }
                Grandma grandma = new Grandma(name, age, diseases);
                queue.Enqueue(grandma);
                allGrandmas.Add(grandma);
                Console.WriteLine("Бабуля добавлена в очередь");
            }
            else if (choice == "2")
            {
                while (queue.Count > 0)
                {
                    Grandma grandma = queue.Dequeue();
                    bool placed = false;
                    foreach (Hospital hospital in hospitals)
                    {
                        if (hospital.Patients.Count >= hospital.Capacity) { continue; }
                        if (grandma.Diseases.Count == 0)
                        {
                            hospital.Patients.Add(grandma);
                            placed = true;
                            Console.WriteLine(grandma.Name + " попала в больницу " + hospital.Name);
                            break;
                        }
                        int treated = 0;
                        foreach (string disease in grandma.Diseases.Keys)
                        {
                            if (hospital.Diseases.Contains(disease)) { treated++; }
                        }
                        if (treated * 100 > grandma.Diseases.Count * 50)
                        {
                            hospital.Patients.Add(grandma);
                            placed = true;
                            Console.WriteLine(grandma.Name + " попала в больницу " + hospital.Name);
                            break;
                        }
                    }
                    if (!placed)
                    {
                        street.Add(grandma);
                        Console.WriteLine(grandma.Name + " осталась на улице плакать");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Все бабули:");
                foreach (Grandma grandma in allGrandmas)
                {
                    grandma.Print();
                }
                Console.WriteLine("Больницы:");
                foreach (Hospital hospital in hospitals)
                {
                    hospital.Print();
                }
                Console.WriteLine("На улице:");
                foreach (Grandma grandma in street)
                {
                    Console.WriteLine(grandma.Name);
                }
            }
        }
    }

    static void Task4()
    {
        Console.WriteLine("Задача 4. Кратчайший путь в графе.");
        int[,] graph = {
            { 0, 1, 1, 0, 0, 0 },
            { 1, 0, 0, 1, 1, 0 },
            { 1, 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 1, 1 },
            { 0, 1, 1, 1, 0, 1 },
            { 0, 0, 0, 1, 1, 0 }
        };
        Console.Write("Начальная вершина: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Конечная вершина: ");
        int end = int.Parse(Console.ReadLine());
        int[] path = ShortestPath(graph, start, end);
        if (path == null)
        {
            Console.WriteLine("Путь не найден");
        }
        else
        {
            Console.Write("Путь: ");
            for (int i = 0; i < path.Length; i++)
            {
                Console.Write(path[i]);
                if (i < path.Length - 1) { Console.Write(" -> "); }
            }
            Console.WriteLine();
        }
    }

    static int[] ShortestPath(int[,] graph, int start, int end)
    {
        int n = graph.GetLength(0);
        if (start < 0 || start >= n || end < 0 || end >= n) { return null; }
        bool[] visited = new bool[n];
        int[] parent = new int[n];
        for (int i = 0; i < n; i++) { parent[i] = -1; }
        Queue<int> queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current == end) { break; }
            for (int i = 0; i < n; i++)
            {
                if (graph[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    parent[i] = current;
                    queue.Enqueue(i);
                }
            }
        }
        if (!visited[end]) { return null; }
        List<int> path = new List<int>();
        int vertex = end;
        while (vertex != -1)
        {
            path.Add(vertex);
            if (vertex == start) { break; }
            vertex = parent[vertex];
        }
        path.Reverse();
        return path.ToArray();
    }
}

class Student
{
    public string Surname;
    public string Name;
    public int Year;
    public string Exam;
    public int Balls;

    public Student(string surname, string name, int year, string exam, int balls)
    {
        Surname = surname;
        Name = name;
        Year = year;
        Exam = exam;
        Balls = balls;
    }

    public string GetKey()
    {
        return Surname + " " + Name;
    }

    public void Print()
    {
        Console.WriteLine(Surname + " " + Name + " " + Year + " " + Exam + " " + Balls);
    }
}

class Grandma
{
    public string Name;
    public int Age;
    public Dictionary<string, string> Diseases;

    public Grandma(string name, int age, Dictionary<string, string> diseases)
    {
        Name = name;
        Age = age;
        Diseases = diseases;
    }

    public void Print()
    {
        Console.Write(Name + " " + Age + " болезни: ");
        if (Diseases.Count == 0) { Console.Write("нет"); }
        foreach (KeyValuePair<string, string> pair in Diseases)
        {
            Console.Write(pair.Key + "(" + pair.Value + ") ");
        }
        Console.WriteLine();
    }
}

class Hospital
{
    public string Name;
    public List<string> Diseases;
    public int Capacity;
    public List<Grandma> Patients;

    public Hospital(string name, List<string> diseases, int capacity)
    {
        Name = name;
        Diseases = diseases;
        Capacity = capacity;
        Patients = new List<Grandma>();
    }

    public void Print()
    {
        Console.Write(Name + " болезни: ");
        foreach (string disease in Diseases)
        {
            Console.Write(disease + " ");
        }
        Console.Write("бабуль: " + Patients.Count + "/" + Capacity);
        int percent = Patients.Count * 100 / Capacity;
        Console.WriteLine(" заполненность: " + percent + "%");
    }
}