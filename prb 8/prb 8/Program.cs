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