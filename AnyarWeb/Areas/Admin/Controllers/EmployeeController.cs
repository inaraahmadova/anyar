
using AnyarWeb.DataAccesLayer;
using AnyarWeb.Models;
using AnyarWeb.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyarWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly AnyarContext _context;

        public EmployeeController(AnyarContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Employees.Select(e => new GetEmployeeVM
            {
                Id = e.Id,
                Name = e.Name,
                Subtitle = e.Subtitle,
                ImageUrl = e.ImageUrl
            }).ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Employee employee = new Employee
            {
                Name = vm.Name,
                Subtitle = vm.Subtitle,
                ImageUrl = vm.ImageUrl
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            UpdateEmployeeVM employeeVM = new UpdateEmployeeVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Subtitle = employee.Subtitle,
                ImageUrl = employee.ImageUrl
            };

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateEmployeeVM employeeVM)
        {
            if (id == null || id < 1) return BadRequest();

            Employee existed = await _context.Employees.FindAsync(id);
            if (existed == null) return NotFound();

            existed.Name = employeeVM.Name;
            existed.Subtitle = employeeVM.Subtitle;
            existed.ImageUrl = employeeVM.ImageUrl;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var item = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
