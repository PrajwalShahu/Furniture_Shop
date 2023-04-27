using System;

class Furniture
{
    public double Height { get; set; }
    public double Width { get; set; }
    public string Color { get; set; }
    public int Qty { get; set; }
    public double Price { get; set; }

    public virtual void Accept()
    {
        Console.Write("Enter Height: ");
        Height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Width: ");
        Width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Color: ");
        Color = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        Qty = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Price: ");
        Price = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Display()
    {
        Console.WriteLine("Height: {0}", Height);
        Console.WriteLine("Width: {0}", Width);
        Console.WriteLine("Color: {0}", Color);
        Console.WriteLine("Quantity: {0}", Qty);
        Console.WriteLine("Price: {0}", Price);
    }
}

class BookShelf : Furniture
{
    public int NoOfShelves { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter Number of Shelves: ");
        NoOfShelves = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        Console.WriteLine("BookShelf Details:");
        base.Display();
        Console.WriteLine("Number of Shelves: {0}", NoOfShelves);
    }
}

class DiningTable : Furniture
{
    public int NoOfLegs { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter Number of Legs: ");
        NoOfLegs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        Console.WriteLine("DiningTable Details:");
        base.Display();
        Console.WriteLine("Number of Legs: {0}", NoOfLegs);
    }
}

class Program
{
    static void Main()
    {
        Furniture[] stock = new Furniture[2];

        int count = AddToStock(stock);
        Console.WriteLine("{0} furniture details accepted.\n", count);

        double totalValue = TotalStockValue(stock);
        Console.WriteLine("Total stock value: {0}%", totalValue);

        ShowStockDetails(stock);
    }

    static int AddToStock(Furniture[] stock)
    {
        int count = 0;

        while (count < stock.Length)
        {
            Console.WriteLine("Enter furniture {0} details:", count + 1);
            Console.WriteLine("1. BookShelf");
            Console.WriteLine("2. DiningTable");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    stock[count] = new BookShelf();
                    break;

                case 2:
                    stock[count] = new DiningTable();
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
            }

            stock[count].Accept();
            count++;
        }

        return count;
    }

    static double TotalStockValue(Furniture[] stock)
    {
        double totalValue = 0;

        foreach (Furniture item in stock)
        {
            totalValue += (item.Price * item.Qty);
        }

        return totalValue;
    }

    static void ShowStockDetails(Furniture[] stock)
    {
        Console.WriteLine("Stock Details:\n");

        foreach (Furniture item in stock)
        {
            item.Display();
            Console.WriteLine();
        }
    }
}
