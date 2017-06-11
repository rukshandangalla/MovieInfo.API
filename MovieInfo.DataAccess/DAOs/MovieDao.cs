using System.Collections.Generic;

namespace MovieInfo.DataAccess.DAOs
{
    public class MovieDao
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Poster { get; set; }

        public List<TheaterDao> Theaters { get; set; }

        public string Cast { get; set; }

        public string Trailer { get; set; }
    }
}
