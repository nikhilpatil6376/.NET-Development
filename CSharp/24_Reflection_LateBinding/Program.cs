using System;
using System.Reflection;
namespace Nikhil
{
    public class Customer
    {
        public string GetFullName(string FirstName,string LastName)
        {
            return FirstName + " " + LastName;
        }
    }
    public class ReflectionLateBinding
    {
        public static void Main(string[] args)
        {
            Assembly executingAssbly=Assembly.GetExecutingAssembly();
            Type customerType = executingAssbly.GetType("Nikhil.Customer");
            object customerInstance= Activator.CreateInstance(customerType);
            MethodInfo getMethodName = customerType.GetMethod("GetFullName");

            string[] parameter = new string[2];
            parameter[0] = "Nikhil";
            parameter[1] = "Patil";

            string fullName=(string)getMethodName.Invoke(customerInstance, parameter);
            Console.WriteLine(fullName);

        }

    }
}