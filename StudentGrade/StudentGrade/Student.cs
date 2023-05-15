namespace StudentGrade;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Grade> Grades { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
        Grades = new List<Grade>();
    }

    public void AddGrade(string subject, double score)
    {
        Grade grade = new Grade(subject, score);
        Grades.Add(grade);
    }
}
