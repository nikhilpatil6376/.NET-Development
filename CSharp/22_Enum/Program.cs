using System;
using System.Reflection;
using System.Xml.Linq;

public enum Gender
{
    Unkown,
    Male,
    Female,
}
public class EnumDemo
{
    public static void Main(string[] args)
    {
        /*
        int gender = 0;
        switch(gender)
        {
            case 0:
                Console.WriteLine("Unkwon");
                break;
            case 1:
                Console.WriteLine("Male");
                break;
            case 2:
                Console.WriteLine("Female");
                break;
            default:
                Console.WriteLine("Please give valid input");
                break;
        }
        */

        Gender gender=Gender.Male;
        switch (gender)
        {
            case Gender.Unkown:
                Console.WriteLine("Unkwon");
                break;
            case Gender.Male:
                Console.WriteLine("Male");
                break;
            case Gender.Female:
                Console.WriteLine("Female");
                break;
            default:
                Console.WriteLine("Please give valid input");
                break;
        }

        int[] EnumValues = (int[])Enum.GetValues(typeof(Gender));
        string[] EnumNames=Enum.GetNames(typeof(Gender));

        Console.WriteLine();
        Console.WriteLine("*************************");
        foreach(string Name in EnumNames)
        {
            Console.WriteLine(Name);
        }
        Console.WriteLine();
        foreach (int Value in EnumValues)
        {
            Console.WriteLine(Value);
        }
        Console.WriteLine("*************************");
    }
}