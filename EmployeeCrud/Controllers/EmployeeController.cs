using EmployeeCrud.Data;
using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employee = _context.employees.ToList();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if(ModelState.IsValid)
            {
                _context.Add(employee);
                _context.SaveChanges();
                TempData["success"] = "Employee Created successfully";
                return RedirectToAction("Index");
            }
            return View("Employee Create Successfully");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.employees.Find(id);
            
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel employee)
        {
            if(employee != null)
            {
                _context.employees.Update(employee);
                _context.SaveChanges();
               TempData["success"] = "Employee update successfully";
                return RedirectToAction("Index");

            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var employee = _context.employees.Find(id);
                return View(employee);

            }
            return View();
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            if(id > 0)
            {
                var employee = _context.employees.Find(id);
                _context.Remove(employee);
                _context.SaveChanges();
                TempData["success"] = "Employee deleted successfully";
                return RedirectToAction("Index");
            }
            return View("Employee Delete successfully");
        }


    }
}
