namespace SuDungLINQ2;

public class Position
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }

    public Position(int id, string name, List<Employee> employees)
    {
        Id = id;
        Name = name;
        Employees = employees;
    }
}