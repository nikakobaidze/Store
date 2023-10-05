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
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            var model = _authorService.GetAuthor();
            var viewModel = new List<AuthorViewModel>();
            foreach (var item in model)
            {
                var authoViewModel = new AuthorViewModel();
                authoViewModel.ID = item.ID;
                authoViewModel.LastName = item.LastName;
                authoViewModel.FirstName = item.FirstName;
                authoViewModel.BookAuthors = item.BookAuthors;
                viewModel.Add(authoViewModel);
            }
            return View(viewModel);
        }
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost]
        public ActionResult Create(AuthorViewModel authorViewModel)
        {
            //var authorViewModel = new AuthorViewModel();
            //authorViewModel.ID = authors.ID;
            //authorViewModel.LastName = authors.LastName;
            //authorViewModel.FirstName = authors.FirstName;
            //authorViewModel.BookAuthors = authors.BookAuthors;
            var authors = new Authors();
            authors.ID = authorViewModel.ID;
            authors.LastName = authorViewModel.LastName;
            authors.FirstName = authorViewModel.FirstName;
            authors.BookAuthors = authorViewModel.BookAuthors;
            _authorService.CreateAuthor(authors);
            _authorService.SaveAuthor();
            return View(authorViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(AuthorViewModel authors)
        {
            var authori = _authorService.GetAuthor(authors.ID);
            _authorService.DeleteAuthor(authori);
            _authorService.SaveAuthor();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(AuthorViewModel authorViewModel)
        {
            var authors = new Authors();
            authors.ID = authorViewModel.ID;
            authors.LastName = authorViewModel.LastName;
            authors.FirstName = authorViewModel.FirstName;
            authors.BookAuthors = authorViewModel.BookAuthors;
            _authorService.UpdateAuthor(authors);
            _authorService.SaveAuthor();
            return View(authorViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var authors=_authorService.GetAuthor(ID);
            var authorViewModel = new AuthorViewModel();
            authorViewModel.ID = authors.ID;
            authorViewModel.LastName = authors.LastName;
            authorViewModel.FirstName = authors.FirstName;
            authorViewModel.BookAuthors = authors.BookAuthors;
            return View(authorViewModel);
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            var authors = _authorService.GetAuthor(ID);
            var authorViewModel = new AuthorViewModel();
            authorViewModel.ID = authors.ID;
            authorViewModel.LastName = authors.LastName;
            authorViewModel.FirstName = authors.FirstName;
            authorViewModel.BookAuthors = authors.BookAuthors;
            return View(authorViewModel);
        }
    }
}