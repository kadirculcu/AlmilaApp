using AlmilaApp.Business.Abstract;
using AlmilaApp.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmilaApp.MvcUI.ViewComponents
{
    public class LessonListViewComponent:ViewComponent
    {
        private readonly ILessonService _lessonService;
        public LessonListViewComponent(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new LessonListViewModel
            {
                Lessons=_lessonService.GetList()
            };
            return View(model);
        }
    }
}
