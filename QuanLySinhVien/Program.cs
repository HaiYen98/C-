using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Subject subject = new Subject(
            "CSE101",
            "Object Oriented Programming",
            1,
            "Nguyen Van Teacher"
        );

        while (true)
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("       STUDENT MANAGEMENT");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. Find student");
            Console.WriteLine("4. Edit student");
            Console.WriteLine("5. Display students");
            Console.WriteLine("6. Display subject");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================");

            Console.Write("Choose: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddStudent(subject);
                    break;

                case "2":
                    RemoveStudent(subject);
                    break;

                case "3":
                    FindStudent(subject);
                    break;

                case "4":
                    EditStudent(subject);
                    break;

                case "5":
                    subject.DisplayStudents();
                    break;

                case "6":
                    subject.Display();
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
    // ADD STUDENT

    static void AddStudent(Subject subject)
    {
        Console.WriteLine("\n===== ADD STUDENT =====");

        // Student ID
        string id;

        while (true)
        {
            Console.Write("Student ID: ");
            id = (Console.ReadLine() ?? "").Trim();

            if (id == "")
            {
                Console.WriteLine("Error: ID cannot be empty!");
                continue;
            }

            if (!Regex.IsMatch(id, @"^[A-Za-z0-9]+$"))
            {
                Console.WriteLine(
                    "Error: ID can only contain letters and numbers!"
                );
                continue;
            }

            if (subject.FindStudent(id) != null)
            {
                Console.WriteLine("Error: Student ID already exists!");
                continue;
            }

            break;
        }

        // Name
        string name;

        while (true)
        {
            Console.Write("Name: ");
            name = (Console.ReadLine() ?? "").Trim();

            if (name == "")
            {
                Console.WriteLine("Error: Name cannot be empty!");
                continue;
            }

            if (!Regex.IsMatch(name, @"^[\p{L} ]+$"))
            {
                Console.WriteLine(
                    "Error: Name can only contain letters!"
                );
                continue;
            }

            if (name.Length < 2 || name.Length > 50)
            {
                Console.WriteLine(
                    "Error: Name must be between 2 and 50 characters!"
                );
                continue;
            }

            break;
        }

        // Mid Point
        double midPoint = ReadScore("Mid Point");

        // Final Point
        double finalPoint = ReadScore("Final Point");

        Student student = new Student(
            id,
            name,
            midPoint,
            finalPoint
        );

        subject.AddStudent(student);

        Console.WriteLine("\nStudent added successfully!");
        Console.WriteLine($"Grade: {student.Grade:F2}");
    }

    // ==========================================
    // READ SCORE
    // ==========================================
    static double ReadScore(string scoreName)
    {
        while (true)
        {
            Console.Write($"{scoreName}: ");
            string input = (Console.ReadLine() ?? "").Trim();

            // Only numbers or decimal numbers
            if (!Regex.IsMatch(input, @"^\d+(\.\d+)?$"))
            {
                Console.WriteLine(
                    "Error: Please enter a number only!"
                );

                Console.WriteLine(
                    "Example: 8, 8.5, 9.25"
                );

                continue;
            }

            if (!double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double score))
            {
                Console.WriteLine("Error: Invalid number!");
                continue;
            }

            if (score < 0 || score > 10)
            {
                Console.WriteLine(
                    "Error: Score must be between 0 and 10!"
                );

                continue;
            }

            return score;
        }
    }

    // REMOVE STUDENT
    static void RemoveStudent(Subject subject)
    {
        Console.WriteLine("\n===== REMOVE STUDENT =====");

        Console.Write("Enter Student ID: ");
        string id = (Console.ReadLine() ?? "").Trim();

        Student? student = subject.FindStudent(id);

        if (student == null)
        {
            Console.WriteLine("Error: Student not found!");
            return;
        }

        subject.RemoveStudent(id);
    }

    // FIND STUDENT
    static void FindStudent(Subject subject)
    {
        Console.WriteLine("\n===== FIND STUDENT =====");

        Console.Write("Enter Student ID: ");
        string id = (Console.ReadLine() ?? "").Trim();

        Student? student = subject.FindStudent(id);

        if (student == null)
        {
            Console.WriteLine("Student not found!");
        }
        else
        {
            Console.WriteLine("\nStudent found:");
            student.Display();
        }
    }
// EDIT STUDENT
    static void EditStudent(Subject subject)
    {
        Console.WriteLine("\n===== EDIT STUDENT =====");

        Console.Write("Enter Student ID: ");
        string id = (Console.ReadLine() ?? "").Trim();

        Student? student = subject.FindStudent(id);

        if (student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        Console.WriteLine("\nCurrent information:");
        student.Display();

        // Edit Name
        while (true)
        {
            Console.Write("New Name: ");
            string name = (Console.ReadLine() ?? "").Trim();

            if (name == "")
            {
                Console.WriteLine("Error: Name cannot be empty!");
                continue;
            }

            if (!Regex.IsMatch(name, @"^[\p{L} ]+$"))
            {
                Console.WriteLine(
                    "Error: Name can only contain letters!"
                );
                continue;
            }

            if (name.Length < 2 || name.Length > 50)
            {
                Console.WriteLine(
                    "Error: Name must be between 2 and 50 characters!"
                );
                continue;
            }

            student.Name = name;
            break;
        }

        // Edit Mid Point
        student.MidPoint = ReadScore("New Mid Point");

        // Edit Final Point
        student.FinalPoint = ReadScore("New Final Point");

        Console.WriteLine("\nStudent updated successfully!");

        Console.WriteLine("New information:");
        student.Display();
    }
}