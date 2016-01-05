using System.Linq;
using System.Collections.Generic;
using HomeMovieCollection.Core.Objects;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.Linq;

namespace HomeMovieCollection.Core
{
    public class MovieCollectionRepository : IMovieCollectionRespository
    {
        private readonly ISession _session;
        public MovieCollectionRepository(ISession session)
        {
            _session = session;
        }

        public IList<Movie> Movies(int pageNo, int pageSize)
        {
            var movies = _session.Query<Movie>()
                                .OrderBy(m => m.ReleaseDate)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Fetch(m => m.Genre)
                                .ToList();

            var movieIds = movies.Select(m => m.MovieId).ToList();

            return _session.Query<Movie>()
                .Where(m => movieIds.Contains(m.MovieId))
                .OrderByDescending(m => m.ReleaseDate)
                .FetchMany(p => p.Actors)
                .ToList();
        }


        public IList<Movie> Movies(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            IList<Movie> movies;
            IList<int> movieIds;

            switch (sortColumn)
            {
                case "Title":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                            .OrderBy(m => m.Title)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .Fetch(m => m.Genre)
                            .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                            .Where(m => movieIds.Contains(m.MovieId))
                            .OrderBy(m => m.Title)
                            .FetchMany(m => m.Actors)
                            .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                        .OrderByDescending(m => m.Title)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Fetch(m => m.Genre)
                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.Title)
                                          .FetchMany(m => m.Actors)
                                          .ToList();

                    }
                    break;

                case "Format":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                                        .OrderBy(m => m.Format)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                                        .OrderByDescending(m => m.ReleaseDate)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                case "Region":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                                        .OrderBy(m => m.Region)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                                        .OrderByDescending(m => m.ReleaseDate)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                case "RunTime":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                                        .OrderBy(m => m.RunTime)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                                        .OrderByDescending(m => m.ReleaseDate)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                case "Genre":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                                        .OrderBy(m => m.Genre)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                                        .OrderByDescending(m => m.ReleaseDate)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                default:
                    movies = _session.Query<Movie>()
                                    .OrderByDescending(m => m.ReleaseDate)
                                    .Skip(pageNo * pageSize)
                                    .Take(pageSize)
                                    .Fetch(m => m.Genre)
                                    .ToList();

                    movieIds = movies.Select(m => m.MovieId).ToList();

                    movies = _session.Query<Movie>()
                                      .Where(m => movieIds.Contains(m.MovieId))
                                      .OrderByDescending(m => m.ReleaseDate)
                                      .FetchMany(m => m.Actors)
                                      .ToList();
                    break;
            }

