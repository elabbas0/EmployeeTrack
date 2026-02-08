using EmployeeTrack.Data;
using EmployeeTrack.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrack.Controllers
{
    public class EmployeesController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public IActionResult Index()
        {
<<<<<<< HEAD
            ViewBag.Positions = _context.Positions
                .Select(p => new { p.Id, p.Name })
                .ToList();

            return View();
=======
            var model = await _context.Employees
                .Include(e => e.Position)
                .Include(e => e.Country)
                .ToListAsync();
            return View(model);
>>>>>>> 9d8db6c58a43ab538732866f46d758c10c3ca2c4
        }

        // DATATABLES LOAD ENDPOINT
        [HttpPost]
        public async Task<IActionResult> Load()
        {
            var query = _context.Employees
                .Include(e => e.Position)
                .AsQueryable();

            // DataTables standard params
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");

            // Custom filters
            var positionIds = Request.Form["col.PositionId"].ToString();
            var nameQuery = Request.Form["col.NameQuery"].ToString();
            var createdStart = Request.Form["col.CreatedStart"].ToString();
            var createdEnd = Request.Form["col.CreatedEnd"].ToString();

            // ---- FILTERING ----

            if (!string.IsNullOrWhiteSpace(positionIds))
            {
                var ids = positionIds.Split(',')
                    .Select(int.Parse)
                    .ToList();

                query = query.Where(e => ids.Contains(e.PositionId));
            }

            if (!string.IsNullOrWhiteSpace(nameQuery))
            {
                query = query.Where(e => e.FirstName.Contains(nameQuery));
            }

            if (!string.IsNullOrWhiteSpace(createdStart) &&
                DateTime.TryParse(createdStart, out var startDate))
            {
                query = query.Where(e => e.CreatedAt >= startDate);
            }

            if (!string.IsNullOrWhiteSpace(createdEnd) &&
                DateTime.TryParse(createdEnd, out var endDate))
            {
                query = query.Where(e => e.CreatedAt <= endDate);
            }

            var recordsTotal = await _context.Employees.CountAsync();
            var recordsFiltered = await query.CountAsync();

            // ---- PAGINATION ----
            var data = await query
                .OrderByDescending(e => e.CreatedAt)
                .Skip(start)
                .Take(length)
                .Select(e => new
                {
                    id = e.Id,
                    name = e.FirstName,
                    position = e.Position.Name,
                    createdAt = e.CreatedAt.ToString("yyyy-MM-dd")
                })
                .ToListAsync();

            return Json(new
            {
                draw,
                recordsTotal,
                recordsFiltered,
                data
            });
        }

        // ----- CREATE -----

        public IActionResult Create()
        {
            ViewData["PositionId"] =
                new SelectList(_context.Positions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee entity)
        {
            if (!ModelState.IsValid)
            {
                ViewData["PositionId"] =
                    new SelectList(_context.Positions, "Id", "Name", entity.PositionId);
                return View(entity);
            }

            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ----- EDIT -----

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            ViewData["PositionId"] =
                new SelectList(_context.Positions, "Id", "Name", employee.PositionId);

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["PositionId"] =
                    new SelectList(_context.Positions, "Id", "Name", employee.PositionId);
                return View(employee);
            }

            try
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // ----- DELETE -----

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees
                .Include(e => e.Position)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
