using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.DTO;
using TaskBoardAPI.Methods;

namespace TaskBoardAPI.Controllers
{
    [ApiController]
    [Route("Column")]
    public class ColumnController : Controller
    {
        private readonly IUsingMethods _methods;

        // POST:
        [HttpPost("{boardUnicalID}/newColumn")] 
        public IActionResult CreateNewColumn(string boardUnicalID, [FromBody] CreateColumnDTO arg)
        {
            try
            {
                _methods.AddColumn(boardUnicalID, arg);
            }
            catch
            {
                return NotFound();
            }
            return Ok();
        }

        // GET:
        [HttpGet("allBoards")] 
        public IActionResult ShowAllBoards()
        {
            IEnumerable<BoardDTO> listBoards;

            try
            {
                listBoards = _methods.GetAllBoard();
            }
            catch
            {
                listBoards = Enumerable.Empty<BoardDTO>();
            }

            return Ok(listBoards);
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
    }
}
