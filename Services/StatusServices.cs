using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Task_Manager_Backend.Data;

namespace Task_Manager_Backend.Services
{
    public class StatusServices
    {
        public readonly AppDbContext appDbContext;

        public StatusServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IResult> AddStatus([FromBody] Status status)
        {


            appDbContext.Statuses.Add(status);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(status);
        }
        
        public async Task<IResult> GetAllStatus()
        {
            List<Status> status = await appDbContext.Statuses.ToListAsync();
            return Results.Ok(status);


        }


        public async Task<IResult> UpdateStatus([FromBody] UpdateStatusDTO request)
        {
            var task = await appDbContext.Taskss
                .FirstOrDefaultAsync(t => t.Task_Id == request.TaskId);

            if (task == null)
            {
                return Results.NotFound("Task not found");
            }

            // 🔹 Check if the provided StatusId exists in the database
            var statusExists = await appDbContext.Statuses.AnyAsync(s => s.Status_Id == request.NewStatusId);
            if (!statusExists)
            {
                return Results.BadRequest("Invalid status ID");
            }

            // 🔹 Update the task's status correctly
            task.StatusId = request.NewStatusId;

            await appDbContext.SaveChangesAsync();
            return Results.Ok(new { task.Task_Id, task.StatusId });
        }







    }
}
