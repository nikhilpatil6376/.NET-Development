using System;
public class Loops
{
    public static void Main(string[] args)
    {
        int num = 10;
        for (int i = 1; i <= num; i++)
        {
            System.Console.Write(i + " ");
        }
        System.Console.WriteLine();

        int j = 1;
        while (j <= num)
        {
            System.Console.Write(j + " ");
            j++;
        }
        Console.WriteLine();

        int k = 1;
        do
        {
            System.Console.Write(k + " ");
            k++;
        } while (k <= num);

    }
}

