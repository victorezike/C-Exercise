using System;
using System.Collections.Generic;
using StudentGrade;

Console.WriteLine("Welcome to the Student Grade Manager!\n");

List<Student> students = new();

bool exitProgram = false;
while (!exitProgram)
{
    PrintMenu();
    int choice = ReadIntegerInput("Enter your choice: ");

    switch (choice)
    {
        case 1:
            AddNewStudent();
            break;
        case 2:
            UpdateStudentGrades();
            break;
        case 3:
            PrintSummaryReport();
            break;
        case 4:
            exitProgram = true;
            break;
        default:
            Console.WriteLine("Invalid option. Please enter a valid option.\n");
            break;
    }
}

void PrintMenu()
{
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add a new student");
    Console.WriteLine("2. Update a student's grades");
    Console.WriteLine("3. Print a summary report");
    Console.WriteLine("4. Exit the program");
    Console.WriteLine();
}

void AddNewStudent()
{
    Console.WriteLine("Add a new student:");

    string name = ReadStringInput("Enter student name: ");
    int age = ReadIntegerInput("Enter student age: ");

    Student student = new(name, age);

    bool addMoreGrades = true;
    while (addMoreGrades)
    {
        string subject = ReadStringInput("Enter subject name: ");
        double score = ReadDoubleInput("Enter subject score: ");

        student.AddGrade(subject, score);

        addMoreGrades = ReadYesNoInput("Do you want to add another subject for this student? (Y/N): ");
    }

    students.Add(student);
    Console.WriteLine("\nStudent added successfully!\n");
}

void UpdateStudentGrades()
{
    Console.WriteLine("Update a student's grades:");

    string name = ReadStringInput("Enter student name: ");
    Student student = FindStudent(name);

    if (student != null)
    {
        Console.WriteLine($"\nCurrent grades for {student.Name}:");
        foreach (Grade grade in student.Grades)
        {
            Console.WriteLine($"{grade.Subject}: {grade.Score}");
        }

        foreach (Grade grade in student.Grades)
        {
            double newScore = ReadDoubleInput($"\nEnter new grade for {grade.Subject}: ");
            grade.Score = newScore;
        }

        Console.WriteLine("\nGrades updated successfully!\n");
    }
    else
    {
        Console.WriteLine("\nStudent not found.\n");
    }
}

void PrintSummaryReport()
{
    Console.WriteLine("\nSummary report:\n");

    foreach (Student student in students)
    {
        Console.WriteLine($"{student.Name} ({student.Age} years old)");

        double totalScore = 0;
        int subjectCount = student.Grades.Count;

        if (subjectCount == 0)
        {
            Console.WriteLine("No grades available for this student.\n");
            continue;
        }

        foreach (Grade grade in student.Grades)
        {
            totalScore += grade.Score;
        }

        double averageScore = totalScore / subjectCount;
        Console.WriteLine($"Average score: {averageScore}\n");
    }
}

string ReadStringInput(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}

int ReadIntegerInput(string prompt)
{
    int value;
    while (!int.TryParse(ReadStringInput(prompt), out value))
    {
        Console.WriteLine("Invalid input. Please enter an integer value.\n");
    }
    return value;
}

double ReadDoubleInput(string prompt)
{
    double value;
    while (!double.TryParse(ReadStringInput(prompt), out value))
    {
        Console.WriteLine("Invalid input. Please enter a numeric value.\n");
    }
    return value;
}

bool ReadYesNoInput(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine()?.Trim().ToLower();

        if (input == "y" || input == "yes")
        {
            return true;
        }
        else if (input == "n" || input == "no")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.\n");
        }
    }
}

Student FindStudent(string name)
{
    foreach (Student student in students)
    {
        if (student.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            return student;
        }
    }
    return null;
}


