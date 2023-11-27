using System;
using System.Net.Http.Headers;

public class InputOutputStatement
{
    public static void Main(string[] args)
    {
        int num1 = 5;
        int num2 = 10;
        SwapValueParameter(num1, num2);
        PrintFromMain(num1, num2);

        SwapReferenceParameter(ref num1, ref num2);
        PrintFromMain(num1, num2);

        int sum = 0;
        int product = 0;
        Cal(num1, num2, out sum, out product);
        PrintFromMain(sum, product);

        ParamsMethod(1, 2, 3, 4, 5);
    }

    public static void ParamsMethod(params int[] args)
    {
        int sum = 0;
        int product = 1;
        foreach (int i in args)
        {
            sum += i;
            product *= i; ;
        }
        PrintFromFunction(sum, product);
    }
    public static void Cal(int num1, int num2, out int sum, out int product)
    {
        sum = num1 + num2;
        product = num1 * num2;
    }
    public static void SwapReferenceParameter(ref int num1, ref int num2)
    {
        num1 = num1 + num2;
        num2 = num1 - num2;
        num1 = num1 - num2;
        PrintFromFunction(num1, num2);
    }
    public static void SwapValueParameter(int num1, int num2)
    {
        num1 = num1 + num2;
        num2 = num1 - num2;
        num1 = num1 - num2;
        PrintFromFunction(num1, num2);
    }

    public static void PrintFromFunction(int num1, int num2)
    {
        Console.WriteLine("Print From Function: num1={0} and num2={1}", num1, num2);
    }
    public static void PrintFromMain(int num1, int num2)
    {
        Console.WriteLine("Print From Main: num1={0} and num2={1}", num1, num2);
    }

}