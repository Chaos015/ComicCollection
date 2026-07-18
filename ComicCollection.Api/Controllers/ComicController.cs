using ComicCollection.Domain.Entities;
using ComicCollection.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComicCollection.Api.Controllers
{
    [ApiController]
    [Route("api/comics")]
    public class ComicController : ControllerBase
    {
        private readonly IComicRepository _repository;

        public ComicController(IComicRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comic>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Comic> GetById(int id)
        {
            var comic = _repository.GetById(id);

            if (comic == null)
            {
                return NotFound();
            }

            return Ok(comic);
        }

        [HttpPost]
        public ActionResult<Comic> Create(Comic comic)
        {
            if (string.IsNullOrWhiteSpace(comic.Name))
            {
                return BadRequest("Comic title is required.");
            }

            _repository.Add(comic);

            return CreatedAtAction(nameof(GetById), new { id = comic.Id }, comic);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Comic comic)
        {
            var existing = _repository.GetById(id);

            if (existing == null)
            {
                return NotFound();
            }

            comic.Id = id;
            _repository.Update(comic);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);

            if (existing == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Comic>> Search(string name)
        {
            var comics = _repository.GetAll()
                .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            return Ok(comics);
        }

        [HttpGet("genre/{genre}")]
        public ActionResult<IEnumerable<Comic>> GetByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest("Genre is required.");
            }

            var comics = _repository.GetAll()
                .Where(c => c.Genre != null &&
                            c.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

            return Ok(comics);
        }
    }
}