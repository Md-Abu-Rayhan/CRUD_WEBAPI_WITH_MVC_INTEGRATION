using EmployeeMVCApp.Models;
using EmployeeMVCApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;


        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.InsertEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var employee = employees.Find(e => e.Id == id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
