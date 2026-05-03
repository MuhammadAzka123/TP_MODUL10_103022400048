using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400048.Models;

namespace TP_MODUL10_103022400048.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>
        {
            new Film { Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetFilms()
        {
            return films;
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetFilm(int id)
        {
            if (id < 1 || id > films.Count)
                return NotFound();

            return Ok(films[id - 1]);
        }

        [HttpPost]
        public ActionResult AddFilm([FromBody] Film film)
        {
            if (film == null)
                return BadRequest("Data kosong / tidak terbaca");

            films.Add(film);
            return Ok(film);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFilm(int id)
        {
            if (id < 1 || id > films.Count)
                return NotFound();

            films.RemoveAt(id - 1);
            return Ok();
        }
    }
}
