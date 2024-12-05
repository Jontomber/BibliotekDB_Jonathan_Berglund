using System;
using Microsoft.EntityFrameworkCore;
using SystemBibliotek.Models;

public class List
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            while (true)
            {
                System.Console.WriteLine("View List");
                System.Console.WriteLine("Do you want to view list Yes/No");
                var _input = Console.ReadLine();
                if (_input == "No")
                {
                    System.Console.WriteLine("Press any key to come back to menu");
                    Console.ReadLine();
                    return;
                }
                
                else if (_input == "Yes")
                {
                    System.Console.WriteLine("\n1. View List book.");
                    System.Console.WriteLine("2. View list Loan");
                    System.Console.WriteLine("3. View relationship");
                    System.Console.WriteLine("4. Go to menu.");
                

                    var _menuInput = Console.ReadLine();
                    switch (_menuInput)
                    {
                        case "1":
                            ListBook.Run();
                            break;
                        case "2":
                            ListLoan.Run();
                            break;
                        case "3":
                            ViewBook.Run();
                            break;
                        case "4":
                            System.Console.WriteLine("To go back press any key");
                            Console.ReadLine();
                            return;
                        default:
                            System.Console.WriteLine("Select between 1 - 4");  
                            Console.ReadLine();                      
                            break; 
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid input, put 1 - 4");
                    Console.ReadLine();       
                }
            }
        }
    }

public class ListBook
{
    public static void Run()
    {
        using(var context = new AppDbContext())
        {
            var Books = context.Books.Include(ba => ba.BookAurthors)
                .ThenInclude(BookAurthor => BookAurthor.Aurthor)
                .ToList();
            
            foreach (var Book in Books)
            {
                System.Console.WriteLine($"\nBook ID {Book.BookID} Book Title {Book.Title} {Book.PublishDate}");
                foreach (var aurthor in Book.BookAurthors)
                {
                    System.Console.WriteLine($"Author ID {aurthor.AurthorID} Author {aurthor.Aurthor.FirstName} {aurthor.Aurthor.LastName}");
                }
            }
        }
    }
}
    public class ListLoan
    {
        public static void Run()
        {

            using (var context = new AppDbContext())
            {
                var loans = context.Loans.Include(l => l.Book)
                    .Where(l => l.Returned == false)
                    .ToList();

                if (!loans.Any())
                {
                    System.Console.WriteLine("There are no loan books");
                }
                else
                {
                    foreach (var loan in loans)
                    {
                        System.Console.WriteLine($"\nBook: {loan.Book.Title}");
                        System.Console.WriteLine($"Signature: {loan.Signature}");
                        System.Console.WriteLine($"Is returned: {loan.Returned}");
                    }

                }
            }
        }
    }
}