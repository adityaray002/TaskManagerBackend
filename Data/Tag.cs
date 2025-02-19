using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Backend.Data
{
    public class Tag
    {
        [Key]
        public int Tag_Id { get; set; }
        public string Tag_Name { get; set; }

       // public ICollection<TaskTagMapping> TaskTags { get; set; }
    }
}
