using ComicCollection.Application.Contract;
using ComicCollection.Application.Core;
using ComicCollection.Application.Dtos;
using ComicCollection.Domain.Entities;
using ComicCollection.Infrastructure.Interfaces;

namespace ComicCollection.Application.Services;

public class ComicService : IComicService
{
    private readonly IComicRepository _repository;

    public ComicService(IComicRepository repository)
    {
        _repository = repository;
    }


    public ServiceResult<IEnumerable<ComicDto>> GetAll()
    {
        var comics = _repository.GetAll()
            .Select(c => new ComicDto
            {
                Id = c.Id,
                Name = c.Name,
                Author = c.Author,
                Editorial = c.Editorial,
                PublicationYear = c.PublicationYear,
                Genre = c.Genre
            })
            .ToList();

        return ServiceResult<IEnumerable<ComicDto>>.Ok(comics);
    }


    public ServiceResult<ComicDto> GetById(int id)
    {
        var comic = _repository.GetById(id);

        if (comic == null)
        {
            return ServiceResult<ComicDto>.Fail("Comic not found.");
        }

        var dto = new ComicDto
        {
            Id = comic.Id,
            Name = comic.Name,
            Author = comic.Author,
            Editorial = comic.Editorial,
            PublicationYear = comic.PublicationYear,
            Genre = comic.Genre
        };

        return ServiceResult<ComicDto>.Ok(dto);
    }


    public ServiceResult<ComicDto> Create(ComicDto comic)
    {
        if (string.IsNullOrWhiteSpace(comic.Name))
        {
            return ServiceResult<ComicDto>.Fail("Comic name is required.");
}

        if (string.IsNullOrWhiteSpace(comic.Author))
        {
            return ServiceResult<ComicDto>.Fail("Author is required.");
}

        if (string.IsNullOrWhiteSpace(comic.Editorial))
{
            return ServiceResult<ComicDto>.Fail("Editorial is required.");
}

        if (string.IsNullOrWhiteSpace(comic.Genre))
{
            return ServiceResult<ComicDto>.Fail("Genre is required.");
}

if (comic.PublicationYear.HasValue &&
    (comic.PublicationYear < 1900 || comic.PublicationYear > DateTime.Now.Year))
{
    return ServiceResult<ComicDto>.Fail("Invalid publication year.");
}

        var entity = new Comic
        {
            Name = comic.Name,
            Author = comic.Author,
            Editorial = comic.Editorial,
            PublicationYear = comic.PublicationYear,
            Genre = comic.Genre
        };

        _repository.Add(entity);

        comic.Id = entity.Id;

        return ServiceResult<ComicDto>.Ok(comic);
    }


    public ServiceResult<ComicDto> Update(int id, ComicDto comic)
{
    if (string.IsNullOrWhiteSpace(comic.Name))
    {
        return ServiceResult<ComicDto>.Fail("Comic name is required.");
    }

    if (string.IsNullOrWhiteSpace(comic.Author))
    {
        return ServiceResult<ComicDto>.Fail("Author is required.");
    }

    if (string.IsNullOrWhiteSpace(comic.Editorial))
    {
        return ServiceResult<ComicDto>.Fail("Editorial is required.");
    }

    if (string.IsNullOrWhiteSpace(comic.Genre))
    {
        return ServiceResult<ComicDto>.Fail("Genre is required.");
    }

    if (comic.PublicationYear.HasValue &&
        (comic.PublicationYear < 1900 || comic.PublicationYear > DateTime.Now.Year))
    {
        return ServiceResult<ComicDto>.Fail("Invalid publication year.");
    }


    var existing = _repository.GetById(id);

    if (existing == null)
    {
        return ServiceResult<ComicDto>.Fail("Comic not found.");
    }


    existing.Name = comic.Name;
    existing.Author = comic.Author;
    existing.Editorial = comic.Editorial;
    existing.PublicationYear = comic.PublicationYear;
    existing.Genre = comic.Genre;

    _repository.Update(existing);

    comic.Id = id;

    return ServiceResult<ComicDto>.Ok(comic);
}


    public ServiceResult<bool> Delete(int id)
    {
        var comic = _repository.GetById(id);

        if (comic == null)
        {
            return ServiceResult<bool>.Fail("Comic not found.");
        }

        _repository.Delete(id);

        return ServiceResult<bool>.Ok(true);
    }
}