using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Backend.Data
{
    public class TaskStatusMapping
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int StatusId { get; set; }

        [ForeignKey("TaskId")]
        public Tasks Task { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}
