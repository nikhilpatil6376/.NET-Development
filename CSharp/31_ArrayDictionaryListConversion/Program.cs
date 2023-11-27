using System;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}
public class ArrayListDictionaryConversion
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

        //Array
        Customer[] customerArray = new Customer[] { customer1, customer2, customer3, customer4 };

        Console.WriteLine();
        Console.WriteLine("Array->Dictionary");
        Dictionary<int, Customer> customerDictionary = customerArray.ToDictionary(cst => cst.Id, cst => cst);
        foreach (KeyValuePair<int, Customer> kvp in customerDictionary)
        {
            Customer customer = kvp.Value;
            Console.WriteLine("Customer Key={0}: ", kvp.Key);
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("__________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("Array->List");
        List<Customer> customerList = customerArray.ToList();
        foreach (Customer customer in customerList)
        {
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("____________________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("List->Dictionary");
        Dictionary<int, Customer> customerDictionary1 = customerList.ToDictionary(cst => cst.Id, cst => cst);
        foreach (KeyValuePair<int, Customer> kvp in customerDictionary1)
        {
            Customer customer = kvp.Value;
            Console.WriteLine("Customer Key={0}: ", kvp.Key);
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("__________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("Dictionary->List");
        List<Customer> customerList1 = customerDictionary.Select(val=>val.Value).ToList();
        foreach (Customer customer in customerList1)
        {
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
            Console.WriteLine("____________________________________________________");
        }

        Console.WriteLine();
        Console.WriteLine("List->Array");
        Customer[] customerArray1= customerList.ToArray();
        foreach (Customer customer in customerArray1)
        {
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
        }

        Console.WriteLine();
        Console.WriteLine("Dictionary->Array");
        Customer[] customerArray2 = customerDictionary.Select(val => val.Value).ToArray();
        foreach (Customer customer in customerArray2)
        {
            Console.WriteLine("ID:{0} Name:{1} Salary:{2}", customer.Id, customer.Name, customer.Salary);
        }

    }
}