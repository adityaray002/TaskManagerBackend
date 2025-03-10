using Task_Manager_Backend.Data;

public class TaskDTO
{
    public int Task_Id { get; set; }
    public string Task_Title { get; set; }
    public DateTime Deadline { get; set; }
    public int StatusId { get; set; }

    public TaskStatusDTO TaskStatus { get; set; }
    public List<EmployeeTaskDTO> EmployeeTasks { get; set; }
    public List<TaskTagDTO> TaskTags { get; set; }
}

public class TaskStatusDTO
{
    public int Id { get; set; }
    public string Status_Name { get; set; }
}

public class EmployeeTaskDTO
{
    public int Id { get; set; }
    public int EmpId { get; set; }
    public EmployeeDTO Employee { get; set; }
}

public class EmployeeDTO
{
    public int Emp_Id { get; set; }
    public string Employee_Name { get; set; }
}

public class TaskTagDTO
{
    public int Id { get; set; }
    public int TagId { get; set; }
    public TagDTO Tag { get; set; }
}

public class TagDTO
{
    public int Tag_Id { get; set; }
    public string Tag_Name { get; set; }
}
