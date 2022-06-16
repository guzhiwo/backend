using TaskBoardAPI_DB.Models;

namespace TaskBoardAPI_DB.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public TaskDTO(CTask task)
        {
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            Priority = task.Priority;
        }
    }
}
