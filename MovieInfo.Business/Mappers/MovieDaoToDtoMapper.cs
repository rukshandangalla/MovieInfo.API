using MovieInfo.Business.Dto;
using MovieInfo.DataAccess.DAOs;
using System.Collections.Generic;

namespace MovieInfo.Business.Mappers
{
    public static class MovieDaoToDtoMapper
    {
        public static MovieDto Convert(MovieDao from)
        {
            var convertedTheaters = new List<TheaterDto>();

            if (from.Theaters != null)
            {
                foreach (var theater in from.Theaters)
                {
                    convertedTheaters.Add(TheaterDaoToDtoMapper.Convert(theater));
                }
            }
            return new MovieDto()
            {
                Id = from.Id,
                Name = from.Name,
                Poster = from.Poster,
                Genre = from.Genre,
                Theaters = convertedTheaters,
                Cast = from.Cast,
                Trailer = from.Trailer
            };
        }
    }
}
