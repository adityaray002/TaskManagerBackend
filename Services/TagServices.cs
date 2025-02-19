using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Manager_Backend.Data;

namespace Task_Manager_Backend.Services
{
    public class TagServices
    {
        public readonly AppDbContext appDbContext;

        public TagServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IResult> AddTag([FromBody] Tag tag)
        {
            appDbContext.Tags.Add(tag);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(tag);
        }

        [HttpGet("/getTags")]
        public async Task<IResult> GetAllTags()
        {
            List<Tag> tags = await appDbContext.Tags.ToListAsync();
            return Results.Ok(tags);
        }

    }
}
