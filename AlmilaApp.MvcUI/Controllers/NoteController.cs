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
            return RedirectToAction("NoteList");
        }
        public IActionResult NoteList()
        {
            var viewModel = new NotesViewModel();
            viewModel.Notes = _noteService.GetNotesAllInformations();
            return View(viewModel);
        }
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var viewModel = new NoteViewModel();
            viewModel.Note = _noteService.Get(p => p.Id == id);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(NoteViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                _noteService.Update(viewModel.Note);
            }
            return RedirectToAction("NoteList");
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            _noteService.Delete(id);
            return RedirectToAction("NoteList");
        }
    }
}