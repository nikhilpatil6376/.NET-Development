using System;

public delegate void printFunDelagate(string msg);
public delegate void MulticastDelegate();
public class Delegate
{
    public static void Main(string[] args)
    {
        printFunDelagate del = new printFunDelagate(print);
        del("Hello World...");

        MulticastDelegate Mdel = new MulticastDelegate(SampleMethodOne);
        Mdel += SampleMethodTwo;
        Mdel += SampleMethodThree;      //Adding Delegate
        Mdel();
        Mdel -= SampleMethodOne;        //Removing Delagate
        Mdel();
    }

    public static void print(string msg)
    {
        Console.WriteLine(msg);
    }

    public static void SampleMethodOne()
    {
        Console.WriteLine("SampleMethodOne Is Invoked");
    }

    public static void SampleMethodTwo()
    {
        Console.WriteLine("SampleMethodTwo Is Invoked");
    }

    public static void SampleMethodThree()
    {
        Console.WriteLine("SampleMethodThree Is Invoked");
    }

}