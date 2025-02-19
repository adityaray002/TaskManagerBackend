using Microsoft.EntityFrameworkCore;

namespace Task_Manager_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tasks> Taskss { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<EmployeeTaskMapping> EmployeeTaskMappings { get; set; }
        public DbSet<TaskTagMapping> TaskTagMappings { get; set; }
        public DbSet<TaskStatusMapping> TaskStatusMappings { get; set; }
    }
}
