using Store.Model.Models;
using Store.Service;
using Store.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            var model = _genreService.GetGenre();
            var viewModel = new List<GenreViewModel>();
            foreach(var item in model)
            {
                var genreViewModel = new GenreViewModel();
                genreViewModel.ID = item.ID;
                genreViewModel.Name = item.Name;
                genreViewModel.BookGenres=item.BookGenres;
               // genreViewModel.BookLanguages = item.BookLanguages;
                viewModel.Add(genreViewModel);
            }
            return View(viewModel);
        }
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public ActionResult Create(GenreViewModel genreViewModel)
        {

            //var genreViewModel = new GenreViewModel();
            //genreViewModel.ID = genres.ID;
            //genreViewModel.Name = genres.Name;
            //genreViewModel.BookGenres = genres.BookGenres;

            var genres = new Genres();
            genres.ID = genreViewModel.ID;
            genres.Name = genreViewModel.Name;
            genres.BookGenres = genreViewModel.BookGenres;

            // genreViewModel.BookLanguages = genres.BookLanguages;
            _genreService.CreateGenre(genres);
            _genreService.SaveGenre();
            return View(genreViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(GenreViewModel genres)
        {
            var genre = _genreService.GetGenre(genres.ID);
            _genreService.DeleteGenre(genre);
            _genreService.SaveGenre();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(GenreViewModel genreViewModel)
        {
            var genres = new Genres();
            genres.ID = genreViewModel.ID;
            genres.Name = genreViewModel.Name;
            genres.BookGenres = genreViewModel.BookGenres;
           // genres.BookLanguages = genreViewModel.BookLanguages;
            _genreService.UpdateGenre(genres);
            _genreService.SaveGenre();
            return View(genreViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var genres = _genreService.GetGenre(ID);
            var genreViewModel = new GenreViewModel();
            genreViewModel.ID = genres.ID;
            genreViewModel.Name = genres.Name;
            genreViewModel.BookGenres = genres.BookGenres;
           // genres.BookLanguages = genreViewModel.BookLanguages;
            return View(genreViewModel);
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            var genres = _genreService.GetGenre(ID);
            var genreViewModel = new GenreViewModel();
            genreViewModel.ID = genres.ID;
            genreViewModel.Name = genres.Name;
            genreViewModel.BookGenres = genres.BookGenres;
            // genres.BookLanguages = genreViewModel.BookLanguages;
            return View(genreViewModel);
        }
    }
}