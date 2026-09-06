using System;

class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Student : Person
{
    public int StudentID;

    public Student(string name, int age, int id) : base(name, age)
    {
        StudentID = id;
    }

    public void Display()
    {
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("Age : " + Age);
        Console.WriteLine("Student ID : " + StudentID);
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student("sourov", 21, 61330);

        Console.WriteLine();
        s.Display();
    }
}
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
using System;

namespace VehicleManagementSystem
{
    class Vehicle
    {
        public virtual void Start()
        {
            Console.WriteLine("Vehicle is starting...");
        }
    }

    class Car : Vehicle
    {
        public sealed override void Start()
        {
            Console.WriteLine("Car starting with key ignition.");
        }
    }

    class Bike : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Bike starting with kick.");
        }
    }

    class Truck : Vehicle
    {
        public new void Start()
        {
            Console.WriteLine("Truck starting with start button .");
        }
    }

    class SportsCar : Car
    {
        /*  public override void start()
        {
            Console.WriteLine("sportscar is starting with turbo");
        }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myVehicle;

            myVehicle = new Car();
            myVehicle.Start();

            myVehicle = new Bike();
            myVehicle.Start();

            Truck myTruck = new Truck();
            Vehicle vehicleRefToTruck = myTruck;

            myTruck.Start();
            vehicleRefToTruck.Start();

            SportsCar mySportsCar = new SportsCar();
            mySportsCar.Start();

            Console.ReadKey();
        }
    }
