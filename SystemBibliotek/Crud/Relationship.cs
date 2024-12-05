using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using SystemBibliotek.Models;

public class Relationship
{
    public static void run()
    {
        using (var context = new AppDbContext())
        {
            var books = context.Books.ToList();

            if(books.Any())
            {
            foreach (var book in books)
            {
                System.Console.WriteLine($"Book ID {book.BookID} Title {book.Title}");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no book");
            } 

        var Aurthors = context.Aurthors.ToList();
        
            if(Aurthors.Any())
            {
            foreach (var aurthor in Aurthors)
            {
                System.Console.WriteLine($"Aurthor ID {aurthor.AurthorID} Name {aurthor.FirstName} {aurthor.LastName}");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no aurthor");
            } 


            System.Console.Write("Enter Book ID ");

            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                System.Console.WriteLine("Invalid BookID");
            }

            System.Console.Write("Enter Aurthor ID ");

            if (!int.TryParse(Console.ReadLine(), out var aurthorID))
            {
                System.Console.WriteLine("Invalid Aurthor ID");
            }

            var bookAurthor = new BookAurthor
            {
                BookID = bookID, AurthorID = aurthorID
            };

            context.BookAurthors.Add(bookAurthor);
            context.SaveChanges();
            System.Console.WriteLine("Saved succesfully");
            
        }
    }
}