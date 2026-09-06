using System;
class program
{
    static void Main()
    {
        Console.Write("Enter array size:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int max = arr[0];
        for (int i = 1; i < n; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        Console.WriteLine("largest element: " + max);
    }
}