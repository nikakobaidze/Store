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

    public class AddPublisherController : Controller
    {
        // GET: AddPosition
        public ActionResult AddPosition()
        {
            return View();
        }
        private readonly IPublisherService _publisherService;

        public AddPublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Index()
        {
            var model = _publisherService.GetPublisher();
            var viewModel = new List<PublisherViewModel> { };
            foreach (var item in model)
            {
                var publisherViewModel = new PublisherViewModel();
                publisherViewModel.ID = item.ID;
                publisherViewModel.Address = item.Address;
                publisherViewModel.PhoneNumber = item.PhoneNumber;
                publisherViewModel.Name = item.Name;
                publisherViewModel.Email = item.Email;
                publisherViewModel.BookPublishers = item.BookPublishers;
                viewModel.Add(publisherViewModel);
            }
            return View(viewModel);
        }
        //public ActionResult Create()
        //{
        //    //_publisherService.CreatePublisher(publisher);
        //    //_publisherService.SavePublisher();
        //    return View(); 
        //}

        [HttpPost]
        public ActionResult Create(PublisherViewModel publisherViewModel)
        {
            //var publisherViewModel = new PublisherViewModel();
            //publisherViewModel.ID = publisher.ID;
            //publisherViewModel.Address = publisher.Address;
            //publisherViewModel.PhoneNumber = publisher.PhoneNumber;
            //publisherViewModel.Name = publisher.Name;
            //publisherViewModel.Email = publisher.Email;
            //publisherViewModel.BookPublishers = publisher.BookPublishers;
            if (!ModelState.IsValid) 
                return View(publisherViewModel);

            var publisher = new Publishers();
            publisher.ID = publisherViewModel.ID;
            publisher.Address = publisherViewModel.Address;
            publisher.PhoneNumber = publisherViewModel.PhoneNumber;
            publisher.Name = publisherViewModel.Name;
            publisher.Email = publisherViewModel.Email;
            publisher.BookPublishers = publisherViewModel.BookPublishers;

            //var model = _publisherService.GetPublisher();
            // var viewModel = new List<PublisherViewModel> { };
            //viewModel.Add(publisherViewModel);
            _publisherService.CreatePublisher(publisher);
            _publisherService.SavePublisher();
            return View(publisherViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(PublisherViewModel publisher)
        {
            var publisheri = _publisherService.GetPublisher(publisher.ID);
            _publisherService.DeletePublisher(publisheri);
            _publisherService.SavePublisher();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(PublisherViewModel publisherViewModel)
        {
            var publisher = new Publishers();
            publisher.ID = publisherViewModel.ID;
            publisher.Address = publisherViewModel.Address;
            publisher.PhoneNumber = publisherViewModel.PhoneNumber;
            publisher.Name = publisherViewModel.Name;
            publisher.Email = publisherViewModel.Email;
            publisher.BookPublishers = publisherViewModel.BookPublishers;
            //var viewModel = new List<PublisherViewModel> { };
            //viewModel.Add(publisherViewModel);
            _publisherService.UpdatePublisher(publisher);
            _publisherService.SavePublisher();
            return View(publisherViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var publisher = _publisherService.GetPublisher(ID);
            var publisherViewModel = new PublisherViewModel();
            publisherViewModel.ID = publisher.ID;
            publisherViewModel.Address = publisher.Address;
            publisherViewModel.PhoneNumber = publisher.PhoneNumber;
            publisherViewModel.Name = publisher.Name;
            publisherViewModel.Email = publisher.Email;
            publisherViewModel.BookPublishers = publisher.BookPublishers;

            return View(publisherViewModel);
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            var publisher = _publisherService.GetPublisher(ID);
            var publisherViewModel = new PublisherViewModel();
            publisherViewModel.ID = publisher.ID;
            publisherViewModel.Address = publisher.Address;
            publisherViewModel.PhoneNumber = publisher.PhoneNumber;
            publisherViewModel.Name = publisher.Name;
            publisherViewModel.Email = publisher.Email;
            publisherViewModel.BookPublishers = publisher.BookPublishers;

            return View(publisherViewModel);
        }
        //[HttpPost]
        //public ActionResult Add(Publishers publisher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Set the CreateDate
        //        publisher.CreateDate = DateTime.Now;

        //        _publisherService.CreatePublisher(publisher);
        //        _publisherService.SavePublisher();

        //        return RedirectToAction("Index", "Home"); // Redirect to home page or any other page after adding
        //    }

        //    return View(); // If the model state is invalid, return the view with validation errors
        //}
    }
}