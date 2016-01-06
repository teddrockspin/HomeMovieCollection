using HomeMovieCollection.Core;
using HomeMovieCollection.Core.Objects;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeMovieCollection
{
    public class MovieModelBinder : DefaultModelBinder
    {
        private readonly IKernel _kernel;

        public MovieModelBinder(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var movie = (Movie)base.BindModel(controllerContext, bindingContext);

            var movieRepository = _kernel.Get<IMovieCollectionRespository>();

            if (movie.Genre != null)
                movie.Genre = movieRepository.Genre(movie.Genre.GenreId);

            var actors = bindingContext.ValueProvider.GetValue("Actors").AttemptedValue.Split(',');

            if (actors.Length > 0)
            {
                movie.Actors = new List<Actor>();

                foreach (var actor in actors)
                {
                    movie.Actors.Add(movieRepository.Actor(int.Parse(actor.Trim())));
                }
            }

            if (bindingContext.ValueProvider.GetValue("oper").AttemptedValue.Equals("edit"))
                movie.Modified = DateTime.UtcNow; // dates are stored in UTC timezone.
            else
                movie.AddedOn = DateTime.UtcNow;

            return movie;
        }
    }
}