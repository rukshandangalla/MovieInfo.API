using Microsoft.AspNetCore.Mvc;
using MovieInfo.Business;

namespace MovieInfo.API.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult GetMovies()
        {
            var retData = MoviesFunctions.Current.GetAllMovies();
            return Ok(retData);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var retData = MoviesFunctions.Current.GetMovieById(id);

            if (retData == null)
            {
                return NotFound();
            }

            return Ok(retData);
        }
    }
}
