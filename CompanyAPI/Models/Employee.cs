using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }

        public int DepartmentId { get; set; } // FK - Should be here to swagger use it instead of all model
        // في كل موظف ، هيكون فيه خاصية اسمها قسم، ونوعها هو الكلاس قسم
        [ForeignKey("DepartmentId")]
        [JsonIgnore] // تغيير اسم الخاصية في جيسون لتجنب الحلقات الدائرية
        public Department? Department { get; set; } // Navigation property
    }
}