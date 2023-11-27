using System;
using System.Runtime.InteropServices;

public class OptionalParameter
{
    public static void Main(string[] args)
    {
        Add1(1, 2);
        Add1(1, 2, 3, 4, 5);
        Console.WriteLine("*************************");

        Add2(1, 2);
        Add2(1, 2, new int[] { 3, 4, 5 });
        Console.WriteLine("*************************");

        Add3(1, 2);
        Add3(1, 2, new int[] { 3, 4, 5 });
        Console.WriteLine("*************************");

        Add4(1, 2);
        Add4(1, 2, new int[] { 3, 4, 5 });
        Console.WriteLine("*************************");

        Add5(1);
        Add5(1, 2, 3);
        Add5(1, num3: 5);
        Console.WriteLine("*************************");
    }
    public static void Add1(int num1, int num2, params int[] args)
    {
        int sum = 0;
        sum = num1 + num2;
        foreach (int i in args)
        {
            sum += i;
        }
        Console.WriteLine("Using Parameters Array: "+sum);
    }

    //2. Default Parameter
    public static void Add2(int num1, int num2, int[] args=null)
    {
        int sum = 0;
        sum = num1 + num2;
        if(args != null)
        {
            foreach (int i in args)
            {
                sum += i;
            }
        }
        Console.WriteLine("Using Default Parameter: " + sum);
    }

    //3.Optional Argument 
    public static void Add3(int num1, int num2, [Optional] int[] args)
    {
        int sum = 0;
        sum = num1 + num2;
        if (args != null)
        {
            foreach (int i in args)
            {
                sum += i;
            }
        }
        Console.WriteLine("Using Default Parameter: " + sum);
    }

    //4.Method Overloading
    public static void Add4(int num1, int num2)
    {
        int sum = 0;
        sum = num1 + num2;
        Console.WriteLine("Using Method Overloading: " + sum);
    }

    public static void Add4(int num1, int num2,int[] args)
    {
        int sum = 0;
        foreach (int i in args)
        {
            sum += i;
        }
        Console.WriteLine("Using Method Overloading: " + sum);
    }

    //5.Named Parameter(Default parameter)
    public static void Add5(int num1, int num2=5,int num3=10)
    {
        int sum = 0;
        sum = num1 + num2+num3;
        Console.WriteLine("Using Named Parameter: " + sum);
    }
}