using ComicCollection.Application.Core;
using ComicCollection.Application.Dtos;

namespace ComicCollection.Application.Contract;

public interface IComicService
{
    ServiceResult<IEnumerable<ComicDto>> GetAll();

    ServiceResult<ComicDto> GetById(int id);

    ServiceResult<ComicDto> Create(ComicDto comic);

    ServiceResult<ComicDto> Update(int id, ComicDto comic);

    ServiceResult<bool> Delete(int id);
}