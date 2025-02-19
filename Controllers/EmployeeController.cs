using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Task_Manager_Backend.Data;
using Task_Manager_Backend.Services;

namespace Task_Manager_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly EmployeeServices employeeServices;
        public EmployeeController(AppDbContext appDbContext, EmployeeServices employeeServices)
        {
            this.appDbContext = appDbContext;
            this.employeeServices = employeeServices;
        }
        [HttpPost("/addEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            

            await employeeServices.AddEmployee(employee);
            return Ok(employee);
        }
        [HttpGet("/getemployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
          var employees =   await employeeServices.GetAllEmployees();
            return Ok(employees);

        }

        
    }
}
