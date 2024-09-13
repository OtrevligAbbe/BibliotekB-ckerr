using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create an instance of the Library class (with default books)
        Library library = new Library();
        int choice;

        // Main program loop
        do
        {
            // Display the menu to the user
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. List Books");
            Console.WriteLine("4. Search Book");
            Console.WriteLine("5. Sort Books");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine()); // Get the user's choice

            // Handle the user's choice based on the menu
            switch (choice)
            {
                case 1:
                    library.AddBook(); // Add a new book
                    break;
                case 2:
                    library.RemoveBook(); // Remove an existing book by title
                    break;
                case 3:
                    library.ListBooks(); // List all books in the library
                    break;
                case 4:
                    library.SearchBook(); // Search for a book by title
                    break;
                case 5:
                    library.SortBooks(); // Sort books alphabetically by title
                    break;
                case 6:
                    Console.WriteLine("Exiting..."); // Exit the program
                    break;
                default:
                    // Handle invalid choices
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 6); // Continue until the user chooses to exit
    }
}

public class Book
{
    // Properties of the Book class
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    // Constructor to initialize a new book with title, author, and year
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    // Override the ToString method to display book information
    public override string ToString()
    {
        return $"{Title} by {Author}, published in {Year}";
    }
}

public class Library
{
    // A list to store books in the library
    private List<Book> books = new List<Book>();

    // Constructor to initialize the library with default books
    public Library()
    {
        // Add "The Lion King" and "Aladdin" to the library when it's created
        books.Add(new Book("The Lion King", "Disney", 1994));
        books.Add(new Book("Aladdin", "Disney", 1992));
    }

    // Method to add a new book to the library
    public void AddBook()
    {
        Console.Write("Enter the book title: ");
        string title = Console.ReadLine(); // Get the title from the user
        Console.Write("Enter the book author: ");
        string author = Console.ReadLine(); // Get the author from the user
        Console.Write("Enter the year of publication: ");
        int year = int.Parse(Console.ReadLine()); // Get the publication year

        // Create a new Book object and add it to the list
        Book newBook = new Book(title, author, year);
        books.Add(newBook);
        Console.WriteLine("Book added successfully.");
    }

    // Method to remove a book from the library by title
    public void RemoveBook()
    {
        Console.Write("Enter the book title to remove: ");
        string title = Console.ReadLine(); // Get the title to remove
        // Find the book that matches the given title (case-insensitive)
        Book bookToRemove = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToRemove != null)
        {
            // If the book is found, remove it from the list
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            // If the book is not found, notify the user
            Console.WriteLine("Book not found.");
        }
    }

    // Method to list all books in the library
    public void ListBooks()
    {
        // Check if there are any books in the library
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
        }
        else
        {
            // Display all books in the library
            Console.WriteLine("Listing all books:");
            foreach (var book in books)
            {
                Console.WriteLine(book); // Use the ToString method of the Book class
            }
        }
    }

    // Method to search for a book by its title
    public void SearchBook()
    {
        Console.Write("Enter the book title to search for: ");
        string title = Console.ReadLine(); // Get the title to search for
        bool bookFound = false;

        // Loop through the list of books to find a match
        foreach (var book in books)
        {
            // If the title matches (case-insensitive), display the book
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Book found: " + book);
                bookFound = true;
                break; // Exit the loop once the book is found
            }
        }

        // If no book was found, notify the user
        if (!bookFound)
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Method to sort the books alphabetically by title
    public void SortBooks()
    {
        // Use the List<T>.Sort() method with the CompareTo() method for alphabetical sorting
        books.Sort((b1, b2) => b1.Title.CompareTo(b2.Title));
        Console.WriteLine("Books sorted alphabetically by title.");
    }
}

