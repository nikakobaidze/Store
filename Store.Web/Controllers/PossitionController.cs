using DocumentFormat.OpenXml.Drawing;
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
    public class PossitionController : Controller
    {
        // GET: Possition
        public ActionResult Index()
        {
            var model = _positionService.GetPosition();
            var viewModel = new List<PossitionViewModel>();
            foreach(var item in model)
            {
                var possitionViewModel=new PossitionViewModel();
                possitionViewModel.ID = item.ID;
                possitionViewModel.PositionTitle=item.PositionTitle;
                possitionViewModel.EmployeePositions = item.EmployeePositions;
                viewModel.Add(possitionViewModel);
            }
            return View(viewModel);
        }
        private readonly IPositionService _positionService;
        public PossitionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost]
        public ActionResult Create(PossitionViewModel positionViewModel)
        {
            //var possitionViewModel = new PossitionViewModel();
            //possitionViewModel.ID = position.ID;
            //possitionViewModel.PositionTitle = position.PositionTitle;
            //possitionViewModel.EmployeePositions = position.EmployeePositions;

            var position = new Positions();
            position.ID = positionViewModel.ID;
            position.PositionTitle = positionViewModel.PositionTitle;
            position.EmployeePositions = positionViewModel.EmployeePositions;
            _positionService.CreatePosition(position);
            _positionService.SavePosition();
            return View(positionViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(PossitionViewModel position)
        {
            var positioni = _positionService.GetPosition(position.ID);
            _positionService.DeletePosition(positioni);
            _positionService.SavePosition();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(PossitionViewModel positionViewModel)
        {
            var position = new Positions();
            position.ID = positionViewModel.ID;
            position.PositionTitle = positionViewModel.PositionTitle;
            position.EmployeePositions = positionViewModel.EmployeePositions;
            _positionService.UpdatePosition(position);
            _positionService.SavePosition();
            return View(positionViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var position = _positionService.GetPosition(ID);
            var possitionViewModel = new PossitionViewModel();
            possitionViewModel.ID = position.ID;
            possitionViewModel.PositionTitle = position.PositionTitle;
            possitionViewModel.EmployeePositions = position.EmployeePositions;
            return View(possitionViewModel);

        }
        public ActionResult Details(int ID)
        {
            var position = _positionService.GetPosition(ID);
            var possitionViewModel = new PossitionViewModel();
            possitionViewModel.ID = position.ID;
            possitionViewModel.PositionTitle = position.PositionTitle;
            possitionViewModel.EmployeePositions = position.EmployeePositions;
            return View(possitionViewModel);
        }
    }
}