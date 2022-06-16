using TaskBoardAPI.Models;

namespace TaskBoardAPI.DTO
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ColumnDTO> Columns { get; set; }

        public BoardDTO(Board board)
        {
            Id = board.UnicalID;
            Name = board.BoardName;
            Columns = board.Columns.Select(c => new ColumnDTO(c)).ToList();
        }
    }
}
