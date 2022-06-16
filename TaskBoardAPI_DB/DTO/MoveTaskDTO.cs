using TaskBoardAPI_DB.Models;

namespace TaskBoardAPI_DB.DTO
{
    public class MoveTaskDTO
    {
        public int Id { get; set; }
        public int ColumnFromId { get; set; }
        public int ColumnToId { get; set; }

    }
}
