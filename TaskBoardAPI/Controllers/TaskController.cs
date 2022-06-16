using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.DTO;
using TaskBoardAPI.Models;
using TaskBoardAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskBoardAPI.Controllers
{
    [Route("Task")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly TaskRepository _taskRepository;

        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("{boardId}/columns/{columnId}/tasks")]
        public IActionResult GetTasks(int boardId, int columnId)
        {
            try
            {
                IEnumerable<TaskDTO> tasks = _taskRepository.GetTasks(boardId, columnId).Select(task => new TaskDTO(task));

                return Ok(tasks);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{boardId}/columns/{columnId}/tasks/{taskId}")]
        public IActionResult GetTask(int boardId, int columnId, int taskId)
        {
            try
            {
                CTask? task = _taskRepository.GetTask(boardId, columnId, taskId);

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(new TaskDTO(task));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("{boardId}/tasks")]
        public IActionResult AddTask(int boardId, int? columnId, int taskId, string taskName, string taskDescription, Priority taskPriority)
        {
            try
            {
                CTask newTask = new CTask(taskId, taskName, taskDescription, taskPriority);

                _taskRepository.AddTask(boardId, columnId, newTask);
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{boardId}/columns/{columnId}/tasks")]
        public IActionResult UpdateTask(int boardId, int columnId, int taskId, string taskName, string taskDescription, Priority taskPriority)
        {
            try
            {
                CTask? task1 = _taskRepository.GetTask(boardId, columnId, taskId);

                if (task1 == null)
                {
                    return NotFound();
                }

                task1.TaskName = taskName;
                task1.TaskDescription = taskDescription;
                task1.TaskPriority = taskPriority;

                _taskRepository.UpdateTask(boardId, columnId, task1);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{boardId}/columns/{columnId}/tasks/{taskId}")]
        public IActionResult DeleteTask(int boardId, int columnId, int taskId)
        {
            try
            {
                _taskRepository.DeleteTask(boardId, columnId, taskId);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{boardId}/tasks")]
        public IActionResult MoveTask(int boardId, int columnFromId, int columnToId, int taskId)
        {
            try
            {
                _taskRepository.MoveTask(boardId, columnFromId, columnToId, taskId);
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }
    }
}