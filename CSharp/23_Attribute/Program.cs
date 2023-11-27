using System;

public class AttributDemo
{
    public static void Main(string[] args)
    {
        Add(5, 5);  ///Outdated Method
        
        Add(new List<int> { 5,5});
        Add(new List<int> { 5, 5,6,7,8 });
    }

    public static void Add(List<int> Numbers)
    {
        int sum = 0;
        foreach (int i in Numbers)
        {
            sum += i;
        }
        Console.WriteLine("Sum:"+sum);
    }

    [Obsolete("Use Add(List <int> Numbers) Method")]
    public static void Add(int num1, int num2)
    {
        int sum = 0;
        sum=num1+ num2;
        Console.WriteLine("Sum:" + sum);
    }
}