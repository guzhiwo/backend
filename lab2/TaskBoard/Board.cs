using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard
{
    public class Board
    {
        string SmallColumnNumber = "Column number cannot be less than 0";
        string BigColumnNumber = "Column number cannot be more than the number of columns.";
        string DefunctTask = "No task with this ID exists";
        string DefunctColumn = "No column with this ID exists";
        string ExistingColumn = "This column already exists";
        string ColumnLimit = "The number of columns cannot exceed 10";
        private const int MAX_COLOUMN = 10;

        private readonly List<Column> Columns;
        public string BoardName { get; }
        public string UnicalID { get; }
        public Board(string name)
        {
            UnicalID = Guid.NewGuid().ToString();
            BoardName = name;
            Columns = new List<Column>();
        }
        public void AddColumn(Column column)
        {
            if (Columns.Contains(column))
                throw new Exception(ExistingColumn);

            if (Columns.Count >= MAX_COLOUMN)
                throw new Exception(ColumnLimit);

            Columns.Add(column);
        }

        public Column GetColumn(string columnUnicalID)
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].UnicalID == columnUnicalID)
                    return Columns[i];
            }
            throw new Exception(DefunctColumn);
        }

        public List<Column> LookAllColumn()
        {
            return Columns;
        }
        public void AddTaskIntoColumn(Task task, int columnNum = 0)
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

        public void DeleteTask(string unicalID)
        {
            int columnsListSize = Columns.Count;

            for (int i = 0; i < columnsListSize; i++)
            {
                if (Columns[i].DeleteTask(unicalID))
                    return;
            }
            throw new Exception(DefunctTask);
        }

        public Task GetTask(string taskUnicalID)
        {
            int columnsListSize = Columns.Count;

            for (int i = 0; i < columnsListSize; i++)
            {
                Task? desiredTask = Columns[i].GetTask(taskUnicalID);

                if (desiredTask != null)
                    return desiredTask;
            }
            throw new Exception(DefunctTask);
        }
        public void MoveTaskBetweenColumns(string columnUnicalID, string taskUnicalID)
        {
            Task movingTask = GetTask(taskUnicalID);
            DeleteTask(movingTask.UnicalID);

            AddTaskIntoColumn(movingTask, FindColumnNum(columnUnicalID));
        }

        private int FindColumnNum(string columnUnicalID)
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
