using System;
using PA = ProjectA.A;
using PB = ProjectB.A;
public class NameSpace
{
    public static void Main(string[] args)
    {
        PA.A.method();
        PB.A.method();
    }
}

namespace ProjectA
{
    namespace A
    {
        class A
        {
            public static void method()
            {
                Console.WriteLine("Method From namespace Project A");
            }
        }
    }
}

namespace ProjectB
{
    namespace A
    {
        class A
        {
            public static void method()
            {
                Console.WriteLine("Method From namespace Project B");
            }
        }
    }
}