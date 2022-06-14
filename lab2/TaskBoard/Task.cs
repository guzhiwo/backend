using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Priority
{
    Low,
    Middle,
    High,
}

namespace TaskBoard
{
    public class Task
    {
        public Task(string name, string description, Priority taskPriority)
        {
            TaskName = name;
            TaskDescription = description;
            TaskPriority = taskPriority;
            UnicalID = Guid.NewGuid().ToString();
        }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string UnicalID { get; set; }
        public Priority TaskPriority { get; set; }

    }
}


