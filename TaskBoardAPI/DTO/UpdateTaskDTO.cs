using TaskBoardAPI.Models;

namespace TaskBoardAPI.DTO
{
    public class UpdateCTaskDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
    }
}
