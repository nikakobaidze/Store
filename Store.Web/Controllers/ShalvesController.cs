using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public class ShalvesController : Controller
    {
        // GET: Shalves
        public ActionResult Index()
        {
            var model = _shalveService.GetShelf();
            var viewModel = new List<ShalvesViewModel>();
            foreach(var item in model)
            {
                var shelfViewModel = new ShalvesViewModel();
                shelfViewModel.ID=item.ID;
                shelfViewModel.Floor=item.Floor;
                shelfViewModel.Shelf = item.Shelf;
                shelfViewModel.Room=item.Room;
                shelfViewModel.Section=item.Section;
                shelfViewModel.Row=item.Row;
                shelfViewModel.BookShalves = item.BookShalves;
                viewModel.Add(shelfViewModel);
            }
            return View(viewModel);
        }
        private readonly IShelveService _shalveService;
        public ShalvesController(IShelveService shalveService)
        {
            _shalveService = shalveService;
        }

        [HttpPost]
        public ActionResult Create(ShalvesViewModel shalvesViewModel)
        {
            //var shelfViewModel=new ShalvesViewModel();
            //shelfViewModel.ID = Shelf.ID;
            //shelfViewModel.Floor = Shelf.Floor;
            //shelfViewModel.Shelf = Shelf.Shelf;
            //shelfViewModel.Room = Shelf.Room;
            //shelfViewModel.Section = Shelf.Section;
            //shelfViewModel.Row = Shelf.Row;
            //shelfViewModel.BookShalves = Shelf.BookShalves;

            var shelf = new Shalves();
            shelf.ID = shalvesViewModel.ID;
            shelf.Floor = shalvesViewModel.Floor;
            shelf.Shelf = shalvesViewModel.Shelf;
            shelf.Room = shalvesViewModel.Room;
            shelf.Section = shalvesViewModel.Section;
            shelf.Row = shalvesViewModel.Row;
            shelf.BookShalves = shalvesViewModel.BookShalves;
            _shalveService.CreateShelf(shelf);
            _shalveService.SaveShelf();
            return View(shalvesViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(ShalvesViewModel Shelf)
        {
            var Shelfi = _shalveService.GetShelf(Shelf.ID);
            _shalveService.DeleteShelf(Shelfi);
            _shalveService.SaveShelf();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(ShalvesViewModel shalvesViewModel)
        {
            var shelf = new Shalves();
            shelf.ID = shalvesViewModel.ID;
            shelf.Floor = shalvesViewModel.Floor;
            shelf.Shelf = shalvesViewModel.Shelf;
            shelf.Room = shalvesViewModel.Room;
            shelf.Section = shalvesViewModel.Section;
            shelf.Row = shalvesViewModel.Row;
            shelf.BookShalves = shalvesViewModel.BookShalves;
            _shalveService.UpdateShelf(shelf);
            _shalveService.SaveShelf();
            return View(shalvesViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var Shelf = _shalveService.GetShelf(ID);
            var shelfViewModel = new ShalvesViewModel();
            shelfViewModel.ID = Shelf.ID;
            shelfViewModel.Floor = Shelf.Floor;
            shelfViewModel.Shelf = Shelf.Shelf;
            shelfViewModel.Room = Shelf.Room;
            shelfViewModel.Section = Shelf.Section;
            shelfViewModel.Row = Shelf.Row;
            shelfViewModel.BookShalves = Shelf.BookShalves;
            return View(shelfViewModel);
        }
        public ActionResult Details(int ID)
        {
            var Shelf = _shalveService.GetShelf(ID);
            var shelfViewModel = new ShalvesViewModel();
            shelfViewModel.ID = Shelf.ID;
            shelfViewModel.Floor = Shelf.Floor;
            shelfViewModel.Shelf = Shelf.Shelf;
            shelfViewModel.Room = Shelf.Room;
            shelfViewModel.Section = Shelf.Section;
            shelfViewModel.Row = Shelf.Row;
            shelfViewModel.BookShalves = Shelf.BookShalves;
            return View(shelfViewModel);
        }
    }
}