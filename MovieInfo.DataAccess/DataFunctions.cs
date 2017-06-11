using MovieInfo.DataAccess.DAOs;
using System.Collections.Generic;
using System.Data;

namespace MovieInfo.DataAccess
{
    public class DataFunctions
    {
        public List<MovieDao> GetAllMovies()
        {
            DBHelper dbHelper = new DBHelper();
            var query = "SELECT * FROM Movies";
            var dt = dbHelper.ExecuteSelectCommand(query, CommandType.Text);

            List<MovieDao> movies = new List<MovieDao>();

            foreach (DataRow row in dt.Rows)
            {
                movies.Add(new MovieDao
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    Poster = row["Poster"].ToString(),
                    Theaters = GetTheatersByMovieId(int.Parse(row["Id"].ToString())),
                    Trailer = row["Trailer"].ToString(),
                    Genre = row["Genre"].ToString(),
                    Cast = row["Cast"].ToString()
                });
            }

            return movies;
        }

        public MovieDao GetMovieById(int id)
        {
            DBHelper dbHelper = new DBHelper();
            var query = $"SELECT * FROM Movies WHERE id = {id}";

            var dt = dbHelper.ExecuteSelectCommand(query, CommandType.Text);
            DataRow row = dt.Rows[0];

            MovieDao movie = new MovieDao
            {
                Id = int.Parse(row["Id"].ToString()),
                Name = row["Name"].ToString(),
                Poster = row["Poster"].ToString(),
                Trailer = row["Trailer"].ToString(),
                Theaters = GetTheatersByMovieId(id),
                Genre = row["Genre"].ToString(),
                Cast = row["Cast"].ToString()
            };

            return movie;
        }

        public List<TheaterDao> GetTheatersByMovieId(int movieId)
        {
            DBHelper dbHelper = new DBHelper();
            var query = $"SELECT TH.id, TH.Name, TH.Location, TH.Map, TH.Cordinates FROM Movies M  Join MovieTheaters MTH ON MTH.MovieId = M.Id Join Theaters TH ON TH.Id = MTH.TheaterId WHERE M.id = {movieId}";

            var dt = dbHelper.ExecuteSelectCommand(query, CommandType.Text);

            List<TheaterDao> theaters = new List<TheaterDao>();

            foreach (DataRow row in dt.Rows)
            {
                theaters.Add(new TheaterDao
                {
                    Id = int.Parse(row["id"].ToString()),
                    Name = row["Name"].ToString(),
                    Location = row["Location"].ToString(),
                    Map = row["Map"].ToString(),
                    Cordinates = row["Cordinates"].ToString()
                });
            }

            return theaters;
        }
    }
}
