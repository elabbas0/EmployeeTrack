using EmployeeTrack.Models.Entities;
using EmployeeTrack.Data; 
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrack.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public int Create(Employee emp)
        {
            _db.Employees.Add(emp);
            _db.SaveChanges();       // save

            if (emp.Id == 0)
            {
                throw new Exception("Failed to create employee.");
            } 

            return emp.Id; //return the employee id.
        }
        public Employee? GetById(int id)
        {
            if (_db.Employees.Find(id) is Employee emp)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        public Employee? GetByName(string name)
        {

            var find = _db.Employees.FirstOrDefault(e => e.firstName == name);

            if (find is Employee emp)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var emp = _db.Employees.Find(id);

            if (emp != null)
            {
                _db.Employees.Remove(emp);

                _db.SaveChanges();
            } else
            {
                return NotFound($"Employee with ID {id} not found.");
            }

                return Ok($"Employee {emp?.firstName} deleted successfully.");
        }

        [HttpPost]
        public IActionResult DeleteByName(string name) 
        {
            var find = _db.Employees.FirstOrDefault(e => e.firstName == name);

            if (find is Employee emp)
            {
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
            else
            {
                return NotFound($"Employee with name {name} not found.");
            }

            return Ok($"Employee \"{name}\" deleted successfully.");
        }
    }
}