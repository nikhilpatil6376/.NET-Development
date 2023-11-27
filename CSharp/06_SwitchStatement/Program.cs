using System;
public class SwitchStatement
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Have You Want To Buy Coffee: 1.Yes  2.No");
        String Order = (Console.ReadLine()).ToUpper();
        int Bill = 0;
        while (Order == "YES")
        {
            Console.WriteLine("Please Select Coffee Size: 1.Large= 50Rs 2.Medium= 40Rs 3.Small= 30Rs");
            String Choise = (Console.ReadLine()).ToUpper();
            switch (Choise)
            {
                case "LARGE":
                    Bill += 50;
                    break;
                case "MEDIUM":
                    Bill += 40;
                    break;
                case "SMALL":
                    Bill += 30;
                    break;
                default:
                    Console.WriteLine("Please Make Valid Choise");
                    break;

            }
            Console.WriteLine("Have You Want To Buy Coffee Again: 1.Yes 2.No");
            Order = (Console.ReadLine()).ToUpper();
        }
        Console.WriteLine("Your Bill is: " + Bill);
        Console.WriteLine("Thank You Vist Again......");
    }
}