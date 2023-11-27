using System;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}
public class ListDemo
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

        List<Customer> customerList=new List<Customer>();

        customerList.Add(customer1);        
        customerList.Add(customer2);
        customerList.Add(customer3);
        customerList.Add(customer4);

        foreach(Customer customer in customerList)
        {
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}",customer.Id,customer.Name,customer.Salary);
            Console.WriteLine("____________________________________________________");
        }
    }
}