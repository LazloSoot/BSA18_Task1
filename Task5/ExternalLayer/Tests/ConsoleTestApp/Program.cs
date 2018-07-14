using System;
using ProjectStructure.Databases.MSSQL;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MSSQLContext context = new MSSQLContext();

            context.Tickets.Add(new ProjectStructure.Domain.Ticket()
            {
                Price = 1000
            });
            Console.ReadLine();
        }
    }
}
