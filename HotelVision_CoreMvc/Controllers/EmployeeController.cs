using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelVision_CoreMvc.Services.Interfaces;
using HotelVision_CoreMvc.Models;

namespace HotelVision_CoreMvc.Controllers
{
    public class EmployeeController : Controller
    {
		private readonly IRepository<Employee> employeesRepository;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IRepository<Employee> employeesRepository, ILogger<EmployeeController> logger)
        {
            this.employeesRepository = employeesRepository;
            this.logger = logger;
        }

        // GET: EmployeeIndex
        public IActionResult EmployeeIndex()
        {
            return View(employeesRepository.GetAll());
        }

        // GET: Employee/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var employee = employeesRepository.GetAll().FirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee([Bind("Id,FirstName,LastName,City,State,Country,Zip,Phone,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeesRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

			var employee = employeesRepository.Get((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,City,State,Country,Zip,Phone,Email")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employeesRepository.Edit(employee);
                }
                catch (Exception ex)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        logger.LogError(ex.Message);
                    }
                }
                return RedirectToAction("EmployeeIndex", "Employee");
            }
            return View(employee);
        }

        // GET: Employee/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = employeesRepository.Get((int)id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employeesRepository.Get(id);
            employeesRepository.Delete(employee);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return employeesRepository.Get(id) != null;
        }
    }
}
