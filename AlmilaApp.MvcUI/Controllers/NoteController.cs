using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmilaApp.Business.Abstract;
using AlmilaApp.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AlmilaApp.MvcUI.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService notService)
        {
            _noteService = notService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Note()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Note(NoteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _noteService.Add(viewModel.Note);
            }
            return RedirectToAction("Note");
        }
        public IActionResult NoteList()
        {
            var viewModel = new NotesViewModel();
            viewModel.Notes = _noteService.GetNotesAllInformations();
            return View(viewModel);
        }
    }
}