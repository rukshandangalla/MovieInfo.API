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
            var cityToReturn = MoviesFunctions.Current.GetMovieById(id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
