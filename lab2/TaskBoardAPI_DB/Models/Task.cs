using ScramBoardAPI.DTO;

namespace ScramBoardAPI.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High,
    }

    public class CTask
    {
        public int UnicalID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Priority TaskPriority { get; set; }

        public CTask(int id, string name, string description, Priority priority)
        {
            UnicalID = id;
            TaskName = name;
            TaskDescription = description;
            TaskPriority = priority;
        }

        public CTask(TaskDTO taskDto)
        {
            UnicalID = taskDto.Id;
            TaskName = taskDto.Name;
            TaskDescription = taskDto.Description;
            TaskPriority = taskDto.Priority;
        }
    }
}
