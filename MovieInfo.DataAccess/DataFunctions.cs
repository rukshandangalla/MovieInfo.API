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
            var query = "SELECT M.id, M.Name, M.Genre, M.Cast, M.Poster, TH.id AS TheaterId, TH.Name AS TheaterName, TH.City FROM Movies M Join Theaters TH ON TH.id = M.TheaterId";
            var dt = dbHelper.ExecuteSelectCommand(query, CommandType.Text);

            List<MovieDao> movies = new List<MovieDao>();

            foreach (DataRow row in dt.Rows)
            {
                movies.Add(new MovieDao
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    Poster = row["Poster"].ToString(),
                    Theater = new TheaterDao { Id = int.Parse(row["TheaterId"].ToString()), Name = row["TheaterName"].ToString(), City = row["City"].ToString() },
                    Genre = row["Genre"].ToString(),
                    Cast = row["Cast"].ToString(),
                });
            }

            return movies;
        }

        public MovieDao GetMovieById(int id)
        {
            DBHelper dbHelper = new DBHelper();
            var query = $"SELECT M.id, M.Name, M.Genre, M.Cast, M.Poster, TH.id AS TheaterId, TH.Name AS TheaterName, TH.City from Movies M Join Theaters TH ON TH.id = M.TheaterId WHERE M.id = {id}";

            var dt = dbHelper.ExecuteSelectCommand(query, CommandType.Text);
            DataRow row = dt.Rows[0];

            MovieDao movie = new MovieDao
            {
                Id = int.Parse(row["Id"].ToString()),
                Name = row["Name"].ToString(),
                Poster = row["Poster"].ToString(),
                Theater = new TheaterDao { Id = int.Parse(row["TheaterId"].ToString()), Name = row["TheaterName"].ToString(), City = row["City"].ToString() },
                Genre = row["Genre"].ToString(),
                Cast = row["Cast"].ToString(),
            };

            return movie;
        }
    }
}
