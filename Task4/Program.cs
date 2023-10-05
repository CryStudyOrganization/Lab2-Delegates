using System;
using System.Collections.Generic;

delegate int BookComparison(Book book1, Book book2);

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }

    public Book(string title, string author, string publisher)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
    }
}

class BookCollection
{
    private readonly List<Book> books = new();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void SortBooks(Comparison<Book> comparison)
    {
        books.Sort(comparison);
    }

    public void SortBooks(BookComparison titleComparison)
    {
        books.Sort((book1, book2) => titleComparison(book1, book2));
    }


    public void DisplayBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Назва: {book.Title}, Автор: {book.Author}, Видавництво: {book.Publisher}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BookCollection collection = new BookCollection();

        // Додаємо книги до колекції
        collection.AddBook(new Book("Книга 1", "Автор 1", "Видавництво 1"));
        collection.AddBook(new Book("Книга 2", "Автор 2", "Видавництво 2"));
        collection.AddBook(new Book("Книга 3", "Автор 3", "Видавництво 2"));

        // Сортування за назвою
        Console.WriteLine("Сортування за назвою:");
        BookComparison titleComparison = (book1, book2) => book1.Title.CompareTo(book2.Title);
        collection.SortBooks(titleComparison);
        collection.DisplayBooks();

        // Сортування за автором в зворотньому порядку
        Console.WriteLine("\nСортування за автором (в зворотньому порядку):");
        BookComparison authorComparison = (book1, book2) => book2.Author.CompareTo(book1.Author);
        collection.SortBooks(authorComparison);
        collection.DisplayBooks();

        // Сортування за видавництвом
        Console.WriteLine("\nСортування за видавництвом:");
        BookComparison publisherComparison = (book1, book2) => book1.Publisher.CompareTo(book2.Publisher);
        collection.SortBooks(publisherComparison);
        collection.DisplayBooks();
    }
}
