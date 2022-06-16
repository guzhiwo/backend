using ScramBoardAPI.Models;

namespace ScramBoardAPI.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public TaskDTO(CTask task)
        {
            Id = task.UnicalID;
            Name = task.TaskName;
            Description = task.TaskDescription;
            Priority = task.TaskPriority;
        }
    }
}
 