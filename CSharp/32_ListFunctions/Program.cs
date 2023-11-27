using System;
using System.Collections.ObjectModel;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}
public class ListFunction
{
    public static void Main(string[] args)
    {
        Customer customer1 = new Customer()
        {
            Id = 1,
            Name = "Nikhil",
            Salary = 30000,
        };

        Customer customer2 = new Customer()
        {
            Id = 2,
            Name = "Ajay",
            Salary = 28000,
        };

        Customer customer3 = new Customer()
        {
            Id = 3,
            Name = "Kishor",
            Salary = 25000,
        };
        Customer customer4 = new Customer()
        {
            Id = 4,
            Name = "Aman",
            Salary = 20000,
        };

        List<Customer> customerList = new List<Customer>();

        customerList.Add(customer1);
        customerList.Add(customer2);
        customerList.Add(customer3);
        customerList.Add(customer4);

        Console.WriteLine();
        Console.WriteLine("Add() Function=>");
        foreach (Customer customer in customerList)
        {
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("____________________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("Contain() function=>"); //take element
        if(customerList.Contains(customer1))
        {
            Console.WriteLine("Item is present");
        }
        else
        {
            Console.WriteLine("Item is not present");
        }


        Console.WriteLine();
        Console.WriteLine("Exist() function=>"); //Take condition return true or false
        Console.WriteLine(customerList.Exists(cst => cst.Salary == 30000));

        Console.WriteLine();
        Console.WriteLine("Find() function=>"); //Take condition return first match
        Console.WriteLine(customerList.Find(cst => cst.Salary >20000).Name);

        Console.WriteLine();
        Console.WriteLine("FindLast() function=>"); //Take condition return Last match
        Console.WriteLine(customerList.FindLast(cst => cst.Salary > 20000).Name);

        Console.WriteLine();
        Console.WriteLine("FindAll() function=>"); //Take condition return all possible match as a List
        List<Customer> cst = customerList.FindAll(cst => cst.Salary >= 20000);
        foreach(Customer cust in  cst)
        {
            Console.WriteLine(cust.Name);
        }

        Console.WriteLine();
        Console.WriteLine("FindIndex() function=>"); //Take condition return first match Index
        Console.WriteLine(customerList.FindIndex(cst => cst.Salary > 20000));

        Console.WriteLine();
        Console.WriteLine("FindLastIndex() function=>"); //Take condition return Last match Index
        Console.WriteLine(customerList.FindLastIndex(cst => cst.Salary > 20000));

        Console.WriteLine();
        Console.WriteLine("TrueForAll() function=>"); //Take condition return true if condition match with all element in list
        Console.WriteLine(customerList.TrueForAll(cst => cst.Salary >= 20000));
    }
}   