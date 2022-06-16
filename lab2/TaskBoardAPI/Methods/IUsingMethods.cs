using TaskBoardAPI.DTO;

namespace TaskBoardAPI.Methods
{
    public interface IUsingMethods
    {
        public void AddBoard(CreateBoardDTO arg);
        public void AddColumn(string boardUnicalID, CreateColumnDTO arg);
        public void AddTask(string columnUnicalID, CreateTaskDTO arg);

        public BoardDTO GetBoard(string boardUnicalID);

        public void DeleteBoard(string boardUnicalID);
        public void DeleteTask(string columnUnicalID, string taskUnicalID);

        public IEnumerable<BoardDTO> GetAllBoard();
        public void MoveTask(string boardUnicalID, string taskUnicalID, MoveTaskBetweenColumnsDTO arg);
    }
}