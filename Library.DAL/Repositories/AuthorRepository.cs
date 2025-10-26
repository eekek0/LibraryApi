using Library.DAL.Models;

namespace Library.DAL.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly List<Author> _authors = new();

    public IEnumerable<Author> GetAll() => _authors;

    public Author? GetById(int id) => _authors.FirstOrDefault(a => a.Id == id);

    public void Add(Author author)
    {
        author.Id = _authors.Count + 1;
        _authors.Add(author);
    }

    public void Update(Author author)
    {
        var existing = GetById(author.Id);
        if (existing == null) return;
        existing.Name = author.Name;
        existing.DateOfBirth = author.DateOfBirth;
    }

    public void Delete(int id)
    {
        var author = GetById(id);
        if (author != null) _authors.Remove(author);
    }
}
