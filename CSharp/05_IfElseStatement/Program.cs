using System;
public class IfElseStatement
{
    public static void Main(string[] args)
    {
        int num1 = 5;
        int num2 = 30;
        int num3 = 20;

        if (num1 > num2)
        {
            Console.WriteLine("{0} is Greater than {1} and {2}", num1, num2, num3);
        }
        else if (num2 >= num3)
        {
            Console.WriteLine("{0} is Greater than {1} and {2}", num2, num1, num3);
        }
        else
        {
            Console.WriteLine("{0} is Greater than {1} and {2}", num3, num1, num2);
        }
    }
}
