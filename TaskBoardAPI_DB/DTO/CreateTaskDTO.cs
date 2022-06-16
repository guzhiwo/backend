using TaskBoardAPI_DB.Models;

namespace TaskBoardAPI_DB.DTO
{
    public class CreateTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
    }
}
