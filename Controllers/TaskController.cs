using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Task_Manager_Backend.Data;
using Task_Manager_Backend.Services;

namespace Task_Manager_Backend.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly TaskServices _taskServices;

        public TaskController(AppDbContext appDbContext, TaskServices taskServices)
        {
            _appDbContext = appDbContext;
            _taskServices = taskServices;
        }

        [HttpPost("/addTask")]
        public async Task<IActionResult> AddTask([FromBody] Tasks task)
        {
             await _taskServices.AddTask(task);
            return Ok(task);
        }

        [HttpGet("/getTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskServices.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("/getTasksById/{id}")]
        public async Task<IActionResult> getTasksById(int id)
        {
            var tasks = await _taskServices.getTasksById(id);
            return Ok(tasks);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTask([FromBody] Tasks updatedTask)
        {
            if (updatedTask == null)
            {
                return BadRequest("Task data is required.");
            }

            var existingTask = await _appDbContext.Taskss
                .Include(t => t.EmployeeTasks)
                .Include(t => t.TaskTags)
                .Include(t => t.TaskStatus)  // Ensure TaskStatus is included
                .FirstOrDefaultAsync(t => t.Task_Id == updatedTask.Task_Id);

            if (existingTask == null)
            {
                return NotFound("Task not found.");
            }

            // 🔹 Update Task properties
            existingTask.Task_Title = updatedTask.Task_Title;
            existingTask.Deadline = updatedTask.Deadline;

            // 🔹 Update relations
            existingTask.EmployeeTasks = updatedTask.EmployeeTasks
                .Select(e => new EmployeeTaskMapping { EmpId = e.EmpId }).ToList();

            existingTask.TaskTags = updatedTask.TaskTags
                .Select(t => new TaskTagMapping { TagId = t.TagId }).ToList();

            // 🔹 Update Task Status
            existingTask.StatusId = updatedTask.StatusId;  // Ensure correct StatusId is assigned

            try
            {
                await _appDbContext.SaveChangesAsync();
                return Ok("Task updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


    }
}
