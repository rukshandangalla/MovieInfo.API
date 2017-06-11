using MovieInfo.Business.Dto;
using MovieInfo.Business.Mappers;
using MovieInfo.DataAccess;
using System.Collections.Generic;

namespace MovieInfo.Business
{
    public class MoviesFunctions
    {
        public static MoviesFunctions Current { get; } = new MoviesFunctions();

        public List<MovieDto> GetAllMovies()
        {
            var retData = new List<MovieDto>();
            DataFunctions df = new DataFunctions();
            var allMovies = df.GetAllMovies();

            foreach (var movie in allMovies)
            {
                retData.Add(MovieDaoToDtoMapper.Convert(movie));
            }

            return retData;
        }

        public MovieDto GetMovieById(int id)
        {
            var retData = new MovieDto();
            DataFunctions df = new DataFunctions();
            var movie = df.GetMovieById(id);

            return MovieDaoToDtoMapper.Convert(movie);
        }

        public List<TheaterDto> GetTheatersByMovieId(int movieId)
        {
            var retData = new List<TheaterDto>();
            DataFunctions df = new DataFunctions();
            var allTheaters = df.GetTheatersByMovieId(movieId);

            foreach (var theater in allTheaters)
            {
                retData.Add(TheaterDaoToDtoMapper.Convert(theater));
            }

            return retData;
        }
    }
}
