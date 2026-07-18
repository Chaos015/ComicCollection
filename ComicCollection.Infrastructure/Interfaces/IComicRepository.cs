using ComicCollection.Domain.Entities;

namespace ComicCollection.Infrastructure.Interfaces;

public interface IComicRepository
{
    IEnumerable<Comic> GetAll();

    Comic? GetById(int id);

    void Add(Comic comic);

    void Update(Comic comic);

    void Delete(int id);
}