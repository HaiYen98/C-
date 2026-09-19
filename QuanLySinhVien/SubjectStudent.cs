using System;
using System.Collections.Generic;

public class Subject
{
    public string SubjectID { get; set; } = "";
    public string Name { get; set; } = "";
    public int Semester { get; set; }
    public string Teacher { get; set; } = "";

    public List<Student> Students { get; set; }

    public Subject(
        string subjectID,
        string name,
        int semester,
        string teacher)
    {
        SubjectID = subjectID;
        Name = name;
        Semester = semester;
        Teacher = teacher;

        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (FindStudent(student.StudentID) != null)
        {
            Console.WriteLine("Student already exists!");
            return;
        }

        Students.Add(student);
        Console.WriteLine("Student added successfully!");
    }

    public void RemoveStudent(string studentID)
    {
        Student? student = FindStudent(studentID);

        if (student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        Students.Remove(student);
        Console.WriteLine("Student removed successfully!");
    }

    public Student? FindStudent(string studentID)
    {
        foreach (Student student in Students)
        {
            if (student.StudentID == studentID)
            {
                return student;
            }
        }

        return null;
    }

    public void DisplayStudents()
    {
        if (Students.Count == 0)
        {
            Console.WriteLine("No students in this subject.");
            return;
        }

        Console.WriteLine("\n===== STUDENT LIST =====");

        foreach (Student student in Students)
        {
            student.Display();
        }
    }

    public void Display()
    {
        Console.WriteLine("\n================================");
        Console.WriteLine($"Subject ID: {SubjectID}");
        Console.WriteLine($"Subject Name: {Name}");
        Console.WriteLine($"Semester: {Semester}");
        Console.WriteLine($"Teacher: {Teacher}");
        Console.WriteLine($"Number of students: {Students.Count}");

        DisplayStudents();
    }
}