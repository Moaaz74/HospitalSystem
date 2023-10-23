using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Models;
using HospitalSystem.Repositories;
using HospitalSystem.Services;

namespace HospitalSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _deptService;

        public DepartmentsController(IDepartmentService deptService)
        {
            _deptService = deptService;
        }

        // GET: Departments
        public IActionResult Index(int PageNumber = 1, int PageSize = 10)
        {
            return _deptService != null ?
                        View(_deptService.GetAll(PageNumber, PageSize)) :
                        Problem("Entity set 'ApplicationDbContext.Departments'  is null.");
        }

        // GET: Departments/Details/5
        public IActionResult Details(int id)
        {

            var department = _deptService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Type,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                _deptService.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Edit(int id)
        {

            var department = _deptService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Type,Description")] Department department)
        {

            if (ModelState.IsValid)
            {
                _deptService.UpdateDepartment(department);
                RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public IActionResult Delete(int id)
        {


            var department = _deptService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _deptService.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
