using EmployeeTrack.Models.Entities;
using EmployeeTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrack.Controllers
{
    public class VisitController : Controller
    {
        private readonly AppDbContext _db;
        public VisitController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Create(Visit visit)
        {
            _db.Visits.Add(visit);
            _db.SaveChanges();

            if (visit.Id == 0)
            {
                return BadRequest("Failed to create visit record.");
            }

            return Ok(visit.Id);
        }

        public Visit? GetById(int id)
        {
            return _db.Visits.Find(id);
        }


        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var visit = _db.Visits.Find(id);

            if (visit != null)
            {
                _db.Visits.Remove(visit);
                _db.SaveChanges();
                return Ok($"Visit ID {id} deleted successfully.");
            }

            return NotFound($"Visit with ID {id} not found.");
        }
    }
}