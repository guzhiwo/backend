using TaskBoardAPI_DB.Models;

namespace TaskBoardAPI_DB.DTO
{
    public class ColumnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public ColumnDTO(Column column)
        {
            Id = column.Id;
            Name = column.Name;
            Tasks = column.Tasks.Select(t => new TaskDTO(t)).ToList();
        }
    }
}
