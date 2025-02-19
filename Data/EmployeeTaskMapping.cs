using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Backend.Data
{
    public class EmployeeTaskMapping
    {
        [Key]
        public int Id { get; set; }  
        public int TaskId { get; set; }
        public int EmpId { get; set; }

        [ForeignKey("TaskId")]
        public Tasks Task { get; set; }

        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }
    }
}
