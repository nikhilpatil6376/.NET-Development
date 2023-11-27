using System;

class Demo
{
    public void InstanceMethod()
    {
        Console.WriteLine("Instance Method");
    }

    public static void StaticMethod()
    {
        Console.WriteLine("Static Method");
    }
}

public class Methods
{
    public static void Main(string[] args)
    {
        Demo obj = new Demo();
        obj.InstanceMethod();

        Demo.StaticMethod();
    }
}
