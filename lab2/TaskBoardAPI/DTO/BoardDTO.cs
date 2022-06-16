using TaskBoard;
namespace TaskBoardAPI.DTO;
public class BoardDTO
{
    public BoardDTO(Board board)
    {
        UnicalID = board.UnicalID;
        BoardName = board.BoardName;

        List<ColumnsDTO> listColumnDTO = new List<ColumnsDTO>();
        List<Column> listColumn = board.LookAllColumn();

        foreach (Column column in listColumn)
        {
            listColumnDTO.Add(new ColumnsDTO(column));
        }
        Columns = listColumnDTO;
    }

    public string UnicalID { get; set; }
    public string BoardName { get; set; }
    public IEnumerable<ColumnsDTO> Columns { get; set; }
}
