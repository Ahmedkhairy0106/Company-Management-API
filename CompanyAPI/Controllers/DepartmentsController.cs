using CompanyAPI.Database;
using CompanyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // Declare a private readonly variable of type CompanyContext (reference to the database).
        private readonly CompanyContext _context;

        public DepartmentsController(CompanyContext context)
        {
            _context = context; // _context is injected via constructor
        }

        // method here
        [HttpGet] // this is verb
        public ActionResult GetAll() // this is action
        {
            var depts = _context.Departments.Select(a => new {
                a.DepartmentId,
                a.Name,
                a.Location,
                a.Description,
                EmployeeNames = a.Employees.Select(emp => emp.Name).ToList()
            }).ToList();
            return Ok(depts);
        }


        //[HttpGet]
        //[Route("{id}")]

        // another method
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Departments.Add(department);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { Id = department.DepartmentId }, new { Message = "Created Successfully" });
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            var deptFromDataBase = _context.Departments.Find(id);
            if (deptFromDataBase == null)
            {
                return NotFound();
            }

            deptFromDataBase.Name = department.Name;
            deptFromDataBase.Location = department.Location;
            deptFromDataBase.Description = department.Description;
            _context.SaveChanges();

            return Ok(deptFromDataBase);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deptFromDataBase = _context.Departments.Find(id);
            if (deptFromDataBase == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(deptFromDataBase);
            _context.SaveChanges();

            return NoContent();
        }
    }
}