            return movies;

        }

        public int AddMovie(Movie movie)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(movie);
                tran.Commit();
                return movie.MovieId;
            }
        }

        public void EditMovie(Movie movie)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(movie);
                tran.Commit();
            }
        }

        public void DeleteMovie(int id)
        {
            using (var tran = _session.BeginTransaction())
            {
                var movie = _session.Get<Movie>(id);
                _session.Delete(movie);
                tran.Commit();
            }
        }

        public Movie Movie(string titleSlug)
        {
            var query = _session.Query<Movie>()
                .Where(m => m.UrlSlug.Equals(titleSlug))
                .Fetch(m => m.Genre);

            query.FetchMany(m => m.Actors).ToFuture();

            return query.ToFuture().Single();
        }

        public Movie Movie(int id)
        {
            return _session.Query<Movie>().FirstOrDefault(t => t.MovieId == id);
        }

        public int TotalMovies()
        {
            return _session.Query<Movie>().Count();
        }

        #region Genre Methods
        public IList<Movie> MoviesForGenre(string genreSlug, int pageNo, int pageSize)
        {
            var movies = _session.Query<Movie>()
                                .Where(m => m.Genre.UrlSlug.Equals(genreSlug))
                                .OrderByDescending(p => p.ReleaseDate)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Fetch(m => m.Genre)
                                .ToList();

            var movieIds = movies.Select(m => m.MovieId).ToList();

            return _session.Query<Movie>()
                          .Where(m => movieIds.Contains(m.MovieId))
                          .OrderByDescending(m => m.MovieId)
                          .FetchMany(m => m.Actors)
                          .ToList();
        }

        public int TotalMoviesForGenre(string genreSlug)
        {
            return _session.Query<Movie>()
                        .Where(m => m.Genre.UrlSlug.Equals(genreSlug))
                        .Count();
        }

        public Genre Genre(string genreSlug)
        {
            return _session.Query<Genre>()
                        .FirstOrDefault(m => m.UrlSlug.Equals(genreSlug));
        }

        public Genre Genre(int id)
        {
            return _session.Query<Genre>().FirstOrDefault(t => t.GenreId == id);
        }

        public IList<Genre> Genres()
        {
            return _session.Query<Genre>().OrderBy(g => g.Name).ToList();
        }

        public int AddGenre(Genre genre)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(genre);
                tran.Commit();
                return genre.GenreId;
            }
        }

        public void EditGenre(Genre genre)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(genre);
                tran.Commit();
            }
        }

        public void DeleteGenre(int id)
        {
            using (var tran = _session.BeginTransaction())
            {
                var genre = _session.Get<Genre>(id);
                _session.Delete(genre);
                tran.Commit();
            }
        }

        #endregion

        #region Actor Methods
        public IList<Actor> Actors()
        {
            return _session.Query<Actor>().OrderBy(p => p.LastName).ToList();
        }

        public IList<Movie> MoviesForActor(string actorSlug, int pageNo, int pageSize)
        {
            var movies = _session.Query<Movie>()
                .Where(m => m.Actors.Any(t => t.UrlSlug.Equals(actorSlug)))
                .OrderByDescending(m => m.ReleaseDate)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Fetch(m => m.Genre)
                .ToList();

            var movieIds = movies.Select(m => m.MovieId).ToList();

            return _session.Query<Movie>()
                .Where(m => movieIds.Contains(m.MovieId))
                .OrderByDescending(m => m.ReleaseDate)
                .FetchMany(m => m.Actors)
                .ToList();
        }

        public int TotalMoviesForActor(string actorSlug)
        {
            return _session.Query<Movie>()
                .Where(m => m.Actors.Any(a => a.UrlSlug.Equals(actorSlug)))
                .Count();
        }

        public Actor Actor(string actorSlug)
        {
            return _session.Query<Actor>()
                .FirstOrDefault(a => a.UrlSlug.Equals(actorSlug));
        }

        public Actor Actor(int id)
        {
            return _session.Query<Actor>().FirstOrDefault(a => a.ActorId == id);
        }

        public int AddActor(Actor actor)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(actor);
                tran.Commit();
                return actor.ActorId;
            }
        }

        public void EditActor(Actor actor)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(actor);
                tran.Commit();
            }
        }

        public void DeleteActor(int id)
        {
            using (var tran = _session.BeginTransaction())
            {
                var actor = _session.Get<Actor>(id);
                _session.Delete(actor);
                tran.Commit();
            }
        }
        #endregion


        //Todo figure out a way to reduce the code here and above to simplify things. 
        #region Search Methods
        public IList<Movie> MoviesForSearch(string search, int pageNo, int pageSize, string sort, bool sortByAscending)
        {
            IList<Movie> movies;
            IList<int> movieIds;
           

            switch (sort.ToLower())
            {
                case "title":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                            .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                            .OrderBy(m => m.Title)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .Fetch(m => m.Genre)
                            .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                            .Where(m => movieIds.Contains(m.MovieId))
                            .OrderBy(m => m.Title)
                            .FetchMany(m => m.Actors)
                            .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                        .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                        .OrderByDescending(m => m.Title)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Fetch(m => m.Genre)
                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.Title)
                                          .FetchMany(m => m.Actors)
                                          .ToList();

                    }
                    break;
                case "release":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                            .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                            .OrderBy(m => m.ReleaseDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .Fetch(m => m.Genre)
                            .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                            .Where(m => movieIds.Contains(m.MovieId))
                            .OrderBy(m => m.ReleaseDate)
                            .FetchMany(m => m.Actors)
                            .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                        .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                        .OrderByDescending(m => m.ReleaseDate)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Fetch(m => m.Genre)
                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.ReleaseDate)
                                          .FetchMany(m => m.Actors)
                                          .ToList();

                    }
                    break;
                case "runtime":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                             .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                        .OrderBy(m => m.RunTime)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.RunTime)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                             .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                        .OrderByDescending(m => m.RunTime)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.RunTime)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                case "genre":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                             .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                        .OrderBy(m => m.Genre)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.Genre)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                             .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                        .OrderByDescending(m => m.Genre)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.Genre)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                case "director":
                    if (sortByAscending)
                    {
                        movies = _session.Query<Movie>()
                             .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                        .OrderBy(m => m.Director)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(p => p.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderBy(m => m.Director)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    else
                    {
                        movies = _session.Query<Movie>()
                             .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                        .OrderByDescending(m => m.Director)
                                        .Skip(pageNo * pageSize)
                                        .Take(pageSize)
                                        .Fetch(m => m.Genre)
                                        .ToList();

                        movieIds = movies.Select(m => m.MovieId).ToList();

                        movies = _session.Query<Movie>()
                                          .Where(m => movieIds.Contains(m.MovieId))
                                          .OrderByDescending(m => m.Director)
                                          .FetchMany(m => m.Actors)
                                          .ToList();
                    }
                    break;
                default:
                    movies = _session.Query<Movie>()
                         .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                                    .OrderBy(m => m.Title)
                                    .Skip(pageNo * pageSize)
                                    .Take(pageSize)
                                    .Fetch(m => m.Genre)
                                    .ToList();

                    movieIds = movies.Select(m => m.MovieId).ToList();

                    movies = _session.Query<Movie>()
                                      .Where(m => movieIds.Contains(m.MovieId))
                                      .OrderBy(m => m.Title)
                                      .FetchMany(m => m.Actors)
                                      .ToList();
                    break;
            }

            return movies;
            //var movies = _session.Query<Movie>()
            //                      .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
            //                      .OrderByDescending(m => m.ReleaseDate)
            //                      .Skip(pageNo * pageSize)
            //                      .Take(pageSize)
            //                      .Fetch(m => m.Genre)
            //                      .ToList();

            //var movieIds = movies.Select(m => m.MovieId).ToList();

            //return _session.Query<Movie>()
            //      .Where(m => movieIds.Contains(m.MovieId))
            //      .OrderByDescending(m => m.ReleaseDate)
            //      .FetchMany(m => m.Actors)
            //      .ToList();
        }

        public int TotalMoviesForSearch(string search)
        {
            return _session.Query<Movie>()
                    .Where(m => (m.Title.Contains(search) || m.Genre.Name.Equals(search) || m.Actors.Any(a => a.FirstName.Equals(search))))
                    .Count();
        }

        #endregion
    }
}
