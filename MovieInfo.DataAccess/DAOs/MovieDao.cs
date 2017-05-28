namespace MovieInfo.DataAccess.DAOs
{
    public class MovieDao
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Poster { get; set; }

        public TheaterDao Theater { get; set; }

        public string Cast { get; set; }
    }
}
