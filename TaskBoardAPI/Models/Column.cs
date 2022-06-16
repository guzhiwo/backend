using TaskBoardAPI.DTO;

namespace TaskBoardAPI.Models
{
    public class Column
    {
        string ExistTask = "You cannot add an existing task";
        public int UnicalID { get; set; }
        public string ColumnName { get; set; }
        public List<CTask> _Tasks { get; set; }

        public Column(int id, string name)
        {
            UnicalID = id;
            ColumnName = name;
            _Tasks = new List<CTask>();
        }

        public Column(ColumnDTO column)
        {
            UnicalID = column.Id;
            ColumnName = column.Name;
            _Tasks = new List<CTask>(column.Tasks.Select(t => new CTask(t)));
        }

        public CTask? GetTask(int taskId)
        {
            return _Tasks.Find(x => x.UnicalID == taskId);
        }


        public void SetTasks(List<CTask> tasks)
        {
            _Tasks = new List<CTask>(tasks);
        }

        public void AddTask(CTask task)
        {
            if (_Tasks.Contains(task))
            {
                throw new Exception(ExistTask);
            }

            else
                _Tasks.Add(task);
        }

        public void DeleteTask(int taskId)
        {
            int index = _Tasks.FindIndex(x => x.UnicalID == taskId);

            _Tasks.RemoveAt(index);
        }
    }
}
