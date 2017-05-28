using MovieInfo.Business.Dto;
using MovieInfo.DataAccess.DAOs;

namespace MovieInfo.Business.Mappers
{
    public static class MovieDaoToDtoMapper
    {
        public static MovieDto Convert(MovieDao from)
        {
            return new MovieDto()
            {
                Id = from.Id,
                Name = from.Name,
                Poster = from.Poster,
                Theater = TheaterDaoToDtoMapper.Convert(from.Theater)
            };
        }
    }
}
