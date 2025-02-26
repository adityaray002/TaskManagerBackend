using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Backend.Data
{
    public class Status
    {
        [Key]
        public int Status_Id { get; set; }
        public string Status_Name { get; set; }
      /*  public ICollection<TaskStatusMapping> TaskStatuses { get; set; }*/
    }
}
