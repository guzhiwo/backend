using System.ComponentModel.DataAnnotations;
using TaskBoardAPI_DB.DTO;

namespace TaskBoardAPI_DB.Models
{
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }

    public class CTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int ColumnId { get; set; }
        public string TaskName { get; internal set; }
        public string TaskDescription { get; internal set; }
        public Priority TaskPriority { get; internal set; }

        public CTask(int id, string name, string description, Priority priority)
        {
            Id = id;
            Name = name;
            Description = description;
            Priority = priority;
        }

        public CTask(TaskDTO taskDto)
        {
            Id = taskDto.Id;
            Name = taskDto.Name;
            Description = taskDto.Description;
            Priority = taskDto.Priority;
        }
    }
}
