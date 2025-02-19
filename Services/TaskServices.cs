using Microsoft.EntityFrameworkCore;
using Task_Manager_Backend.Data;

namespace Task_Manager_Backend.Services
{
    public class TaskServices
    {
        private readonly AppDbContext appDbContext;

        public TaskServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IResult> AddTask(Tasks task)
        {
            appDbContext.Taskss.Add(task);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(task);
        }

        public async Task<List<TaskDTO>> GetAllTasks()
        {
            var tasks = await appDbContext.Taskss
                .Include(t => t.EmployeeTasks)
                    .ThenInclude(et => et.Employee)
                .Include(t => t.TaskTags)
                    .ThenInclude(tt => tt.Tag)
                .Include(t => t.TaskStatuses)
                    .ThenInclude(ts => ts.Status)
                .ToListAsync();

            return tasks.Select(t => new TaskDTO
            {
                Task_Id = t.Task_Id,
                Task_Title = t.Task_Title,
                Deadline = t.Deadline,
                Employees = t.EmployeeTasks.Select(et => new EmployeeDTO
                {
                    EmployeeId = et.Employee.Emp_Id,
                    EmployeeName = et.Employee.Employee_Name
                }).ToList(),
                Tags = t.TaskTags.Select(tt => new TagDTO
                {
                    TagId = tt.Tag.Tag_Id,
                    TagName = tt.Tag.Tag_Name
                }).ToList(),
                Statuses = t.TaskStatuses.Select(ts => new StatusDTO
                {
                    StatusId = ts.Status.Status_Id,
                    StatusName = ts.Status.Status_Name
                }).ToList()
            }).ToList();
        }
    }
}
