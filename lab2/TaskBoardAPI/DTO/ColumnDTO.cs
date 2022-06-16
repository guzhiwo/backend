using TaskBoard;
using Task = TaskBoard.Task;

namespace TaskBoardAPI.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(Column column)
    {
        UnicalID = column.UnicalID;
        ColumnName = column.ColumnName;

        List<TasksDTO> listTasksDTO = new List<TasksDTO>();
        List<Task> listTasks = column.LookAllTasks();

        foreach (Task task in listTasks)
        {
            listTasksDTO.Add(new TasksDTO(task));
        }

        Tasks = listTasksDTO;
    }

    public string UnicalID { get; set; }
    public string ColumnName { get; set; }
    public IEnumerable<TasksDTO> Tasks { get; set; }
}
