using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Methods;
using TaskBoardAPI.DTO;

namespace TaskBoardAPI.Controllers
{
    [ApiController]
    [Route("Task")]
    public class TaskController : Controller
    {

        private readonly IUsingMethods _methods;

        // POST: 
        [HttpPost("{boardUnicalID}/newTask")] 
        public IActionResult CreateNewTask(string boardUnicalID, [FromBody] CreateTaskDTO arg)
        {
            try
            {
                _methods.AddTask(boardUnicalID, arg);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }


        // PUT:
        [HttpPut("{boardUnicalID}/move/{taskUnicalID}")] 
        public IActionResult MoveTaskIntoColumn(string boardUnicalID, string taskUnicalID, [FromBody] MoveTaskBetweenColumnsDTO arg)
        {
            try
            {
                _methods.MoveTask(boardUnicalID, taskUnicalID, arg);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE:
        [HttpDelete("{boardUnicalID}/delete/{taskUnicalID}")] 
        public IActionResult DeleteTask(string boardUnicalID, string taskUnicalID)
        {
            try
            {
                _methods.DeleteTask(boardUnicalID, taskUnicalID);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
