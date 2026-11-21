
using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        // Temporary storage for registered students
        private static List<Student> students = new List<Student>();

        // Display student list
        public IActionResult Index()
        {
            return View(students);
        }

        // Open registration form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Receive registration form data
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // Display individual student details
        public IActionResult Details(int id)
        {
            Student? student = students.Find(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
