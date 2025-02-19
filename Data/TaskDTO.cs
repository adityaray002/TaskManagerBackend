namespace Task_Manager_Backend.Data
{
    public class TaskDTO
    {
        public int Task_Id { get; set; }
        public string Task_Title { get; set; }
        public DateTime Deadline { get; set; }

        public List<EmployeeDTO> Employees { get; set; } = new();
        public List<TagDTO> Tags { get; set; } = new();
        public List<StatusDTO> Statuses { get; set; } = new();
    }
}
