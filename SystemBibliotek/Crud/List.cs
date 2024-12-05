// using System;
// using Microsoft.EntityFrameworkCore;
// using SystemBibliotek.Models;

// public class ListBook
// {
//     public static void Run()
//     {
//         using(var context = new AppDbContext())
//         {
//             var Books = context.Books.Include(ba => ba.BookAurthors)
//                 .ThenInclude(BookAurthor => BookAurthor.Aurthor)
//                 .ToList();
            
//             foreach (var Book in Books)
//             {
//                 System.Console.WriteLine($"\nBook ID:{Books.BookID} Book Title: {Books.Title}");
//                 foreach (var aurthor in book.BookAurthors)
//                 {
//                     System.Console.WriteLine($"Author ID: {author.Aurthor.ID} Author: {author.Aurthor.FirstName} {author.Aurthor.LastName}");
//                 }
//             }
//         }
//     }
// }