using HomeMovieCollection.Core;
using HomeMovieCollection.Core.Objects;
using System.Collections.Generic;


namespace HomeMovieCollection.Models
{
    public class ListViewModel
    {
        public ListViewModel(IMovieCollectionRespository movieCollectionRepository, int p)
        {
            Movies = movieCollectionRepository.Movies(p - 1, 5);
            TotalMovies = movieCollectionRepository.TotalMovies();
        }

        public ListViewModel(IMovieCollectionRespository movieCollectionRepository, string text, string type, int p, string sort, bool sortAsc)
        {
            switch (type)
            {
                case "Genre":
                    Movies = movieCollectionRepository.MoviesForGenre(text, p - 1, 5);
                    TotalMovies = movieCollectionRepository.TotalMoviesForGenre(text);
                    Genre = movieCollectionRepository.Genre(text);
                    break;
                case "Actor":
                    Movies = movieCollectionRepository.MoviesForActor(text, p - 1, 5);
                    TotalMovies = movieCollectionRepository.TotalMoviesForActor(text);
                    Actor = movieCollectionRepository.Actor(text);
                    break;
                default:
                    Movies = movieCollectionRepository.MoviesForSearch(text, p - 1, 5, sort, sortAsc);
                    TotalMovies = movieCollectionRepository.TotalMoviesForSearch(text);
                    Search = text;
                    break;
            }
        }

        public IList<Movie> Movies { get; private set; }
        public int TotalMovies { get; private set; }
        public Genre Genre { get; private set; }
        public Actor Actor { get; private set; }
        public string Search { get; private set; }
    }
}