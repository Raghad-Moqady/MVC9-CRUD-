using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //AsNoTracking()==>لا تهتم بأي تعديل او تغيير او حفظ تغييرات ..فقط تستخدم لعرض الداتا 
            //High Performance
            var employees= _context.Employees.AsNoTracking().ToList();
            return View(employees);
        }
        public IActionResult GoBack()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var employees = _context.Employees.Find(id);
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var employee = _context.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)//New employee's Data
        {
            var currectEmployee = _context.Employees.Find(employee.Id);
            if (currectEmployee != null)
            {
                currectEmployee.Name = employee.Name;
                currectEmployee.Email = employee.Email;
                currectEmployee.Password = employee.Password;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //حذف نهائي من الداتابيس
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
