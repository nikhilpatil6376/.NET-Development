using System;
using System.Security.Cryptography.X509Certificates;

public class Employee
{
    public int EmployeeID {  get; set; }
    public string EmployeeName { get; set; }
    public int EmployeeAge { get; set; }

    public string Gender { get; set; }
}

public class Company
{
    List<Employee> EmployeeList;

    public Company()
    {
        EmployeeList = new List<Employee>();
        EmployeeList.Add(new Employee() { EmployeeID = 1, EmployeeName = "Nikhil", EmployeeAge = 21, Gender="Male" });
        EmployeeList.Add(new Employee() { EmployeeID = 2, EmployeeName = "Ram", EmployeeAge = 25, Gender = "Male" });
        EmployeeList.Add(new Employee() { EmployeeID = 3, EmployeeName = "Nayana", EmployeeAge = 31, Gender = "Female" });
        EmployeeList.Add(new Employee() { EmployeeID = 4, EmployeeName = "Amrita", EmployeeAge = 35, Gender = "Female" });
        EmployeeList.Add(new Employee() { EmployeeID = 5, EmployeeName = "Rajesh", EmployeeAge = 39, Gender = "Male" });

    }

    public string this[int EmpId]
    {
        get
        {
            return EmployeeList.FirstOrDefault(emp => emp.EmployeeID == EmpId).EmployeeName;
        }
        set
        {
            EmployeeList.FirstOrDefault(emp => emp.EmployeeID == EmpId).EmployeeName = value;
        }
    }

    //Indexer Overloadding
    public int this[string Gender]
    {
        get
        {
            return EmployeeList.Count(emp=> emp.Gender==Gender);
        }
    }
}

public class Indexer
    {
        public static void Main(string[] args)
        {
        Company company = new Company();
        Console.WriteLine("Name of Employee with ID=1: " + company[1]);
        Console.WriteLine("Name of Employee with ID=2: " + company[2]);
        Console.WriteLine("Name of Employee with ID=3: " + company[3]);
        Console.WriteLine("Name of Employee with ID=4: " + company[4]);
        Console.WriteLine("Name of Employee with ID=5: " + company[5]);

        Console.WriteLine("************************************");

        company[1] = "Nikhil Patil";
        Console.WriteLine("Name of Employee with ID=1 Changed: " + company[1]);
        company[2] = "Ram Chaudhari";
        Console.WriteLine("Name of Employee with ID=2 Changed: " + company[2]);

        Console.WriteLine("************************************");
        //Indexer Ovrloading
        Console.WriteLine("Employee Count with Gender Male: " + company["Male"]);
        Console.WriteLine("Employee Count with Gender Female: " + company["Female"]);

    }
 }