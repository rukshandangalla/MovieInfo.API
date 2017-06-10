using Microsoft.AspNetCore.Mvc;
using MovieInfo.Business;
using MovieInfo.Business.Dto;
using System.Collections.Generic;

namespace MovieInfo.API.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public List<MovieDto> Get()
        {
            return MoviesFunctions.Current.GetAllMovies();
        }

        [HttpGet("{id}")]
        public MovieDto GetMovie(int id)
        {
            return MoviesFunctions.Current.GetMovieById(id);
        }
    }
}
