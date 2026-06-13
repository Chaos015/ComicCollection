using ComicCollection.Api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ComicCollection.Api.Controllers
{
    [ApiController]
    [Route("api/comics")]
    public class ComicController : ControllerBase
    {
        private static readonly List<Comic> _comics = new List<Comic>
        {
            new Comic
            {
                Id = 1,
                Name = "Batman: The Killing Joke",
                Author = "Alan Moore",
                Editorial = "DC Comics",
                PublicationYear = 1988,
                genre = "Superhéroes"
            },
            new Comic
            {
                Id = 2,
                Name = "Spider-Man: Blue",
                Author = "Jeph Loeb",
                Editorial = "Marvel Comics",
                PublicationYear = 2002,
                genre = "Superhéroes"
            },
            new Comic
            {
                Id = 3,
                Name = "Saga Vol. 1",
                Author = "Brian K. Vaughan",
                Editorial = "Image Comics",
                PublicationYear = 2012,
                genre = "Ciencia Ficción"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Comic>> GetAll()
        {
            return Ok(_comics);
        }

        [HttpGet("{id}")]
        public ActionResult<Comic> GetById(int id)
        {
            var comic = _comics.FirstOrDefault(c => c.Id == id);

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

            int newId = _comics.Any()
                ? _comics.Max(c => c.Id) + 1
                : 1;

            comic.Id = newId;

            _comics.Add(comic);

            return CreatedAtAction(
                nameof(GetById),
                new { id = comic.Id },
                comic
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Comic comic)
        {
            var existing = _comics.FirstOrDefault(c => c.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = comic.Name;
            existing.Author = comic.Author;
            existing.Editorial = comic.Editorial;
            existing.PublicationYear = comic.PublicationYear;
            existing.genre = comic.genre;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _comics.FirstOrDefault(c => c.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            _comics.Remove(existing);

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Comic>> Search(string name)
            {
        var comics = _comics
        .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        .ToList();

        return Ok(comics);
        }
    }
}