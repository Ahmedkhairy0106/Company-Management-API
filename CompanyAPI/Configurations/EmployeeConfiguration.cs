using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyAPI.Controllers
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(a => a.Salary)
                .IsRequired()
                .HasDefaultValue(5000);

            builder.Property(a => a.Name)
                .IsRequired();

            builder.Property(a => a.Email)
                .IsRequired();
        }
    }
}