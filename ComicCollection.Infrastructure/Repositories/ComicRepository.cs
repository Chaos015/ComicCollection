using ComicCollection.Domain.Entities;
using ComicCollection.Infrastructure.Interfaces;

namespace ComicCollection.Infrastructure.Repositories;

public class ComicRepository : IComicRepository
{
    private readonly List<Comic> _comics = new()
    {
        new Comic
        {
            Id = 1,
            Name = "Batman: The Killing Joke",
            Author = "Alan Moore",
            Editorial = "DC Comics",
            PublicationYear = 1988,
            Genre = "Super Heroes"
        },

        new Comic
        {
            Id = 2,
            Name = "Spider-Man: Blue",
            Author = "Jeph Loeb",
            Editorial = "Marvel Comics",
            PublicationYear = 2002,
            Genre = "Super Heroes"
        },

        new Comic
        {
            Id = 3,
            Name = "Saga Vol. 1",
            Author = "Brian K. Vaughan",
            Editorial = "Image Comics",
            PublicationYear = 2012,
            Genre = "Science Fiction"
        }
    };


    public IEnumerable<Comic> GetAll()
    {
        return _comics;
    }


    public Comic? GetById(int id)
    {
        return _comics.FirstOrDefault(c => c.Id == id);
    }


    public void Add(Comic comic)
    {
        int newId = _comics.Any()
            ? _comics.Max(c => c.Id) + 1
            : 1;

        comic.Id = newId;

        _comics.Add(comic);
    }


    public void Update(Comic comic)
    {
        var existing = GetById(comic.Id);

        if (existing != null)
        {
            existing.Name = comic.Name;
            existing.Author = comic.Author;
            existing.Editorial = comic.Editorial;
            existing.PublicationYear = comic.PublicationYear;
            existing.Genre = comic.Genre;
        }
    }


    public void Delete(int id)
    {
        var comic = GetById(id);

        if (comic != null)
        {
            _comics.Remove(comic);
        }
    }
}