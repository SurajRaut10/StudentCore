using Microsoft.AspNetCore.Mvc;
using StudentCore.Models;
using System.Diagnostics;

namespace StudentCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StudentContext c1;

        public HomeController(ILogger<HomeController> logger, StudentContext c1)
        {
            _logger = logger;
            this.c1 = c1;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var t=c1.Students.ToList();
            return View(t);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(String Sname,String Address,String Semail,String Smobno,String Gender,String Course)
        {
            try
            {
                Student st = new Student();
                st.Sname = Sname;
                st.Address = Address;
                st.Semail = Semail;
                st.Smobno = Smobno;
                st.Gender = Gender;
                st.Course = Course;

                c1.Students.Add(st);
                c1.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
            var r=c1.Students.Where(x=>x.Sid==id).FirstOrDefault();
            return View(r);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var r = c1.Students.Where(x => x.Sid == id).FirstOrDefault();
            c1.Students.Remove(r);
            c1.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var student = c1.Students.Where(x => x.Sid == id).FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int Id, String Name, String Address, String email, String mobno, String gender, String course)
        {
            if (string.IsNullOrEmpty(course))
            {
                // Handle the case when course is not selected
                ModelState.AddModelError("Course", "Please select a course.");
                // Reload the student data to redisplay the form with an error message
                var student = c1.Students.Where(x => x.Sid == Id).FirstOrDefault();
                return View(student);
            }

            Student s = new Student
            {
                Sid = Id,
                Sname = Name,
                Address = Address,
                Semail = email,
                Smobno = mobno,
                Gender = gender,
                Course = course
            };

            c1.Students.Update(s);
            c1.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
