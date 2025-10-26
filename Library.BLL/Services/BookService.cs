using Library.BLL.DTOs;
using Library.DAL.Models;
using Library.DAL.Repositories;

namespace Library.BLL.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<BookDto> GetAll() =>
        _repository.GetAll().Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            PublishedYear = b.PublishedYear,
            AuthorId = b.AuthorId
        });

    public BookDto? GetById(int id)
    {
        var book = _repository.GetById(id);
        if (book == null) return null;
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            PublishedYear = book.PublishedYear,
            AuthorId = book.AuthorId
        };
    }

    public BookDto Create(BookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            AuthorId = dto.AuthorId
        };
        _repository.Add(book);
        dto.Id = book.Id;
        return dto;
    }

    public bool Update(int id, BookDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing == null) return false;

        existing.Title = dto.Title;
        existing.PublishedYear = dto.PublishedYear;
        existing.AuthorId = dto.AuthorId;
        _repository.Update(existing);
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _repository.GetById(id);
        if (existing == null) return false;
        _repository.Delete(id);
        return true;
    }
}
