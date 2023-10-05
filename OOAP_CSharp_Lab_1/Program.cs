using System;

public delegate void PayDelegate(Employee employee);

public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void PaySalary(PayDelegate payDelegate)
    {
        payDelegate(this);
    }
}

public class PayrollSystem
{
    public static void PayForManager(Employee employee)
    {
        employee.Salary = 50000;
        Console.WriteLine($"{employee.Name}, як менеджер, отримує {employee.Salary}.");
    }

    public static void PayForEngineer(Employee employee)
    {
        employee.Salary = 40000;
        Console.WriteLine($"{employee.Name}, як iнженер, отримує {employee.Salary}.");
    }

    public static void PayForAdministrator(Employee employee)
    {
        employee.Salary = 30000;
        Console.WriteLine($"{employee.Name}, як адмiнiстратор, отримує {employee.Salary}.");
    }
}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Введiть кiлькiсть повторiв:");
        int repeat = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < repeat; i++)
        {

            Console.WriteLine("Введiть iм'я працiвника:");
            string name = Console.ReadLine();

            Console.WriteLine("Введiть посаду працiвника (менеджер, iнженер, адмiнiстратор):");
            string position = (Console.ReadLine()).ToLower();


            Employee employee = new Employee(name, position);

            switch (position)
            {
                case "менеджер":
                    employee.PaySalary(PayrollSystem.PayForManager);
                    break;
                case "iнженер":
                    employee.PaySalary(PayrollSystem.PayForEngineer);
                    break;
                case "адмiнiстратор":
                    employee.PaySalary(PayrollSystem.PayForAdministrator);
                    break;
                default:
                    Console.WriteLine("Невiдома посада");
                    break;
            }

        }

    }
}