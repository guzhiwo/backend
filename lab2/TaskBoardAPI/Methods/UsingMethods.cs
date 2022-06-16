using Microsoft.Extensions.Caching.Memory;
using TaskBoard;
using TaskBoardAPI.DTO;
using Task = TaskBoard.Task;

namespace TaskBoardAPI.Methods
{
    public class UsingMethods : IUsingMethods
    {
        private readonly IMemoryCache _memoryCache;
        public UsingMethods(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private static Priority GetTaskPriority(int priority)
        {
            switch (priority)
            {
                case 0:
                    priority = (int)Priority.High;
                    break;
                case 1:
                    priority = (int)Priority.Middle;
                    break;
                case 2:
                    priority = (int)Priority.Low;
                    break;
                default:
                    throw new System.Exception("Неизвестная сложность задачи.");
            }
            return (Priority)priority;
        }

        private List<Board> GetListBoards()
        {
            _memoryCache.TryGetValue("boards", out List<Board> listBoards);

            if (listBoards == null)
                throw new System.Exception("Невозможно выполнить действие! Список досок пуст.");

            return listBoards;
        }

        private int GetIndexBoard(string boardUnicalID)
        {
            List<Board> listBoards = GetListBoards();
            int listBoardsLength = listBoards.Count;

            for (int i = 0; i < listBoardsLength; i++)
            {
                if (listBoards[i].UnicalID == boardUnicalID)
                    return i;
            }
            throw new System.Exception("Доска не найдена.");
        }
        public void AddBoard(CreateBoardDTO arg)
        {
            List<Board> listBoards;
            try
            {
                listBoards = GetListBoards();
            }
            catch (System.Exception)
            {
                listBoards = new List<Board>();
            }

            listBoards.Add(new Board(arg.BoardName));
            _memoryCache.Set("boards", listBoards);
        }

        public void AddColumn(string boardUnicalID, CreateColumnDTO arg)
        {
            List<Board> listBoards = GetListBoards();
            listBoards[GetIndexBoard(boardUnicalID)].AddColumn(new Column(arg.ColumnName));
            _memoryCache.Set("boards", listBoards);
        }

        public void AddTask(string boardUnicalID, CreateTaskDTO arg)
        {
            List<Board> listBoards = GetListBoards();
            listBoards[GetIndexBoard(boardUnicalID)].AddTaskIntoColumn(new Task(arg.TaskName, arg.TaskDescription, GetTaskPriority(arg.TaskPriority)));
            _memoryCache.Set("boards", listBoards);
        }
        public BoardDTO GetBoard(string boardUnicalID)
        {
            BoardDTO board = new(GetListBoards()[GetIndexBoard(boardUnicalID)]);
            return board;
        }

        public void DeleteBoard(string boardUnicalID)
        {
            List<Board> listBoards = GetListBoards();
            int listBoardsLength = listBoards.Count;

            for (int i = 0; i < listBoardsLength; i++)
            {
                if (listBoards[i].UnicalID == boardUnicalID)
                {
                    listBoards.RemoveAt(i);
                    _memoryCache.Set("boards", listBoards);
                    return;
                }
            }

            throw new System.Exception("Доска не найдена.");
        }

        public void DeleteTask(string columnUnicalID, string taskUnicalID)
        {
            List<Board> listBoards = GetListBoards();
            listBoards[GetIndexBoard(columnUnicalID)].DeleteTask(taskUnicalID);
            _memoryCache.Set("boards", listBoards);
        }
        public IEnumerable<BoardDTO> GetAllBoard()
        {
            IEnumerable<BoardDTO> allBoards = GetListBoards().Select(board => new BoardDTO(board));
            return allBoards;
        }
        public void MoveTask(string boardUnicalID, string taskUnicalID, MoveTaskBetweenColumnsDTO arg)
        {
            List<Board> boards = GetListBoards();

            boards[GetIndexBoard(boardUnicalID)].MoveTaskBetweenColumns(arg.columnUnicalID, taskUnicalID);

            _memoryCache.Set("boards", boards);
        }

        void IUsingMethods.AddBoard(CreateBoardDTO arg)
        {
            throw new NotImplementedException();
        }

        void IUsingMethods.AddColumn(string boardUnicalID, CreateColumnDTO arg)
        {
            throw new NotImplementedException();
        }

        void IUsingMethods.AddTask(string columnUnicalID, CreateTaskDTO arg)
        {
            throw new NotImplementedException();
        }

        BoardDTO IUsingMethods.GetBoard(string boardUnicalID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BoardDTO> IUsingMethods.GetAllBoard()
        {
            throw new NotImplementedException();
        }

        void IUsingMethods.MoveTask(string boardUnicalID, string taskUnicalID, MoveTaskBetweenColumnsDTO arg)
        {
            throw new NotImplementedException();
        }
    }
}
