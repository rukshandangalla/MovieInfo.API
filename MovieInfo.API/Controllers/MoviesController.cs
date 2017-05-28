using Microsoft.AspNetCore.Mvc;
using MovieInfo.Business;

namespace MovieInfo.API.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            var retData = MoviesFunctions.Current.GetAllMovies();
            return Ok(retData);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
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
