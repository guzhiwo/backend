namespace ScramBoardAPI.Models
{
    public class Board
    {
        string SmallColumnNumber = "Column number cannot be less than 0";
        string BigColumnNumber = "Column number cannot be more than the number of columns.";
        string DefunctColumn = "No column with this ID exists";
        string ExistingColumn = "This column already exists";
        string ColumnLimit = "The number of columns cannot exceed 10";

        private const int MAX_COLOUMN = 10;
        public int UnicalID { get; set; }
        public string BoardName { get; set; }
        public List<Column> Columns { get; set; }

        public Board(int id, string name)
        {
            UnicalID = id;
            BoardName = name;
            Columns = new List<Column>();
        }
        
        public Column? GetColumn(int columnId)
        {
            return Columns.Find(x => x.UnicalID == columnId);
        }

        public void AddColumn(Column column)
        {
            if (Columns.Contains(column))
                throw new Exception(ExistingColumn);

            if (Columns.Count >= MAX_COLOUMN)
                throw new Exception(ColumnLimit);

            Columns.Add(column);
        }

        public void SetColumns(List<Column> columns)
        {
            Columns = new List<Column>(columns);
        }

        public void RemoveColumn(int columnId)
        {
            int index = Columns.FindIndex(x => x.UnicalID == columnId);
            Columns.RemoveAt(index);
        }

        public void AddTask(CTask task, int columnNum = 0)
        {
            int columnsListSize = Columns.Count;

            if (columnNum < 0)
            {
                throw new Exception(SmallColumnNumber);
            }

            if (columnNum >= columnsListSize)
            {
                throw new Exception(BigColumnNumber);
            }

            Columns[columnNum].AddTask(task);
        }
        public void MoveTask(Column columnFrom, Column columnTo, CTask task)
        {
            columnFrom.DeleteTask(task.UnicalID);
            columnTo.AddTask(task);
        }
        private int FindColumnNum(int columnUnicalID)
        {
            int columnsListSize = Columns.Count;

            for (int i = 0; i < columnsListSize; i++)
            {
                if (Columns[i].UnicalID == columnUnicalID)
                    return i;
            }
            throw new Exception(DefunctColumn);
        }
    }
}
