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
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            var model = _languageService.GetLanguage();
            var viewModel = new List<LanguageViewModel>();
            foreach (var item in model)
            {
                var languageViewModel = new LanguageViewModel();
                languageViewModel.ID = item.ID;
                languageViewModel.Language = item.Language;
                viewModel.Add(languageViewModel);
            }
            return View(viewModel);
        }
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languagenService)
        {
            _languageService = languagenService;
        }

        [HttpPost]
        public ActionResult Create(LanguageViewModel languageViewModel)
        {
            //var languageViewModel = new LanguageViewModel();
            //languageViewModel.ID = language.ID;
            //languageViewModel.Language = language.Language;
            var language = new Languages();
            language.ID = languageViewModel.ID;
            language.Language = languageViewModel.Language;
            _languageService.CreateLanguage(language);
            _languageService.SaveLanguage();
            return View(languageViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(LanguageViewModel language)
        {
            var languag = _languageService.GetLanguage(language.ID);
            _languageService.DeleteLanguage(languag);
            _languageService.SaveLanguage();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(LanguageViewModel languageViewModel)
        {
            var language = new Languages();
            language.ID = languageViewModel.ID;
            language.Language = languageViewModel.Language;
            _languageService.UpdateLanguage(language);
            _languageService.SaveLanguage();
            return View(languageViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var language = _languageService.GetLanguage(ID);
            var languageViewModel = new LanguageViewModel();
            languageViewModel.ID = language.ID;
            languageViewModel.Language = language.Language;
            return View(languageViewModel);
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            var language = _languageService.GetLanguage(ID);
            var languageViewModel = new LanguageViewModel();
            languageViewModel.ID = language.ID;
            languageViewModel.Language = language.Language;
            return View(languageViewModel);
        }
    }
}
