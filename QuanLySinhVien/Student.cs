using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class Student
{
    [Required(ErrorMessage = "Student ID is required.")]
    [RegularExpression(@"^[A-Za-z0-9]+$",
        ErrorMessage = "Student ID can only contain letters and numbers.")]
    public string StudentID { get; set; } = "";

    [Required(ErrorMessage = "Name is required.")]
    [RegularExpression(@"^[\p{L} ]+$",
        ErrorMessage = "Name can only contain letters and spaces.")]
    [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Name must be between 2 and 50 characters.")]
    public string Name { get; set; } = "";

    [Range(0, 10,
        ErrorMessage = "MidPoint must be between 0 and 10.")]
    public double MidPoint { get; set; }

    [Range(0, 10,
        ErrorMessage = "FinalPoint must be between 0 and 10.")]
    public double FinalPoint { get; set; }

    // Calculate grade
    public double Grade
    {
        get
        {
            return (MidPoint + FinalPoint) / 2;
        }
    }

    public Student(
        string studentID,
        string name,
        double midPoint,
        double finalPoint)
    {
        StudentID = studentID;
        Name = name;
        MidPoint = midPoint;
        FinalPoint = finalPoint;
    }

    public void Display()
    {
        Console.WriteLine(
            $"ID: {StudentID} | " +
            $"Name: {Name} | " +
            $"Mid: {MidPoint} | " +
            $"Final: {FinalPoint} | " +
            $"Grade: {Grade:F2}"
        );
    }
}