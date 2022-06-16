using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI_DB.DTO;
using TaskBoardAPI_DB.Models;
using TaskBoardAPI_DB.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskBoardAPI_DB.Controllers
{
    [Route("Column")]
    [ApiController]
    public class ColumnController : Controller
    {
        private readonly ColumnRepository _columnRepository;

        public ColumnController(ColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }


        [HttpGet("{boardId}/columns")]
        public IActionResult GetColumns(int boardId)
        {
            IEnumerable<ColumnDTO> columns;

            try
            {
                columns = _columnRepository.GetColumns(boardId).Select(column => new ColumnDTO(column));
            }
            catch
            {
                return NotFound();
            }

            return Ok(columns);
        }

        [HttpGet("{boardId}/columns/{columnId}")]
        public IActionResult GetColumn(int boardId, int columnId)
        {
            try
            {
                Column? column = _columnRepository.GetColumn(boardId, columnId);
                if (column == null)
                {
                    return NotFound();
                }

                return Ok(new ColumnDTO(column));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("{boardId}/columns")]
        public IActionResult AddColumn(int boardId, int columnId, string columnName)
        {
            try
            {
                Column newColumn = new Column(columnId, columnName);
                _columnRepository.AddColumn(boardId, newColumn);
            }
            catch
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{boardId}/columns")]
        public IActionResult UpdateColumn(int boardId, int columnId, string columnName)
        {
            try
            {
                Column? boardColumn = _columnRepository.GetColumn(boardId, columnId);

                if (boardColumn == null)
                {
                    return NotFound();
                }

                boardColumn.ColumnName = columnName;
                _columnRepository.UpdateColumn(boardId, boardColumn);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{boardId}/columns/{columnId}")]
        public IActionResult DeleteColumn(int boardId, int columnId)
        {
            try
            {
                _columnRepository.RemoveColumn(boardId, columnId);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
