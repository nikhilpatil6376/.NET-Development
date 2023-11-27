using System;
using System.Security.Cryptography.X509Certificates;

interface I1
{
    void print();
}

interface I2
{
    void print();
}

class I1I2 : I1, I2
{
    public void print()  //Default Implemention
    {
        Console.WriteLine("Default Implementation");
    }
    void I1.print()  //Explicite Interface Implementation
    {
        Console.WriteLine("InterFace: I1");
    }
}
public class Interface
{
    public static void Main(string[] args)
    {
        I1I2 obj = new I1I2();
        ((I1)obj).print();
        ((I2)obj).print();
    }
}