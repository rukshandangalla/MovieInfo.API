using MovieInfo.Business.Dto;
using MovieInfo.DataAccess.DAOs;

namespace MovieInfo.Business.Mappers
{
    public static class TheaterDaoToDtoMapper
    {
        public static TheaterDto Convert(TheaterDao from)
        {
            return new TheaterDto()
            {
                Id = from.Id,
                Name = from.Name,
                City = from.City
            };
        }
    }
}
