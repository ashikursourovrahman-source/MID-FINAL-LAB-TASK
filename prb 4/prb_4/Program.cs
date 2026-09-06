using System;
namespace prb_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            int sum = 0;
            int i = 1;

            Console.Write("Enter N: ");
            N = Convert.ToInt32(Console.ReadLine());

            while (i <= N)
            {
                sum += i;
                i++;
            }

            Console.WriteLine("Sum of numbers from 1 to " + N + ": " + sum);
        }
    }
}