using SystemBibliotek.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class Update
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nUpdate Book and Aurthor");
            System.Console.WriteLine("1. Update Book");
            System.Console.WriteLine("2. Update Aurthor");
            System.Console.WriteLine("3. Go back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UpdateBook();
                    break;
                case "2":
                    UpdateAurthor();
                    break;
                case "4":
                    System.Console.WriteLine("To go back press any key");
                    Console.ReadLine();
                    return;
            }
        }
    }


    public static void UpdateBook()
    {
        using (var context = new AppDbContext())
        {
            var Books = context.Books.ToList();
            System.Console.WriteLine("Enter Book ID");
            
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                System.Console.WriteLine("Book ID not found");
            
                foreach (var book in Books)
                {
                    System.Console.WriteLine($"Title {book.Title} BookID {book.BookID}");
                }
                return;
            }

            var updateBook = context.Books.Find(bookID);
            System.Console.WriteLine($"The current Title is: {updateBook.Title}\nEnter a new Title: ");
            var title = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(title))
            {
                updateBook.Title = title;
            }
            context.SaveChanges();
            System.Console.WriteLine($"You've now renamed the book to {title}.");
        }
    }



    public static void UpdateAurthor()
    {
        using (var context = new AppDbContext())
        {
            var Aurthors = context.Aurthors.ToList();
            System.Console.WriteLine("Enter an Author ID: ");
            if (!int.TryParse(Console.ReadLine(), out var aurthorID))
            {
                System.Console.WriteLine("The ID could not be found, please try again!");
                foreach (var aurthor in Aurthors)
                {
                    System.Console.WriteLine($"Author: {aurthor.FirstName} {aurthor.LastName} - ID: {aurthor.AurthorID}");
                }
                return;
            }

            var updateAurthor = context.Aurthors.Find(aurthorID); 
            System.Console.WriteLine($"The current Author name is: {updateAurthor.FirstName} {updateAurthor.LastName}");
            
            var firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName)) 
            {
                updateAurthor.FirstName = firstName;
            }

            var lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
            { 
                updateAurthor.LastName = lastName; 
            }

            context.SaveChanges();
            System.Console.WriteLine($"You've now changed the bio to {firstName} {lastName}.");
        }
    }
}

