using System;
using System.IO;

public class ExceptionHandling
{
    public static void Main(string[] args)
    {
        try
        {
            try
            {
                Console.WriteLine("Enter First Number");
                int FirstNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Second Number");
                int SecondNum = Convert.ToInt32(Console.ReadLine());
                int Result = FirstNum / SecondNum;
                Console.WriteLine("Result:{0}", Result);
            }
            catch (Exception e)
            {
                string FilePath = @"C:\Users\Nikhil.Patil\source\repos\Log.txt";
                if (File.Exists(FilePath))
                {
                    StreamWriter sw = new StreamWriter(FilePath);
                    sw.Write(e.GetType().Name);
                    sw.WriteLine();
                    sw.Write(e.Message);
                    sw.Close();
                    Console.WriteLine("There is Problem Try Later");
                }
                else
                {
                    throw new FileNotFoundException(FilePath+" is not present", e);
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Current Exception:{0}",ex.GetType().Name);
            if(ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception:{0}", ex.InnerException.GetType().Name);
            }
        }
    }
}