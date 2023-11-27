using System;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}
public class DictionaryDemo
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

        Dictionary<int, Customer > dictionaryCustomer= new Dictionary<int, Customer>();

        dictionaryCustomer.Add(customer1.Id, customer1);
        dictionaryCustomer.Add(customer2.Id, customer2);    
        dictionaryCustomer.Add(customer3.Id, customer3);
        dictionaryCustomer.Add(customer4.Id, customer4);
        
        foreach(KeyValuePair<int, Customer> kvp in dictionaryCustomer)
        {
            Customer customer= kvp.Value;
            Console.WriteLine("Customer Key={0}: ", kvp.Key);
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id,customer.Name, customer.Salary);
            Console.WriteLine("__________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("Dictionary After Remove() operation");
        dictionaryCustomer.Remove(1);
        foreach (KeyValuePair<int, Customer> kvp in dictionaryCustomer)
        {
            Customer customer = kvp.Value;
            Console.WriteLine("Customer Key={0}: ", kvp.Key);
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("__________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("Dictionary After Clear Operation");
        dictionaryCustomer.Clear();
        foreach (KeyValuePair<int, Customer> kvp in dictionaryCustomer)
        {
            Customer customer = kvp.Value;
            Console.WriteLine("Customer Key={0}: ", kvp.Key);
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("__________________________________________");
        }
    }
}