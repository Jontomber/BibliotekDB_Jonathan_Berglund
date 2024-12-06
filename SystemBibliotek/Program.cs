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
        Console.WriteLine("Welcome\n");
        int menuSel = 0;
        do
        {
            menuSel = MenuS();
            Menu(menuSel);
        }
        while (menuSel != 7);
    }
    private static int MenuS()
    {
        int menuSel = 0;
        Console.WriteLine("Menu Selection");
        Console.WriteLine("1. Create Book, Aurthor");
        Console.WriteLine("2. Delete Book, Aurthor, Loan");
        Console.WriteLine("3. Loan and return Book");
        Console.WriteLine("4. Update Book, Aurthor");
        Console.WriteLine("5. Add Reltionship to Aurthor and Book.");
        Console.WriteLine("6. List");
        Console.WriteLine("7. Quit");
        try
        {
            menuSel = Convert.ToInt32(Console.ReadLine());
            if (menuSel < 1 || menuSel > 7)
            {
                Console.WriteLine("Select Between 1 - 7");
                Console.ReadLine();
                return MenuS();
            }
        }
        catch
        {
            System.Console.WriteLine("Select between 1 - 7");
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
                Create.Run();
                break;
            case 2:
                Remove.Run();
                break;
            case 3:
                ReturnAndLoan.Run();
                break;
            case 4:
                Update.Run();
                break;
            case 5:
                Relationship.run();
                break;
            case 6:
                List.Run();
                break;
            case 7:
                System.Console.WriteLine("Bye!");
                menuSel = 0;   
                return;
            default:
                System.Console.WriteLine("Invalid input!");
                Console.ReadLine();
                break;
        }
    }
}