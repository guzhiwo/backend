using TaskBoardAPI.DTO;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Repositories
{
    public class ColumnRepository
    {
        private readonly BoardRepository _boardRepository;

        public ColumnRepository(BoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public BoardRepository GetBoardRepository()
        {
            return _boardRepository;
        }

        public List<Column> GetColumns(int boardId)
        {
            Board? board = _boardRepository.GetBoard(boardId);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            return board.Columns;
        }

        public Column? GetColumn(int boardId, int? columnId)
        {
            if (columnId is null) return null;
            List<Column> columns = GetColumns(boardId);

            return columns.Find(x => x.UnicalID == columnId);
        }

        public void AddColumn(int boardId, Column column)
        {
            Board? board = _boardRepository.GetBoard(boardId);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            if (board.Columns.FindIndex(x => x.UnicalID == column.UnicalID) == -1 && column.ColumnName != null)
            {
                board.AddColumn(column);
            }

            _boardRepository.SaveBoard(board);
        }

        public void UpdateColumn(int boardId, Column column)
        {
            Board? board = _boardRepository.GetBoard(boardId);
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            List<Column> columns = board.Columns;

            int columnIndex = columns.FindIndex(x => x.UnicalID == column.UnicalID);
            if (columnIndex == -1)
            {
                throw new ArgumentException("Column not found");
            }

            columns[columnIndex] = column;

            board.SetColumns(columns);

            _boardRepository.SaveBoard(board);
        }

        public void RemoveColumn(int boardId, int columnId)
        {
            Board? board = _boardRepository.GetBoard(boardId);
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            board.RemoveColumn(columnId);

            _boardRepository.SaveBoard(board);
        }
    }
}
