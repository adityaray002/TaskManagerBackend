using Microsoft.AspNetCore.Mvc;
using Task_Manager_Backend.Data;
using Task_Manager_Backend.Services;

namespace Task_Manager_Backend.Controllers
{
    public class StatusController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly StatusServices statusServices;
        public StatusController(AppDbContext appDbContext, StatusServices statusServices)
        {
            this.appDbContext = appDbContext;
            this.statusServices = statusServices;
        }
        [HttpPost("/addStatus")]
        public async Task<IActionResult> AddStatus([FromBody] Status status)
        {


            await statusServices.AddStatus(status);
            return Ok(status);
        }
        [HttpGet("/getstatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            var status = await statusServices.GetAllStatus();
            return Ok(status);


        }

        [HttpPost("/updatestatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusDTO updateStatusDTO)
        {
            if (updateStatusDTO == null)
            {
                return BadRequest("Invalid request data.");
            }

            var status = await statusServices.UpdateStatus(updateStatusDTO.TaskId, updateStatusDTO.NewStatusId);

            if (status == null)
            {
                return NotFound($"Task with ID {updateStatusDTO.TaskId} not found.");
            }

            return Ok(status);
        }

    }
}