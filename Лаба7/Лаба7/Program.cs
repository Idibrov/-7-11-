using System;

class Book : IComparable
{
    private string author;
    private string title;
    private int pages;
    private int year;

    public void SetBook(string author, string title, int pages, int year)
    {
        this.author = author;
        this.title = title;
        this.pages = pages;
        this.year = year;
    }

    public void Show()
    {
        Console.WriteLine($"\nКнига:\n Автор: {author}\n Название: {title}\n Год издания: {year}\n {pages} стр.\n");
    }

    public int CompareTo(object obj)
    {
        Book otherBook = (Book)obj;

        if (this.year == otherBook.year) return 0;
        else if (this.year > otherBook.year) return 1;
        else return -1;
    }
}

class Program
{
    static void Main()
    {
        Book[] books = new Book[3];

        books[0] = new Book();
        books[0].SetBook("Автор1", "Название1", 300, 2000);

        books[1] = new Book();
        books[1].SetBook("Автор2", "Название2", 250, 1998);

        books[2] = new Book();
        books[2].SetBook("Автор3", "Название3", 400, 2010);

        Array.Sort(books);

        Console.WriteLine("Отсортированный список книг по году издания:");
        foreach (var book in books)
        {
            book.Show();
        }
    }
}
