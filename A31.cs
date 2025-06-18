using System;

class Product
{
    public static int ProductCount = 0;
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
        ProductCount++;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price:C}");
    }
}

class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; } // у місяцях

    public ElectronicProduct(string name, double price, int warrantyPeriod)
        : base(name, price)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Warranty Period: {WarrantyPeriod} months");
    }
}

class ClothingProduct : Product
{
    public string Size { get; set; }

    public ClothingProduct(string name, double price, string size)
        : base(name, price)
    {
        Size = size;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Size: {Size}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product phone = new ElectronicProduct("Smartphone", 699.99, 24);
        Product shirt = new ClothingProduct("T-shirt", 29.99, "M");

        phone.DisplayInfo();
        Console.WriteLine();
        shirt.DisplayInfo();

        Console.WriteLine($"\nTotal products created: {Product.ProductCount}");
    }
}