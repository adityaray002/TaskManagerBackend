using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Backend.Data
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Profile { get; set; }

       // public ICollection<EmployeeTaskMapping> EmployeeTasks { get; set; }
    }
}
