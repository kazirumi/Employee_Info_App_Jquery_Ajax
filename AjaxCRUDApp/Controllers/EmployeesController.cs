using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AjaxCRUDApp.Models;

namespace AjaxCRUDApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AjaxCRUDAppContext _context;

        public EmployeesController(AjaxCRUDAppContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }



        // GET: Employees/AddOrEdit
        // GET: Employees/AddOrEdit/5
      
        public IActionResult AddOrEdit(int? EmployeeID = 0)
        {
            if (EmployeeID == 0)
            {
                return View(new Employee());
            }
            else
            {
                Employee employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == EmployeeID);
                if (employee == null)
                {
                    return NotFound();

                }

                return View(employee);
            }
            
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,Name,ContactNumber,Address,JoiningDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("EmployeeID,Name,ContactNumber,Address,JoiningDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();

                   
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(employee);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!EmployeeExists(employee.EmployeeID))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        
                        
                    }

                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Employee.ToList()) });
            }



            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", employee) });
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

             
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return View("_ViewAll", _context.Employee.ToList());
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}
