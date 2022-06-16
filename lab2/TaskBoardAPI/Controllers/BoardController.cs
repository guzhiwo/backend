using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.DTO;
using TaskBoardAPI.Methods;

namespace TaskBoardAPI.Controllers
{
    [ApiController]
    [Route("Board")]
    public class BoardController : Controller
    {
        private readonly IUsingMethods _methods;


        // POST:
        [HttpPost("newBoard")]
        public IActionResult CreateNewBoard([FromBody] CreateBoardDTO arg)
        {
            try
            {
                _methods.AddBoard(arg);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // GET:
        [HttpGet("{boardUnicalID}")] 
        public IActionResult GetBoardByUnicalID(string boardUnicalID)
        {
            BoardDTO board;
            try
            {
                board = _methods.GetBoard(boardUnicalID);
            }
            catch
            {
                return NotFound();
            }

            return Ok(board);
        }

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

        // DELETE:
        [HttpDelete("{boardUnicalID}/deleteBoard")] //тип запроса: DELETE. адрес запроса: "scrumBoard/{boardUnicalID}/deleteBoard"
        public IActionResult DeleteBoard(string boardUnicalID)
        {
            try
            {
                _methods.DeleteBoard(boardUnicalID);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
