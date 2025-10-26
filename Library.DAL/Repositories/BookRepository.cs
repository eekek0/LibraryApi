using Library.DAL.Models;

namespace Library.DAL.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new();

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var existing = GetById(book.Id);
        if (existing == null) return;
        existing.Title = book.Title;
        existing.PublishedYear = book.PublishedYear;
        existing.AuthorId = book.AuthorId;
    }

    public void Delete(int id)
    {
        var book = GetById(id);
        if (book != null) _books.Remove(book);
    }
}
