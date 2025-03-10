using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        public async Task<IResult> AddTask(Tasks newTask)
        {
            if (newTask == null)
                return Results.BadRequest("Task data is required.");

            // 🔵 Assign Default Status (if not provided)
            if (newTask.StatusId == 0)
            {
                var defaultStatus = await appDbContext.Statuses.FirstOrDefaultAsync();
                if (defaultStatus == null)
                    return Results.BadRequest("No default status found.");

                newTask.StatusId = defaultStatus.Status_Id;
            }

            // 🔵 Save Task First (Ensures task_Id is generated)
            await appDbContext.Taskss.AddAsync(newTask);
            await appDbContext.SaveChangesAsync(); // ✅ Task now has an ID

            // 🔵 Fetch and Assign TaskStatus
            var taskStatus = await appDbContext.Statuses
                .FirstOrDefaultAsync(ts => ts.Status_Id == newTask.StatusId);

            if (taskStatus != null)
            {
                newTask.TaskStatus = taskStatus;
            }

            // 🔵 Update EmployeeTasks and TaskTags with Correct Task ID
            foreach (var employeeTask in newTask.EmployeeTasks)
            {
                employeeTask.TaskId = newTask.Task_Id; // ✅ Assign generated Task ID
            }

            foreach (var taskTag in newTask.TaskTags)
            {
                taskTag.TaskId = newTask.Task_Id; // ✅ Assign generated Task ID
            }

            await appDbContext.SaveChangesAsync(); // ✅ Save relationships

            return Results.Ok(newTask);
        }











        public async Task<IResult> GetAllTasks()
        {
            var tasks = await appDbContext.Taskss
                .Include(t => t.TaskStatus)
                .Include(t => t.EmployeeTasks).ThenInclude(et => et.Employee)
                .Include(t => t.TaskTags).ThenInclude(tt => tt.Tag)
                .Select(t => new TaskDTO
                {
                    Task_Id = t.Task_Id,
                    Task_Title = t.Task_Title,
                    Deadline = t.Deadline,
                    StatusId = t.StatusId,
                    TaskStatus = t.TaskStatus != null ? new TaskStatusDTO
                    {
                        Id = t.TaskStatus.Status_Id,
                        Status_Name = t.TaskStatus.Status_Name
                    } : null,
                    EmployeeTasks = t.EmployeeTasks.Select(et => new EmployeeTaskDTO
                    {
                        Id = et.Id,
                        EmpId = et.EmpId,
                        Employee = et.Employee != null ? new EmployeeDTO
                        {
                            Emp_Id = et.Employee.Emp_Id,
                            Employee_Name = et.Employee.Employee_Name
                        } : null
                    }).ToList(),
                    TaskTags = t.TaskTags.Select(tt => new TaskTagDTO
                    {
                        Id = tt.Id,
                        TagId = tt.TagId,
                        Tag = tt.Tag != null ? new TagDTO
                        {
                            Tag_Id = tt.Tag.Tag_Id,
                            Tag_Name = tt.Tag.Tag_Name
                        } : null
                    }).ToList()
                })
                .ToListAsync();

            return Results.Ok(tasks);
        }




        // 🔵 Get Task by ID
        public async Task<Tasks> getTasksById(int id)
        {
            var task = await appDbContext.Taskss
                .Include(t => t.EmployeeTasks)
                    .ThenInclude(et => et.Employee)
                .Include(t => t.TaskTags)
                    .ThenInclude(tt => tt.Tag)
                .Include(t => t.TaskStatus)  // 🔹 Include the status
                .FirstOrDefaultAsync(t => t.Task_Id == id);

            return task ?? null;
        }


    }
}
