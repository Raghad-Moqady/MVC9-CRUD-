using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var employees= context.Employees.ToList();
            return View(employees);
        }
        public IActionResult GoBack()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var employees = context.Employees.Find(id);
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var employee = context.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)//New employee's Data
        {
            var currectEmployee =context.Employees.Find(employee.Id);
            if (currectEmployee != null)
            {
                currectEmployee.Name = employee.Name;
                currectEmployee.Email = employee.Email;
                currectEmployee.Password = employee.Password;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //حذف نهائي من الداتابيس
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
