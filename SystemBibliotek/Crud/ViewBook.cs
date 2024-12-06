using System;
using Microsoft.EntityFrameworkCore;
using SystemBibliotek.Models;

public class ViewBook
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            var books = context.Books.Include(b => b.BookAurthors)
                .ThenInclude(b => b.Aurthor)
                .ToList();

            if (books.Any())
            {


                foreach (var book in books)
                {
                    System.Console.WriteLine($"Book Title {book.Title} ");
                    foreach (var aurthor in book.BookAurthors)
                    {
                        System.Console.WriteLine($"Aurthor ID {aurthor.AurthorID} Aurthor Name {aurthor.Aurthor.FirstName} {aurthor.Aurthor.LastName}");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("There is no reltionship ");
            }
        }
    }
}