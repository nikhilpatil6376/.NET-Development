using System;
public class ArrayDemo
{
    public static void Main(string[] args)
    {
        int[] ar1 = { 1, 2, 3, 4, 5 };
        int[] ar2 = new int[3];
        ar2[0] = 0;
        ar2[1] = 1;
        ar2[2] = 2;

        //for (int i = 0; i <= ar1.Length; i++) //IndexOutOfRangeException
        for (int i = 0; i < ar1.Length; i++)
        {
            Console.Write(ar1[i] + " ");
        }

        Console.WriteLine();

        foreach (int i in ar2)
        {
            Console.Write(i + " ");
        }
    }
}
