using System;
using System.Security.Cryptography.X509Certificates;

public class GenericDemo
{
    public static void Main(string[] args)
    {
        bool Equal = AreEqual<string>("ram","ram");
        if (Equal)
        {
            Console.WriteLine("Values are equal");
        }
        else
        {
            Console.WriteLine("Values are not equal");
        }
    }

    public static bool AreEqual<T>(T value1,T value2)
    {
        return value1.Equals(value2);
    }
}