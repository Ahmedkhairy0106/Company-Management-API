using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyAPI.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [JsonIgnore] // تغيير اسم الخاصية في جيسون لتجنب الحلقات الدائرية
        public ICollection<Employee>? Employees { get; set; }
    }
}