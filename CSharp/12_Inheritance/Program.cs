using System;
using System.Runtime.CompilerServices;

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void PrintEmployeeDetails()
    {
        Console.WriteLine("Name:{0} {1}", this.FirstName, this.LastName);
    }
}

class FullTimeEmployee : Employee
{
    public int Salary { get; set; }
    public void SalaryE()
    {
        Console.WriteLine("Salary " + this.Salary);
    }
}

class PartTimeEmployee : Employee
{
    public int DaySalary { get; set; }
    public int WorkingDay { get; set; }

    public void SalaryE()
    {
        Console.WriteLine("Salary " + this.DaySalary * this.WorkingDay);
    }
}
public class Inheritance
{
    public static void Main(string[] args)
    {
        FullTimeEmployee FE = new FullTimeEmployee();
        FE.FirstName = "Full";
        FE.LastName = "Time";
        FE.Salary = 100000;
        FE.PrintEmployeeDetails();
        FE.SalaryE();

        PartTimeEmployee PE = new PartTimeEmployee();
        PE.FirstName = "Part";
        PE.LastName = "Time";
        PE.DaySalary = 3000;
        PE.WorkingDay = 10;
        PE.PrintEmployeeDetails();
        PE.SalaryE();


    }
}