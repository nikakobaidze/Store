using DocumentFormat.OpenXml.Office2010.Excel;
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
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var model = _bookService.GetBook();
            var viewModel = new List<BookViewModel>();
            foreach(var item in model)
            {
                var bookViewModel=new BookViewModel();
                bookViewModel.Title = item.Title;
                bookViewModel.ID=item.ID;
                bookViewModel.PublicationDate = item.PublicationDate;
                bookViewModel.Edition = item.Edition;
                bookViewModel.Reservations = item.Reservations;
                bookViewModel.PageNumber=item.PageNumber;
                bookViewModel.TotalCopies = item.TotalCopies;
                bookViewModel.AvialableCopies = item.AvialableCopies;
                bookViewModel.ISBN=item.ISBN;
                bookViewModel.BookLanguages = item.BookLanguages;
                bookViewModel.BookPublishers = item.BookPublishers;
                bookViewModel.BookGenres = item.BookGenres;
                bookViewModel.Reservations = item.Reservations;
                bookViewModel.BookAuthors = item.BookAuthors;
                bookViewModel.BookShalves = item.BookShalves;
                viewModel.Add(bookViewModel);
            }
            return View(viewModel);
        }
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpPost]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            //var bookViewModel = new BookViewModel();
            //bookViewModel.Title = book.Title;
            //bookViewModel.ID = book.ID;
            //bookViewModel.PublicationDate = book.PublicationDate;
            //bookViewModel.Edition = book.Edition;
            //bookViewModel.Reservations = book.Reservations;
            //bookViewModel.PageNumber = book.PageNumber;
            //bookViewModel.TotalCopies = book.TotalCopies;
            //bookViewModel.AvialableCopies = book.AvialableCopies;
            //bookViewModel.ISBN = book.ISBN;
            //bookViewModel.BookLanguages = book.BookLanguages;
            //bookViewModel.BookPublishers = book.BookPublishers;
            //bookViewModel.BookGenres = book.BookGenres;
            //bookViewModel.Reservations = book.Reservations;
            //bookViewModel.BookAuthors = book.BookAuthors;
            //bookViewModel.BookShalves = book.BookShalves;

            var books = new Books();
            books.Title = bookViewModel.Title;
            books.ID = bookViewModel.ID;
            books.PublicationDate = bookViewModel.PublicationDate;
            books.Edition = bookViewModel.Edition;
            books.Reservations = bookViewModel.Reservations;
            books.PageNumber = bookViewModel.PageNumber;
            books.TotalCopies = bookViewModel.TotalCopies;
            books.AvialableCopies = bookViewModel.AvialableCopies;
            books.ISBN = bookViewModel.ISBN;
            books.BookLanguages = bookViewModel.BookLanguages;
            books.BookPublishers = bookViewModel.BookPublishers;
            books.BookGenres = bookViewModel.BookGenres;
            books.Reservations = bookViewModel.Reservations;
            books.BookAuthors = bookViewModel.BookAuthors;
            books.BookShalves = bookViewModel.BookShalves;
            _bookService.CreateBook(books);
            _bookService.SaveBook();
            return View(bookViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(BookViewModel book)
        {
            var booki = _bookService.GetBook(book.ID);
            _bookService.DeleteBook(booki);
            _bookService.SaveBook();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            var books = new Books();
            books.Title = bookViewModel.Title;
            books.ID = bookViewModel.ID;
            books.PublicationDate = bookViewModel.PublicationDate;
            books.Edition = bookViewModel.Edition;
            books.Reservations = bookViewModel.Reservations;
            books.PageNumber = bookViewModel.PageNumber;
            books.TotalCopies = bookViewModel.TotalCopies;
            books.AvialableCopies = bookViewModel.AvialableCopies;
            books.ISBN = bookViewModel.ISBN;
            books.BookLanguages = bookViewModel.BookLanguages;
            books.BookPublishers = bookViewModel.BookPublishers;
            books.BookGenres = bookViewModel.BookGenres;
            books.Reservations = bookViewModel.Reservations;
            books.BookAuthors = bookViewModel.BookAuthors;
            books.BookShalves = bookViewModel.BookShalves;
            _bookService.UpdateBook(books);
            _bookService.SaveBook();
            return View(bookViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var books=_bookService.GetBook(ID);
            var bookViewModel = new BookViewModel();
            bookViewModel.Title = books.Title;
            bookViewModel.ID = books.ID;
            bookViewModel.PublicationDate = books.PublicationDate;
            bookViewModel.Edition = books.Edition;
            bookViewModel.Reservations = books.Reservations;
            bookViewModel.PageNumber = books.PageNumber;
            bookViewModel.TotalCopies = books.TotalCopies;
            bookViewModel.AvialableCopies = books.AvialableCopies;
            bookViewModel.ISBN = books.ISBN;
            bookViewModel.BookLanguages = books.BookLanguages;
            bookViewModel.BookPublishers = books.BookPublishers;
            bookViewModel.BookGenres = books.BookGenres;
            bookViewModel.Reservations = books.Reservations;
            bookViewModel.BookAuthors = books.BookAuthors;
            bookViewModel.BookShalves = books.BookShalves;
            return View(bookViewModel);
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            var books = _bookService.GetBook(ID);
            var bookViewModel = new BookViewModel();
            bookViewModel.Title = books.Title;
            bookViewModel.ID = books.ID;
            bookViewModel.PublicationDate = books.PublicationDate;
            bookViewModel.Edition = books.Edition;
            bookViewModel.Reservations = books.Reservations;
            bookViewModel.PageNumber = books.PageNumber;
            bookViewModel.TotalCopies = books.TotalCopies;
            bookViewModel.AvialableCopies = books.AvialableCopies;
            bookViewModel.ISBN = books.ISBN;
            bookViewModel.BookLanguages = books.BookLanguages;
            bookViewModel.BookPublishers = books.BookPublishers;
            bookViewModel.BookGenres = books.BookGenres;
            bookViewModel.Reservations = books.Reservations;
            bookViewModel.BookAuthors = books.BookAuthors;
            bookViewModel.BookShalves = books.BookShalves;
            return View(bookViewModel);
        }
    }
}