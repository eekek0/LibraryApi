using Library.BLL.DTOs;
using Library.DAL.Models;
using Library.DAL.Repositories;

namespace Library.BLL.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<AuthorDto> GetAll() =>
        _repository.GetAll().Select(a => new AuthorDto
        {
            Id = a.Id,
            Name = a.Name,
            DateOfBirth = a.DateOfBirth
        });

    public AuthorDto? GetById(int id)
    {
        var author = _repository.GetById(id);
        if (author == null) return null;
        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }

    public AuthorDto Create(AuthorDto dto)
    {
        var author = new Author
        {
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth
        };
        _repository.Add(author);
        dto.Id = author.Id;
        return dto;
    }

    public bool Update(int id, AuthorDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing == null) return false;

        existing.Name = dto.Name;
        existing.DateOfBirth = dto.DateOfBirth;
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
