using System;

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual void PrintEmpName()
    {
        Console.WriteLine(FirstName + " " + LastName + " Employee");
    }
}

class FullTimeEmployee : Employee
{
    public override void PrintEmpName() //Method Overriding
    {
        Console.WriteLine(FirstName + " " + LastName + " Full Time");
    }
}

class PartTimeEmployee : Employee
{
    public override void PrintEmpName() //Method Overriding
    {
        Console.WriteLine(FirstName + " " + LastName + " Part Time");
    }
}

class TemporaryEmployee : Employee
{
    public new void PrintEmpName() //Method Hidding
    {
        Console.WriteLine(FirstName + " " + LastName + " Temporary");
    }
}
public class Polymorphism
{
    public static void Main(string[] args)
    {
        Employee[] emp = new Employee[3];
        emp[0] = new FullTimeEmployee();    //Method Overriding
        emp[1] = new PartTimeEmployee();    //Method Overriding
        emp[2] = new TemporaryEmployee();   //Method Hidding

        foreach (Employee e in emp)
        {
            e.PrintEmpName();
        }

    }
}