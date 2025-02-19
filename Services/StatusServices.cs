using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<IResult> UpdateStatus(int taskId,int newStatusId)
        {
            var taskStatus = await appDbContext.TaskStatusMappings
       .Where(ts => ts.TaskId == taskId)
       .FirstOrDefaultAsync();

            if (taskStatus == null)
            {
                return Results.NotFound($"Task with ID {taskId} not found.");
            }

            taskStatus.StatusId = newStatusId;
            await appDbContext.SaveChangesAsync();

            return Results.Ok(taskStatus);

        }
    }
}
