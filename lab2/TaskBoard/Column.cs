using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard
{
    public class Column
    {
        string ExistTask = "You cannot add an existing task";
        public string UnicalID { get; }
        public string ColumnName { get; set; }

        private readonly List<Task> _Tasks;

        public Column(string name)
        {
            ColumnName = name;
            UnicalID = Guid.NewGuid().ToString();

            _Tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            if (_Tasks.Contains(task))
            {
                throw new Exception(ExistTask);
            }

            else
                _Tasks.Add(task);
        }

        public bool DeleteTask(string taskUnicalID)
        {
            int tasksListSize = _Tasks.Count;

            for (int i = 0; i < tasksListSize; i++)
            {
                if (taskUnicalID == _Tasks[i].UnicalID)
                {
                    _Tasks.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Task? GetTask(string taskUnicalID)
        {
            int tasksListSize = _Tasks.Count;

            for (int i = 0; i < tasksListSize; i++)
            {
                if (taskUnicalID == _Tasks[i].UnicalID)
                {
                    return _Tasks[i];
                }
            }
            return null;
        }

        public List<Task> LookAllTasks()
        {
            return _Tasks;
        }
    }
}
