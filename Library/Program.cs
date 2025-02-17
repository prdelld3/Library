using System;
using System.Collections.Generic;

class Book
{
    public string Title;
    public int YearPublished;

    public Book(string title, int yearPublished)
    {
        Title = title;
        YearPublished = yearPublished;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        List<Book> bookList = new List<Book>();

        while (isRunning)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t  Library"
                + "\n\t  [1] Register New Book"
                + "\n\t  [2] Books in Library"
                + "\n\t  [3] Exit");
            Console.ResetColor();

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        RegisterNewBook(bookList);
                        break;

                    case 2:
                        DisplayBooksInLibrary(bookList);
                        break;

                    case 3:
                        isRunning = false;
                        break;

                    default:
                        ErrorMessage("Invalid menu choice");
                        break;
                }
            }
            else
            {
                ErrorMessage("Invalid input. Please enter a number.");
            }
        }
    }

    static void RegisterNewBook(List<Book> bookList)
    {
        Console.Clear();
        Console.WriteLine("Enter the title of the book:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the year of first publication:");
        if (int.TryParse(Console.ReadLine(), out int yearPublished))
        {
            title = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
            Book book = new Book(title, yearPublished);
            bookList.Add(book);
            Console.WriteLine("Book registered successfully.");
            Console.ReadLine();
        }
        else
        {
            ErrorMessage("Invalid year. Please enter a valid integer.");
        }
    }

    static void DisplayBooksInLibrary(List<Book> bookList)
    {
        Console.Clear();
        if (bookList.Count > 0)
        {
            Console.WriteLine("Books in Library:");
            foreach (Book book in bookList)
            {
                Console.WriteLine($"{book.Title} ({book.YearPublished})");
            }
            Console.WriteLine($"\nTotal books in library: {bookList.Count}");
        }
        else
        {
            ErrorMessage("No books registered in the library.");
        }
        Console.ReadLine();
    }

    static void ErrorMessage(string message)
    {
        Console.Clear();
        Console.WriteLine($"Error: {message}");
        Console.ReadLine();
    }
}
