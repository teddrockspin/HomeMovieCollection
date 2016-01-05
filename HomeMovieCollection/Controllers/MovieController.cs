using HomeMovieCollection.Core;
using HomeMovieCollection.Models;
using System.Web;
using System.Web.Mvc;

namespace HomeMovieCollection.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieCollectionRespository _movieCollectionRespository;

        public MovieController(IMovieCollectionRespository movieCollectionRespository)
        {
            _movieCollectionRespository = movieCollectionRespository;
        }

      public ViewResult Movies( int p = 1)
        {
            var viewModel = new ListViewModel(_movieCollectionRespository, p);

            ViewBag.Title = "Latest Movies";

            return View("List", viewModel);

        }

        public ViewResult Movie(string title)
        {
            var movie = _movieCollectionRespository.Movie(title);

            if (movie == null)
            {
                throw new HttpException(404, "Movie not found");
            }

            return View(movie);
        }

        public ViewResult Genre(string genre, int p = 1)
        {
            var viewModel = new ListViewModel(_movieCollectionRespository, genre, "Genre", p, "", false);

            if (viewModel.Genre == null)
            {
                throw new HttpException(404, "Genre Not found");
            }

            ViewBag.Title = string.Format(@"Movies by Genre ""{0}""", viewModel.Genre.Name);
            return View("List", viewModel);
        }

        public ViewResult Actor(string actor, int p = 1)
        {
            var viewModel = new ListViewModel(_movieCollectionRespository, actor, "Actor", p, "", false);

            if(viewModel.Actor == null)
            {
                throw new HttpException(404, "Actor not found");
            }

            ViewBag.Title = string.Format(@"Movies starring Actor ""{0}""", viewModel.Actor.FirstName + " " + viewModel.Actor.LastName);
            return View("List", viewModel);
        }

        public ViewResult Search(string s, string sort = "", string sortAsc = "", int p = 1)
        {
            ViewBag.Title = string.Format(@"Search results found for search text ""{0}""", s);

            var viewModel = new ListViewModel(_movieCollectionRespository, s, "Search", p, sort, (sortAsc == "" ? true : false));
            return View("Search", viewModel);
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 2000, VaryByParam = "none")]
        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_movieCollectionRespository);
            return PartialView("_Sidebars", widgetViewModel);
        }
    }
}