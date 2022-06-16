using ScramBoardAPI.Models;

namespace ScramBoardAPI.DTO
{
    public class ColumnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskDTO> Tasks { get; set; }
         
        public ColumnDTO(Column column)
        {
            Id = column.UnicalID;
            Name = column.ColumnName;
            Tasks = column._Tasks.Select(t => new TaskDTO(t)).ToList();
        }
    }
}
