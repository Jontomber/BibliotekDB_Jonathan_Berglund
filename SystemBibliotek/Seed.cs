using System;
using SystemBibliotek.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore;

public class Seed
{
        public static void Run()
        {
        using (var context = new AppDbContext())
        {
        var transaction = context.Database.BeginTransaction();

                try
                {
                        if (!context.Books.Any() && !context.Aurthors.Any() && !context.BookAurthors.Any())
                        {
                var book1 = new Book
                {
                Title = "Monster",
                PublishDate = new DateOnly(1994, 12, 08),
                ReadyLoan = true
                };

                var book2 = new Book
                {
                Title = "Solo Leveling",
                PublishDate = new DateOnly(2024, 3, 31),
                ReadyLoan = true
                };

                var book3 = new Book
                {
                Title = "Inital D",
                PublishDate = new DateOnly(1995, 11, 6),
                ReadyLoan = true
                };

                var book4 = new Book
                {
                Title = "Hunter x Hunter",
                PublishDate = new DateOnly(1998, 6, 4),
                ReadyLoan = true
                };

                var book5 = new Book
                {
                Title = "One Piece",
                PublishDate = new DateOnly(1997, 7, 22),
                ReadyLoan = true
                };


                var aurthor1 = new Aurthor
                {
                FirstName = "Naoki",
                LastName = "Urasawa",
                };

                var aurthor2 = new Aurthor
                {
                FirstName = "Chugong",
                LastName = "Bankai",
                };

                var aurthor3 = new Aurthor
                {
                FirstName = "Shuichi",
                LastName = "Shigeno",
                };

                var aurthor4 = new Aurthor
                {
                FirstName = "Yoshihiro",
                LastName = "Togashi",
                };

                var aurthor5 = new Aurthor
                {
                FirstName = "Eiichiro",
                LastName = "Oda",
                };

                context.Aurthors.Add(aurthor1);
                context.Aurthors.Add(aurthor2);
                context.Aurthors.Add(aurthor3);
                context.Aurthors.Add(aurthor4);
                context.Aurthors.Add(aurthor5);

                context.Books.Add(book1);
                context.Books.Add(book2);
                context.Books.Add(book3);
                context.Books.Add(book4);
                context.Books.Add(book5);

                context.SaveChanges();

                var bookAurthors = new[]
                {
                        new BookAurthor {Book = book1, Aurthor = aurthor1},
                        new BookAurthor {Book = book2, Aurthor = aurthor2},
                        new BookAurthor {Book = book3, Aurthor = aurthor3},
                        new BookAurthor {Book = book4, Aurthor = aurthor4},
                        new BookAurthor {Book = book5, Aurthor = aurthor5}
                };

                        context.BookAurthors.AddRange(bookAurthors);
                        context.SaveChanges();
                        transaction.Commit();
                        System.Console.WriteLine("Saved");
                }
                else
                {
                        System.Console.WriteLine("Seed has already been deployed");
                }
                }
                        catch (Exception ex)
                        {
                                transaction.Rollback();
                                System.Console.WriteLine("Error" + ex.Message);
                        }
                }
        }
}