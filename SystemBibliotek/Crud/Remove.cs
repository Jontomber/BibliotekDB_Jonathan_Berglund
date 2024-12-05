using SystemBibliotek.Models;
using System;
using System.Linq;

public class Remove
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nRemove Book, Aurthor or Loan");
            System.Console.WriteLine("1. Remove Aurthor");
            System.Console.WriteLine("2. Remove Book");
            System.Console.WriteLine("3. Remove Loan");
            System.Console.WriteLine("4. Go back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RemoveAuth();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    RemoveLoan();
                    break;
                case "4":
                    System.Console.WriteLine("To go back press any key");
                    Console.ReadLine();
                    return;
            }
        }
    }

    private static void RemoveLoan()
    {
        using (var context = new AppDbContext())
        {
            var loans = context.Loans.ToList();
            if (!loans.Any())
            {
                System.Console.WriteLine("No loan found");
            }
            else
            {
                foreach (var lend in loans) 
                {
                    System.Console.WriteLine($"Loan ID {lend.LoanID} Loaners Signature {lend.Signature}");
                }
            }

            Console.Write("Write Loan ID to delete");
            if (int.TryParse(Console.ReadLine(), out var loanId))
            {
                var loan = context.Loans.Find(loanId);
                if (loan != null)
                {
                    context.Loans.Remove(loan);
                    context.SaveChanges();
                    Console.WriteLine("Loan has been removed");
                }
                else
                {
                    Console.WriteLine("Loan ID not found.");
                }
            }
        }
    }
    private static void RemoveBook()
    {
        using (var context = new AppDbContext())
        {

            var books = context.Books.ToList();
            if (!books.Any())
            {
                System.Console.WriteLine("No book found");
            }
            else
            {
                foreach (var bock in books) 
                {
                    System.Console.WriteLine($"Book ID {bock.BookID} Title {bock.Title}");
                }
            }

            System.Console.Write("Write book id to delete");
            if (int.TryParse(Console.ReadLine(), out var bookid))
            {
                var book = context.Books.Find(bookid);
                if (book != null)
                {
                    var bookauth = context.BookAurthors.Where(ba => ba.BookID == bookid).ToList();
                    context.BookAurthors.RemoveRange(bookauth);

                    context.Books.Remove(book);
                    context.SaveChanges();
                    System.Console.WriteLine("Book has been removed");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }
    }

    private static void RemoveAuth()
    {
        using (var context = new AppDbContext())
        {
            var aurthors = context.Aurthors.ToList();

            if (!aurthors.Any())
            {
                System.Console.WriteLine("No authors found");
            }
            else
            {
                foreach (var auth in aurthors)
                {
                    System.Console.WriteLine($"Aurthor ID {auth.AurthorID} Firstname {auth.FirstName} Lastname: {auth.LastName}");
                }
            }

            System.Console.Write("Enter aurthor ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out var aurthorID))
            {
                var aurthor = context.Aurthors.Find(aurthorID);
                if (aurthor != null)
                {
                    var bookauth = context.BookAurthors.Where(ba => ba.AurthorID == aurthorID).ToList();
                    context.BookAurthors.RemoveRange(bookauth);

                    context.Aurthors.Remove(aurthor);
                    context.SaveChanges();
                    Console.WriteLine("Aurthor has been deleted");
                }
            }
            else
            {
                Console.WriteLine("Aurthor not found.");
            }
        }
    }
}