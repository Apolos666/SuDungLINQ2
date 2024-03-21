// See https://aka.ms/new-console-template for more information

using SuDungLINQ2;

internal class Program
{
    private static List<Position> positions = new List<Position>
    {
        new Position(1, "Manager", new List<Employee>()),
        new Position(2, "Developer", new List<Employee>()),
        new Position(3, "Tester", new List<Employee>())
    };
    
    private static List<Department> departments = new List<Department>
    {
        new Department(1, "HR", new List<Employee>()),
        new Department(2, "IT", new List<Employee>()),
        new Department(3, "Marketing", new List<Employee>())
    };
    
    private static List<Employee> employees = new List<Employee>
    {
        new Employee(1, "John Doe", 18,departments[1], positions[1]),
        new Employee(2, "Jane Doe", 20,departments[2], positions[2]),
        new Employee(3, "Jim Doe", 25,departments[0], positions[0])
    };
    
    public static void Main(string[] args)
    {
        Setup();

        Console.WriteLine("Enter the name of the employee you want to search:");
        var searchByName = Console.ReadLine();
        var employee = employees.FirstOrDefault(e => e.Name.ToLower().Contains(searchByName.ToLower()));
        Console.WriteLine(employee is not null ? $"Employee found: {employee.Name}" : "Employee not found");
        
        Console.WriteLine("Enter the name of the department you want to search:");
        var searchByDepartment = Console.ReadLine();
        var department = departments.FirstOrDefault(d => d.Name.ToLower().Contains(searchByDepartment.ToLower()));
        Console.WriteLine(department is not null ? $"Department found: {department.Name}" : "Department not found");
        
        Console.WriteLine("Enter the name of the position you want to search:");
        var searchByPosition = Console.ReadLine();
        var position = positions.FirstOrDefault(p => p.Name.ToLower().Contains(searchByPosition.ToLower()));
        Console.WriteLine(position is not null ? $"Position found: {position.Name}" : "Position not found");
        
        Console.WriteLine("Enter the age gap you want to search for");
        Console.WriteLine("Enter the minimum age:");
        var minAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the maximum age:");
        var maxAge = int.Parse(Console.ReadLine());
        var employeesByAge = employees.Where(e => e.Age >= minAge && e.Age <= maxAge).ToList();
        employeesByAge.ForEach(e => Console.WriteLine($"Employee found: {e.Name}, Age: {e.Age}"));
        
        Console.WriteLine("Enter the position name you want to search for:");
        var positionName = Console.ReadLine();
        var employeesByPosition = employees
            .Where(e => e.Position.Name.ToLower().Contains(positionName.ToLower())).ToList();
        if (employeesByPosition.Count == 0)
            Console.WriteLine("No employee found with the given position name");
        else
            employeesByPosition.ForEach(e => Console.WriteLine($"Employee found: {e.Name}, Position: {e.Position.Name}"));
        
        Console.WriteLine("Enter the department name you want to search for:");
        var departmentName = Console.ReadLine();
        var employeesByDepartment = employees
            .Where(e => e.Department.Name.ToLower().Contains(departmentName.ToLower())).ToList();
        if (employeesByDepartment.Count == 0)
            Console.WriteLine("No employee found with the given department name");
        else
            employeesByDepartment.ForEach(e => Console.WriteLine($"Employee found: {e.Name}, Department: {e.Department.Name}"));
        Console.ReadKey();
    }

    private static void Setup()
    {
        foreach (var employee in employees)
        {
            employee.Department.Employees.Add(employee);
            employee.Position.Employees.Add(employee);
        }
    }
}