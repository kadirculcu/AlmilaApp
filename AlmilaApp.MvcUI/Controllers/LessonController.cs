using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmilaApp.Business.Abstract;
using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AlmilaApp.MvcUI.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IActionResult Index()
        {
            var viewModel = new LessonsViewModel();
            viewModel.Lesson = _lessonService.GetList();

            return View(viewModel);

        }
        public IActionResult Lesson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Lesson(LessonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _lessonService.Add(viewModel.Lesson);
            }
            return RedirectToAction("Index");
        }
    }
}