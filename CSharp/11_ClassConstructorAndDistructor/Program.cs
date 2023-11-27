using System;
public class ClassConstructorAndDistructor
{
    public static void Main(string[] args)
    {
        A obj = new A(5, 6);
        obj.sum();
    }
}

class A
{
    int num1;
    int num2;

    public void sum()
    {
        Console.WriteLine("Sum of num1 and num2: " + (this.num1 + this.num2));
    }

    public A(int num1, int num2)
    {
        this.num1 = num1;
        this.num2 = num2;
    }

    ~A()
    {
        //release Resourses
    }

}
