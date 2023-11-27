using System;
public class DataTypeConversions
{
    //Implicit: no data loss like int to float
    //Explicit: 1]Type Casting, 2]Convert.ToInt32(int) 3]int.Parse("123"), 4]int.TryParse("abc", out int)

    public static void Main(string[] args)
    {
        int num1 = 5;
        float num2 = num1;
        Console.WriteLine("Implicte Conversion Int to Float: " + num2);

        float num3 = 5.12f;
        int num4 = (int)num3;
        Console.WriteLine("TypeCasting Float to Int: " + num4);

        num4 = Convert.ToInt32(num3);
        Console.WriteLine(num4);


        num4 = Convert.ToInt32("123");
        Console.WriteLine(num4);

        //Through FormatException
        //num4 = Convert.ToInt32("abc");
        //Console.WriteLine(num4);

        num4 = int.Parse("456");
        Console.WriteLine(num4);

        //Through FormatException
        //num4 = int.Parse("abc");
        //Console.WriteLine(num4);


        int Result = 0;
        bool IsConversionSuccessfull = int.TryParse("789", out Result);
        if (IsConversionSuccessfull)
        {
            Console.WriteLine(Result);
        }

        IsConversionSuccessfull = int.TryParse("abc", out Result);
        if (IsConversionSuccessfull)
        {
            Console.WriteLine(Result);
        }

    }
}
