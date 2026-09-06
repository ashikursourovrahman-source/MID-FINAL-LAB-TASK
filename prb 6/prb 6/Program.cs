using System;
class Program
{
    static void Main()
    {
        int[,] matrix = new int[3, 3];
        int sum = 0;
        Console.WriteLine("Enter 3x3 matrix elements:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                sum += matrix[i, j];
            }
        }

        Console.WriteLine("Matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Sum of all elements = " + sum);
    }
}