using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int students = Convert.ToInt32(Console.ReadLine());
        int[][] marks = new int[students][];
        int highestTotal = 0;
        int topStudent = 0;
        for (int i = 0; i < students; i++)
        {
            Console.Write("Enter number of subjects for Student " + (i + 1) + ": ");
            int subjects = Convert.ToInt32(Console.ReadLine());
            marks[i] = new int[subjects];
            int total = 0;
            Console.WriteLine("Enter marks for Student " + (i + 1) + ":");
            for (int j = 0; j < subjects; j++)
            {
                Console.Write("Subject " + (j + 1) + ": ");
                marks[i][j] = Convert.ToInt32(Console.ReadLine());
                total = total + marks[i][j];
            }

            Console.WriteLine("Total Marks of Student " + (i + 1) + ": " + total);
            if (i == 0 || total > highestTotal)
            {
                highestTotal = total;
                topStudent = i + 1;
            }
        }

        Console.WriteLine("\nStudent with Highest Total Marks:");
        Console.WriteLine("Student " + topStudent);
        Console.WriteLine("Total Marks = " + highestTotal);
    }
}