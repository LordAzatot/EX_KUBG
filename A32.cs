using System;

// Абстрактний клас Document
abstract class Document
{
    public abstract void Print();

    public void PrepareForPrinting()
    {
        Console.WriteLine("Preparing document for printing...");
        Print();
    }
}

// Конкретні реалізації документів
class PDFDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing PDF document");
    }
}

class WordDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing Word document");
    }
}

class ExcelDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing Excel document");
    }
}

// Фабрика документів
class DocumentFactory
{
    public static Document CreateDocument(string type)
    {
        switch (type.ToLower())
        {
            case "pdf":
                return new PDFDocument();
            case "word":
                return new WordDocument();
            case "excel":
                return new ExcelDocument();
            default:
                throw new ArgumentException("Unknown document type");
        }
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        Document pdf = DocumentFactory.CreateDocument("pdf");
        Document word = DocumentFactory.CreateDocument("word");
        Document excel = DocumentFactory.CreateDocument("excel");

        pdf.PrepareForPrinting();
        Console.WriteLine();
        word.PrepareForPrinting();
        Console.WriteLine();
        excel.PrepareForPrinting();
    }
}