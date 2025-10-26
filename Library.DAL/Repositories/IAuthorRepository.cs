using Library.DAL.Models;

namespace Library.DAL.Repositories;

public interface IAuthorRepository
{
    IEnumerable<Author> GetAll();
    Author? GetById(int id);
    void Add(Author author);
    void Update(Author author);
    void Delete(int id);
}
