using HomeMovieCollection.Core;
using HomeMovieCollection.Core.Objects;
using System.Collections.Generic;

namespace HomeMovieCollection.Models
{
    public class WidgetViewModel 
    {
        public WidgetViewModel(IMovieCollectionRespository movieCollectionRepository)
        {
            Genres = movieCollectionRepository.Genres();
            Actors = movieCollectionRepository.Actors();
        }

      
        public IList<Genre> Genres { get; private set; }
        public IList<Actor> Actors { get; private set; }
    }
}