namespace SuDungLINQ2;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Department Department { get; set; }
    public Position Position { get; set; }

    public Employee(int id, string name, int age, Department department, Position position)
    {
        Id = id;
        Name = name;
        Age = age;
        Department = department;
        Position = position;
    }
}