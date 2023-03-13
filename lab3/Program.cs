using System;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    private char _gender;
    public char Gender
    {
        get
        {
            return _gender;
        }
        set
        {
            if (value == 'M' || value == 'F')
            {
                _gender = value;
            }
            else
            {
                Console.WriteLine("Error: Invalid gender!");
            }
        }
    }

    public Person()
    {
        FirstName = "";
        LastName = "";
        BirthDate = DateTime.MinValue;
        Gender = 'M';
    }

    public Person(string firstName, string lastName, DateTime birthDate, char gender)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Gender = gender;
    }

    public Person(Person other)
    {
        FirstName = other.FirstName;
        LastName = other.LastName;
        BirthDate = other.BirthDate;
        Gender = other.Gender;
    }

    public void Input()
    {
        Console.Write("Enter first name: ");
        FirstName = Console.ReadLine();
        Console.Write("Enter last name: ");
        LastName = Console.ReadLine();
        Console.Write("Enter birth date (dd.mm.yyyy): ");
        BirthDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter gender (M/F): ");
        Gender = char.Parse(Console.ReadLine());
    }

    public void Output()
    {
        Console.WriteLine($"Name: {LastName} {FirstName}");
        Console.WriteLine($"Birth Date: {BirthDate:d}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Age: {GetAge()}");
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName}, {BirthDate:d}, {Gender}, {GetAge()}";
    }

    public int GetAge()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now < BirthDate.AddYears(age))
        {
            age--;
        }
        return age;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter number of people: ");
        int numPeople = int.Parse(Console.ReadLine());

        Person[] people = new Person[numPeople];

        for (int i = 0; i < numPeople; i++)
        {
            people[i] = new Person();
            Console.WriteLine($"\nEnter data for person {i + 1}:");
            people[i].Input();
        }

        Console.WriteLine("\nData for all people:");
        foreach (Person p in people)
        {
            Console.WriteLine(p.ToString());
        }
    }
}
