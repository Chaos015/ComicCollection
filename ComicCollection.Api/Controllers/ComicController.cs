using ComicCollection.Application.Contract;
using ComicCollection.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ComicCollection.Api.Controllers;

[ApiController]
[Route("api/comics")]
public class ComicController : ControllerBase
{
    private readonly IComicService _service;

    public ComicController(IComicService service)
    {
        _service = service;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _service.GetAll();

        return result.Success
            ? Ok(result)
            : BadRequest(result);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);

        return result.Success
            ? Ok(result)
            : NotFound(result);
    }


    [HttpPost]
    public IActionResult Create(ComicDto comic)
    {
        var result = _service.Create(comic);

        return result.Success
            ? Created("", result)
            : BadRequest(result);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, ComicDto comic)
    {
        var result = _service.Update(id, comic);

        return result.Success
            ? Ok(result)
            : BadRequest(result);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);

        return result.Success
            ? Ok(result)
            : NotFound(result);
    }
}