using System;

abstract class A1
{
    public abstract void print();
    public int Add(params int[] args)
    {
        int sum = 0;
        foreach (int i in args)
        {
            sum += i;
        }
        return sum;
    }
}

class Demo : A1
{
    public override void print()
    {
        Console.WriteLine("Sum:{0}", Add(5, 6));
    }
}

public class AbstractClass
{
    public static void Main(string[] args)
    {
        Demo obj = new Demo();
        obj.print();
    }
}