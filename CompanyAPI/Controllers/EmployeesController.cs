using CompanyAPI.Database;
using CompanyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public EmployeesController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var emp = _context.Employees.Select(e => new {
                e.EmployeeId,
                e.Name,
                e.Email,
                e.Salary,
                e.DepartmentId
            }).ToList();

            return Ok(emp);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid) // check if the incoming model (Employee) is valid according to data annotations (like [Required], [MaxLength], etc.)
                return BadRequest(ModelState); // return 400 Bad Request with details about validation errors

            if (employee.DepartmentId == 0)
            {
                return BadRequest("DepartmentId is required");
            }

            var department = _context.Departments.Find(employee.DepartmentId);
            if (department == null)
            {
                return NotFound("Department not found");
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, new { Message = "Created Successfully" });
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var empFromDataBase = _context.Employees.Find(id);
            if (empFromDataBase == null)
            {
                return NotFound();
            }

            var dept = _context.Departments.Find(employee.DepartmentId);
            if (dept == null)
            {
                return BadRequest("New department ID not found in database");
            }

            empFromDataBase.DepartmentId = employee.DepartmentId;
            empFromDataBase.Salary = employee.Salary;
            empFromDataBase.Name = employee.Name;
            empFromDataBase.Email = employee.Email;

            _context.SaveChanges();

            return Ok(empFromDataBase);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
