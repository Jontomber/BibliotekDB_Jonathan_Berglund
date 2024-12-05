﻿using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using SystemBibliotek.Models;

class MainProgram
{
    

    static void Main(string[] args)
    {   
        Seed.Run();
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
        Console.WriteLine("1. Create Book");
        Console.WriteLine("2. Create Aurthor");
        Console.WriteLine("3. Delete Book, Aurthor, Loan");
        Console.WriteLine("4. Loan and return Book");
        Console.WriteLine("5. Update Book, Aurthor");
        Console.WriteLine("6. Add Reltionship to Aurthor and Book.");
        Console.WriteLine("7. List");
        Console.WriteLine("8. Quit");
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
            case 3:
                Remove.Run();
                break;
            case 4:
                ReturnAndLoan.Run();
                break;
            case 5:
                Update.Run();
                break;
            case 6:
                Relationship.run();
                break;
            case 7:
                List.Run();
                break;
            case 8:
                System.Console.WriteLine("Bye Test");
                menuSel = 0;   
                return;
            default:
                System.Console.WriteLine("Invalid input test");
                Console.ReadLine();
                break;
        }
    }
}