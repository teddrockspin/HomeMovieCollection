using HomeMovieCollection.Core.Objects;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HomeMovieCollection
{
    public static class ActionLinkExtensions
    {
        public static MvcHtmlString MovieLink(this HtmlHelper helper, Movie movie)
        {
            return helper.ActionLink(movie.Title, "Movie", "Movie",
                new
                {
                    title = movie.UrlSlug
                },
                new
                {
                    title = movie.Title
                });
        }

        public static MvcHtmlString GenreLink(this HtmlHelper helper,
            Genre genre)
        {
            return helper.ActionLink(genre.Name, "Genre", "Movie",
                new
                {
                    genre = genre.UrlSlug
                },
                new
                {
                    title = String.Format("See all movies in {0}", genre.Name)
                });
        }

        public static MvcHtmlString ActorLink(this HtmlHelper helper, Actor actor)
        {
            return helper.ActionLink(actor.FirstName + " " + actor.LastName, "Actor", "Movie", new { actor = actor.UrlSlug },
                new
                {
                    title = String.Format("See all movies starring {0}", actor.FirstName + " " + actor.LastName)
                });
        }

    }
}