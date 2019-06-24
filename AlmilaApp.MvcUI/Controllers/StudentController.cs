using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmilaApp.Business.Abstract;
using AlmilaApp.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AlmilaApp.MvcUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Student(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _studentService.Add(viewModel.Student);
            }
            return RedirectToAction("StudentList");
        }
        public IActionResult StudentList()
        {
            var viewModel = new StudentsViewModel();
            viewModel.Student = _studentService.GetAll();

            return View(viewModel);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            _studentService.Delete(id);
            return RedirectToAction("StudentList");
        }
        public IActionResult UpdateStudent()
        {
            return View();
        }
        public IActionResult StudentUpdate()
        {
            return View();
        }
    }
}