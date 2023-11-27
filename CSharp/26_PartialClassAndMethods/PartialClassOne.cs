using System;

public partial class PartialClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    partial void Print();

    public void PublicPrint()
    {
        Print();
    }

}
public class PartialClassDemo
{
    public static void Main(string[] args)
    {
        PartialClass obj= new PartialClass();
        obj.FirstName = "Nikhil";
        obj.LastName = "Patil";
        obj.PublicPrint();
    }
}