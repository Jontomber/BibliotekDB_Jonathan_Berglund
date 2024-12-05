using SystemBibliotek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Azure.Core.Pipeline;


public class ReturnAndLoan
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nLoan or Return book");
            System.Console.WriteLine("1. Loan Book");
            System.Console.WriteLine("2. Return Book");
            System.Console.WriteLine("3. Go back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddLoans();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "4":
                    System.Console.WriteLine("To go back press any key");
                    Console.ReadLine();
                    return;
            }
        }
    }



    public static void AddLoans()
    {
        using (var context = new AppDbContext())
        {

            System.Console.WriteLine("\n Books Available\n");
            var books = context.Books.Include(ba => ba.BookAurthors) // bo
                .ThenInclude(ba => ba.Aurthor)
                .ToList();

            if (!books.Any())
            {
                Console.WriteLine("There is no books to loan");
                return;
            }

            foreach (var bocks in books)
            {
                Console.WriteLine($"Book ID {bocks.BookID}, Title {bocks.Title} Available {(bocks.ReadyLoan ? "Yes" : "No")}\n");
            }


            Console.Write("Write Lender's Name ");
            var lender = Console.ReadLine();

            Console.Write("Enter Book ID ");
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                Console.WriteLine("Invalid Book ID");
                return;
            }

            var book = context.Books.Find(bookID);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!book.ReadyLoan)
            {
                System.Console.WriteLine("Book not available");
                return;
            }
            var loan = new Loan
            {
                BookID = bookID,
                Signature = lender,
                LoanDate = DateTime.Now,
                Returned = false
            };

            context.Loans.Add(loan);
            context.SaveChanges();

            Console.WriteLine($"Loan added {bookID} Lender {lender}");
        }
    }


    public static void ReturnBook()
    {
        using (var context = new AppDbContext())
        {
            Console.Write("Write Lender's Name ");
            var lender = Console.ReadLine();

            Console.Write("Write BookID to return ");
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                Console.WriteLine("There is no Book ID for this");
                return;
            }

            var loan = context.Loans
                .FirstOrDefault(l => l.Signature == lender && l.BookID == bookID && !l.Returned);

            if (loan == null)
            {
                Console.WriteLine("There is no loan for this lender");
                return;
            }

            loan.Returned = true;
            loan.ReturnDate = DateTime.Now;


            var book = context.Books.Find(bookID);
            if (book != null)
            {
                book.ReadyLoan = true;
            }

            context.SaveChanges();
            Console.WriteLine($"Lender {lender} has returned Book ID {bookID}");
        }
    }
}
