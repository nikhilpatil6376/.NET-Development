using System;
public class NullCoalesingOperator
{
    public static void Main(string[] args)
    {
        int AvailableTicket;
        int? TicketOnSale = null;
        AvailableTicket = TicketOnSale ?? 0;
        Console.WriteLine("Available Ticket:{0}", AvailableTicket);
    }
}
