namespace Task_Manager_Backend.Data
{
    public class TaskModelList
    {
        public int Task_Id { get; set; }
        public string Task_Title { get; set; }
        public DateTime Deadline { get; set; }
        public List<EmployeeTaskModel> EmployeeTasks { get; set; } = new();
        public List<TaskTagModel> TaskTags { get; set; } = new();
        public TaskStatusModel TaskStatus { get; set; }  // Changed to single TaskStatus
    }

    public class EmployeeTaskModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmpId { get; set; }
        public EmployeeModel Employee { get; set; } = new();  // Ensuring non-nullable reference
    }

    public class EmployeeModel
    {
        public int Emp_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Profile { get; set; }
    }

    public class TaskTagModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int TagId { get; set; }
        public TagModel Tag { get; set; } = new();
    }

    public class TagModel
    {
        public int Tag_Id { get; set; }
        public string Tag_Name { get; set; }
    }

    public class TaskStatusModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        public StatusModel Status { get; set; } = new();
    }

    public class StatusModel
    {
        public int Status_Id { get; set; }
        public string Status_Name { get; set; }
    }
}
