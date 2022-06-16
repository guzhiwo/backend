using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.DTO;
using TaskBoardAPI.Models;
using TaskBoardAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskBoardAPI.Controllers
{
    [Route("Board")]
    [ApiController]
    public class BoardController : Controller
    {
        private readonly BoardRepository _boardRepository;

        public BoardController(BoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        [HttpGet]
        public IActionResult GetBoards()
        {
            IEnumerable<BoardDTO> boards = _boardRepository.GetBoards().Select(board => new BoardDTO(board));

            return Ok(boards);
        }

        [HttpGet("{boardId}")]
        public IActionResult GetBoardByUUID(int boardId)
        {
            Board? board = _boardRepository.GetBoard(boardId);

            if (board == null)
            {
                return NotFound();
            }

            return Ok(new BoardDTO(board));
        }

        [HttpPost]
        public IActionResult CreateBoard(int id, string name)
        {

            _boardRepository.AddBoard(new Board(id, name));

            return Ok();
        }

        [HttpDelete("{boardId}")]
        public IActionResult DeleteBoard(int boardId)
        {
            try
            {
                _boardRepository.RemoveBoard(boardId);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }

            return Ok();
        }
    }
}
