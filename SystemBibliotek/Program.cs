﻿using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SystemBibliotek.Models;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Hey test");
        int menuSel = 0;
        do
        {
            menuSel = MenuS();
            Menu(menuSel);
        }
        while (menuSel != 9);
    }
    private static int MenuS()
    {
        int menuSel = 0;
        Console.WriteLine("Menu Test");
        System.Console.WriteLine("1. Create Book");
        System.Console.WriteLine("2. Create Aurthor");
        System.Console.WriteLine("3. Delete Book, Aurthor");
        System.Console.WriteLine("4. Loan Book");
        System.Console.WriteLine("5. Return Book");
        System.Console.WriteLine("6. Update Book, Aurthor");
        System.Console.WriteLine("7. Add Reltionship to Aurthor and Book.");
        System.Console.WriteLine("8. List");
        System.Console.WriteLine("9. Quit");
        try
        {
            menuSel = Convert.ToInt32(Console.ReadLine());
            if (menuSel < 1 || menuSel > 9)
            {
                Console.WriteLine("Select Between 1 - 9 Test");
                Console.ReadLine();
                return MenuS();
            }
        }
        catch
        {
            System.Console.WriteLine("Select between 1 - 9 Test");
            Console.ReadLine();
            return MenuS(); 
        }
        return menuSel;
    }
    private static void Menu(int menuSel)
    {
        switch (menuSel)
        {
            case 1:
                AddBook.Run();
                break;
            case 2:
                AddAurthor.Run();
                break;
            // case 3:
            //     Remove.Run();
            //     break;
            // case 4:
            //     LoanBook.Run();
            //     break;
            // case 5:
            //     ReturnBook.Run();
            //     break;
            // case 6:
            //     Update.Run();
            //     break;
            // case 7:
            //     SetRelationship.Run();
            //     break;
            // case 8:
            //     List.Run();
            //     break;
            // case 9:
            //     System.Console.WriteLine("Bye Test");
            //     menuSel = 0;   
            //     return;
            default:
                System.Console.WriteLine("Invalid input test");
                Console.ReadLine();
                break;
        }
    }
}