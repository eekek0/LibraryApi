using Library.BLL.DTOs;

namespace Library.BLL.Services;

public interface IAuthorService
{
    IEnumerable<AuthorDto> GetAll();
    AuthorDto? GetById(int id);
    AuthorDto Create(AuthorDto author);
    bool Update(int id, AuthorDto updated);
    bool Delete(int id);
}
