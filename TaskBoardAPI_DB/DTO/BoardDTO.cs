using TaskBoardAPI_DB.Models;

namespace TaskBoardAPI_DB.DTO
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ColumnDTO> Columns { get; set; }

        public BoardDTO(Board board)
        {
            Id = board.Id;
            Name = board.Name;
            Columns = board.Columns.Select(c => new ColumnDTO(c)).ToList();
        }
    }
}
