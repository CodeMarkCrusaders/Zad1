
public class Student : IEquatable<Student>
{
    // Поля 
    private string _firstName;
    private string _lastName;
    private string _middleName;
    private string _group;
    private string _recordBookNumber;
    private int _course;

    // Свойства
    public string FirstName
    {
        get => _firstName;
        private set => _firstName = value ?? throw new ArgumentNullException(nameof(value), "Имя не может быть null.");
    }

    public string LastName
    {
        get => _lastName;
        private set => _lastName = value ?? throw new ArgumentNullException(nameof(value), "Фамилия не может быть null.");
    }

    public string MiddleName
    {
        get => _middleName;
        private set => _middleName = value ?? throw new ArgumentNullException(nameof(value), "Отчество не может быть null.");
    }

    public string Group
    {
        get => _group;
        private set => _group = value ?? throw new ArgumentNullException(nameof(value), "Группа не может быть null.");
    }

    public string RecordBookNumber
    {
        get => _recordBookNumber;
        private set => _recordBookNumber = value ?? throw new ArgumentNullException(nameof(value), "Номер зачётной книжки не может быть null.");
    }

    public int Course
    {
        get => _course;
        private set
        {
            if (value < 1 || value > 4)
                throw new ArgumentOutOfRangeException(nameof(value), "Курс должен быть в пределах от 1 до 4.");
            _course = value;
        }
    }

    // Конструктор
    public Student(string firstName, string lastName, string middleName, string group, string recordBookNumber, int course)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Group = group;
        RecordBookNumber = recordBookNumber;
        Course = course;
    }

    // Переопределение метода ToString
    public override string ToString()
    {
        return $"{LastName} {FirstName} {MiddleName}, Группа: {Group}, Номер зачётной книжки: {RecordBookNumber}, Курс: {Course}";
    }

    // Реализация интерфейса IEquatable<Student> и переопределение метода Equals
    public bool Equals(Student other)
    {
        if (other == null)
            return false;

        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               MiddleName == other.MiddleName &&
               Group == other.Group &&
               RecordBookNumber == other.RecordBookNumber &&
               Course == other.Course;
    }

    // Переопределение метода GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, MiddleName, Group, RecordBookNumber, Course);
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        try
        {
            var student1 = new Student("Илья", "Южкин", "Хзкович", "202", "123456", 2);
            var student2 = new Student("Даниил", "Александрович", "Чураков", " 202", "654321", 2);

            Console.WriteLine("Информация о студентах:");
            Console.WriteLine(student1);
            Console.WriteLine(student2);

            Console.WriteLine("Равны ли студенты? " + student1.Equals(student2));

            var student3 = new Student("Илья", "Южкин", "Хзкович", "202", "123456", 2);
            Console.WriteLine("Равны ли student1 и student3? " + student1.Equals(student3));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}

