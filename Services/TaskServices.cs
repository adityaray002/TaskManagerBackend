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

        public async Task<IResult> AddTask(Tasks task)
        {
           
            
            appDbContext.Taskss.Add(task);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(task);
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            //return await appDbContext.Taskss.ToListAsync();
            ////return await appDbContext.EmployeeTaskMappings
            ////.Include(etm => etm.Task)
            ////.Include(etm => etm.Employee)
            ////.ToListAsync();

            return await appDbContext.Taskss
        .Include(t => t.EmployeeTasks)  // Include EmployeeTaskMappings
        .ThenInclude(etm => etm.Employee) // Include Employee details
        .Include(t => t.TaskTags)
        .ThenInclude(tag => tag.Tag)
        .Include(t => t.TaskStatuses)
        .ThenInclude(s => s.Status)
        .ToListAsync();
        }
    }
}
