using System.Collections.Generic;
using HomeMovieCollection.Core.Objects;

namespace HomeMovieCollection.Core
{
    public interface IMovieCollectionRespository
    {
        IList<Movie> Movies(int pageNo, int pageSize);
        IList<Movie> Movies(int pageNo, int pageSize, string sortColumn, bool sortByAscending);
        int TotalMovies();

        Movie Movie(string titleSlug);
        Movie Movie(int id);
        int AddMovie(Movie movie);
        void EditMovie(Movie movie);
        void DeleteMovie(int id);

        #region Genre Methods
        IList<Movie> MoviesForGenre(string genreSlug, int pageNo, int pageSize);
        int TotalMoviesForGenre(string genreSlug);
        Genre Genre(string genreSlug);
        Genre Genre(int id);
        IList<Genre> Genres();
        int AddGenre(Genre genre);
        void EditGenre(Genre genre);
        void DeleteGenre(int id);
        #endregion

        #region Actor Methods
        IList<Movie> MoviesForActor(string actorSlug, int pageNo, int pageSize);
        int TotalMoviesForActor(string actorSlug);
        Actor Actor(string actorSlug);
        Actor Actor(int id);
        IList<Actor> Actors();
        int AddActor(Actor actor);
        void EditActor(Actor actor);
        void DeleteActor(int id);

        #endregion

        #region Search Methods
        IList<Movie> MoviesForSearch(string search, int pageNo, int pageSize, string sort, bool sortAsc);
        int TotalMoviesForSearch(string search);
        #endregion
    }
}
