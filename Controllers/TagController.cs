using Microsoft.AspNetCore.Mvc;
using Task_Manager_Backend.Data;
using Task_Manager_Backend.Services;

namespace Task_Manager_Backend.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly TagServices tagServices;

        public TagController(AppDbContext appDbContext, TagServices tagServices)
        {
            this.appDbContext = appDbContext;
            this.tagServices = tagServices;
        }

        [HttpPost("/addTag")]
        public async Task<IActionResult> AddTag([FromBody] Tag tag)
        {
            await tagServices.AddTag(tag);
            return Ok(tag);
        }

        [HttpGet("/getTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await tagServices.GetAllTags();
            return Ok(tags);
        }
    }
}
