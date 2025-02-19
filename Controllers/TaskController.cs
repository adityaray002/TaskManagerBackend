using Microsoft.AspNetCore.Mvc;
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
    }
}
