using System;
using Microsoft.EntityFrameworkCore.Storage.Json;
using SystemBibliotek.Models;

public class Create
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nCreate Book or Aurthor");
            System.Console.WriteLine("1. Create Book");
            System.Console.WriteLine("2. Create Aurthor");
            System.Console.WriteLine("3. Go back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    AddAurthor();
                    break;
                case "4":
                    System.Console.WriteLine("To go back press any key");
                    Console.ReadLine();
                    return;
            }
        }
    }
    public static void AddBook()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("Add a new Book to List Test");

            System.Console.WriteLine("Enter Title");
            var _title = Console.ReadLine()?.Trim();

            System.Console.WriteLine("Enter Release Date Test YYYY MM DD need blank spaces between numbers");
            var _publishDate = Console.ReadLine();
            if (!DateOnly.TryParse(_publishDate, out DateOnly publishDate))
            {
                System.Console.WriteLine("Invalid Input, try again test");
                return;
            }

            System.Console.WriteLine("Ready to loan");
            bool _readyLoan = true;

            var _book = new Book
            {
                Title = _title,
                PublishDate = publishDate,
                ReadyLoan = _readyLoan
            };
            context.Books.Add(_book);
            context.SaveChanges();
            System.Console.WriteLine($"{_title} Has been added"); 
        }
    }


    public static void AddAurthor()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nAdd a new Aurthor\n");
            Console.ResetColor();

            System.Console.WriteLine("Enter a First Name: ");
            var _firstName = Console.ReadLine()?.Trim();
            System.Console.WriteLine("Enter a Last Name: ");
            var _lastName = Console.ReadLine()?.Trim();

            var _aurthor = new Aurthor 
            {
                FirstName = _firstName,
                LastName = _lastName,
            };

            context.Aurthors.Add(_aurthor);
            context.SaveChanges();
            System.Console.WriteLine($"{_firstName} {_lastName} Has been added\n");
        }
    }
}