using System;
public class MethodOverloding
{
    public static void Main(string[] args)
    {
        Add(5, 5);
        Add(1, 5, 7);
        Add(5.2, 5.3);
    }

    public static void Add(int num1, int num2)
    {
        int sum = 0;
        sum = num1 + num2;
        Console.WriteLine("Sum of two number is: " + sum);
    }

    public static void Add(int num1, int num2, int num3)
    {
        int sum = 0;
        sum = num1 + num2 + num3;
        Console.WriteLine("Sum of three number is: " + sum);
    }

    public static void Add(double num1, double num2)
    {
        double sum = 0;
        sum = num1 + num2;
        Console.WriteLine("Sum of two floating number is: " + sum);
    }
}