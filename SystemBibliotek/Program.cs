class menu
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Vad vill du göra");
        System.Console.WriteLine("1. Lägg till Bok");
        System.Console.WriteLine("2. Låna bok");
        System.Console.WriteLine("3. Lämna tillbaka bok ");

        var input = Console.ReadLine();

        // if (input == "1")
        // {
        //     AddData.Run();
        // }
        // else if (input == "2")
        // {
        //     ReadData.Run();
        // }
        // else
        // {
        //     System.Console.WriteLine("Ogiltigt");
        // }
    }
}