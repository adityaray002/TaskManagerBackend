using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_Manager_Backend.Data
{
    public class TaskTagMapping
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int TagId { get; set; }

        // [ForeignKey("TaskId")]
        // [JsonIgnore]
        // public Tasks Task { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
