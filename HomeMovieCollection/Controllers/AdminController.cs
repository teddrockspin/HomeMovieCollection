using System;
using System.Web.Mvc;
using HomeMovieCollection.Models;
using HomeMovieCollection.Core;
using HomeMovieCollection.Providers;
using Newtonsoft.Json;
using HomeMovieCollection.Core.Objects;
using System.Text;

namespace HomeMovieCollection.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly IAuthProvider _authProvider;
        private readonly IMovieCollectionRespository _movieCollectionRepository;

        public AdminController(IAuthProvider authProvider, IMovieCollectionRespository movieCollectionRepository = null)
        {
            _authProvider = authProvider;
            _movieCollectionRepository = movieCollectionRepository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (_authProvider.IsLoggedIn)
                return RedirectToUrl(returnUrl);

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && _authProvider.Login(model.UserName, model.Password))
            {
                return RedirectToUrl(returnUrl);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            _authProvider.Logout();

            return Redirect("/");
        }

        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Manage");
            }
        }

        #region Posts Methods
        public ContentResult Movies(JqInViewModel jqParams)
        {
            var movies = _movieCollectionRepository.Movies(jqParams.page - 1, jqParams.rows,
                jqParams.sidx, jqParams.sord == "asc");

            var totalMovies = _movieCollectionRepository.TotalMovies();
            return Content(JsonConvert.SerializeObject(new
            {
                page = jqParams.page,
                records = totalMovies,
                rows = movies,
                total = Math.Ceiling(Convert.ToDouble(totalMovies) / jqParams.rows)
            }, new CustomDateTimeConverter()), "application/json");
        }

        [HttpPost, ValidateInput(false)]
        public ContentResult AddMovie(Movie movie)
        {
            string json;

            ModelState.Clear();

            if (ModelState.IsValid)
            {
                var id = _movieCollectionRepository.AddMovie(movie);

                json = JsonConvert.SerializeObject(new
                {
                    id = id,
                    success = true,
                    message = "Movie added successfully."
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to add the movie."
                });
            }

            return Content(json, "application/json");
        }

        [HttpPost, ValidateInput(false)]
        public ContentResult EditMovie(Movie movie)
        {
            string json;

            ModelState.Clear();

            if (TryValidateModel(movie))
            {
                _movieCollectionRepository.EditMovie(movie);
                json = JsonConvert.SerializeObject(new
                {
                    id = movie.MovieId,
                    success = true,
                    message = "Changes saved successfully."
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to save the changes."
                });
            }

            return Content(json, "application/json");
        }

        [HttpPost]
        public ContentResult DeleteMovie(int id)
        {
            _movieCollectionRepository.DeleteMovie(id);

            var json = JsonConvert.SerializeObject(new
            {
                id = 0,
                success = true,
                message = "Movie deleted successfully"
            });

            return Content(json, "application/json");
        }

        public ActionResult GoToMovie(int id)
        {
            var post = _movieCollectionRepository.Movie(id);
            return RedirectToRoute(new { controller = "Movie", action = "Movie", title = post.UrlSlug });
        }


        #endregion

        #region Genre Methods
        public ContentResult Genres()
        {
            var genres = _movieCollectionRepository.Genres();

            return Content(JsonConvert.SerializeObject(new
            {
                page = 1,
                records = genres.Count,
                rows = genres,
                total = 1
            }), "application/json");
        }

        [HttpPost]
        public ContentResult AddGenre([Bind(Exclude = "GenreID")] Genre genre)
        {
            string json;

            if (ModelState.IsValid)
            {
                var id = _movieCollectionRepository.AddGenre(genre);
                json = JsonConvert.SerializeObject(new
                {
                    id = id,
                    success = true,
                    message = "Genre added successfully"
                });
            } else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to add the genre."
                });

                
            }

            return Content(json, "application/json");
        }

        [HttpPost]
        public ContentResult EditGenre(Genre genre)
        {
            string json;

            if (ModelState.IsValid)
            {
                _movieCollectionRepository.EditGenre(genre);
                json = JsonConvert.SerializeObject(new
                {
                    id = genre.GenreId,
                    success = true,
                    message = "Changes saved successfully."
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to save the changes."
                });
            }

            return Content(json, "application/json");

        }

        [HttpPost]
        public ContentResult DeleteGenre(int id)
        {
            _movieCollectionRepository.DeleteGenre(id);

            var json = JsonConvert.SerializeObject(new
            {
                id = 0,
                success = true,
                message = "Genre deleted successfully."
            });

            return Content(json, "application/json");
        }


        public ContentResult GetGenresHtml()
        {
            var genres = _movieCollectionRepository.Genres();

            var sb = new StringBuilder();
            sb.AppendLine(@"<select>");

            foreach (var genre in genres)
            {
                sb.AppendLine(string.Format(@"<option value=""{0}"">{1}</option>",
                    genre.GenreId, genre.Name));
            }

            sb.AppendLine("<select>");
            return Content(sb.ToString(), "text/html");
        }

        #endregion

        #region Actor Methods
        public ContentResult Actors()
        {
            var actors = _movieCollectionRepository.Actors();

            return Content(JsonConvert.SerializeObject(new
            {
                page = 1,
                records = actors.Count,
                rows = actors,
                total = 1
            }), "application/json");
        }

        [HttpPost]
        public ContentResult AddActor([Bind(Exclude = "ActorId")]Actor actor)
        {
            string json;

            if (ModelState.IsValid)
            {
                var id = _movieCollectionRepository.AddActor(actor);
                json = JsonConvert.SerializeObject(new
                {
                    id = id,
                    success = true,
                    message = "Actor added successfully."
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to add the actor."
                });
            }

            return Content(json, "application/json");
        }

        [HttpPost]
        public ContentResult EditActor(Actor actor)
        {
            string json;

            if (ModelState.IsValid)
            {
                _movieCollectionRepository.EditActor(actor);
                json = JsonConvert.SerializeObject(new
                {
                    id = actor.ActorId,
                    success = true,
                    message = "Changes saved successfully."
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to save the changes."
                });
            }

            return Content(json, "application/json");
        }

        [HttpPost]
        public ContentResult DeleteActor(int id)
        {
            _movieCollectionRepository.DeleteActor(id);

            var json = JsonConvert.SerializeObject(new
            {
                id = 0,
                success = true,
                message = "Actor deleted successfully."
            });

            return Content(json, "application/json");
        }




        public ContentResult GetActorsHtml()
        {
            var actors = _movieCollectionRepository.Actors();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<select multiple=""multiple"">");

            foreach (var actor in actors)
            {
                sb.AppendLine(string.Format(@"<option value=""{0}"">{1}</option>",
                    actor.ActorId, actor.FirstName + " " + actor.LastName));
            }

            sb.AppendLine("<select>");
            return Content(sb.ToString(), "text/html");
        }
        #endregion


        [ChildActionOnly]
        //[OutputCache(Duration = 2000, VaryByParam = "none")]
        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_movieCollectionRepository);
            return PartialView("_Sidebars", widgetViewModel);
        }
    }
}