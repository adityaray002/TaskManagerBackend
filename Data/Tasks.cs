using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_Manager_Backend.Data
{
    public class Tasks
    {
        [Key]
        public int Task_Id { get; set; }
        public string Task_Title { get; set; }
        public DateTime Deadline { get; set; }
        
        public ICollection<EmployeeTaskMapping> EmployeeTasks { get; set; }
     
        public ICollection<TaskTagMapping> TaskTags { get; set; }
        
        public ICollection<TaskStatusMapping> TaskStatuses { get; set; }

    }
}
