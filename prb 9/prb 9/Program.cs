using System;

class Employee
{
    public int EmpID;
    public string Name;

    public Employee(int id, string name)
    {
        EmpID = id;
        Name = name;
        Console.WriteLine("Employee ID:" + EmpID);
        Console.WriteLine("Employee Name:" + Name);
    }
}

class ParmanentEmployee : Employee
{
    public double BasicSalary;
    public double Bonus;

    public ParmanentEmployee(int id, string name, double salary, double bonus) : base(id, name)
    {
        BasicSalary = salary;
        Bonus = bonus;
        double TotalSalary = BasicSalary + Bonus;
        Console.WriteLine("Basic Salary:" + BasicSalary);
        Console.WriteLine("Total Bonus:" + Bonus);
        Console.WriteLine("Total Salary:" + TotalSalary);
    }
}

class Program
{
    static void Main()
    {
        ParmanentEmployee p = new ParmanentEmployee(61330, "sourov", 100000, 10000);
    }
}