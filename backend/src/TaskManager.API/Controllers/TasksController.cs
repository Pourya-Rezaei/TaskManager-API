using Microsoft.AspNetCore.Mvc;
using MediatR;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Application.DTOs;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// دریافت لیست تمام کارها
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaskDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());
            return Ok(result);
        }

        /// <summary>
        /// دریافت یک کار بر اساس شناسه
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));
            if (result is null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// دریافت کارهای یک دسته‌بندی
        /// </summary>
        [HttpGet("category/{categoryId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<TaskDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var result = await _mediator.Send(new GetTasksByCategoryQuery(categoryId));
            return Ok(result);
        }

        /// <summary>
        /// ساخت کار جدید
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto dto)
        {
            var command = new CreateTaskCommand(
                dto.Title,
                dto.Description,
                dto.Priority,
                dto.DueDate,
                dto.CategoryId
            );
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        /// <summary>
        /// ویرایش یک کار
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskDto dto)
        {
            var command = new UpdateTaskCommand(
                id,
                dto.Title,
                dto.Description,
                dto.Priority,
                dto.DueDate,
                dto.CategoryId
            );
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// حذف یک کار
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return NoContent();
        }

        /// <summary>
        /// تغییر وضعیت یک کار
        /// </summary>
        [HttpPatch("{id:guid}/status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] TaskStatus status)
        {
            await _mediator.Send(new ChangeTaskStatusCommand(id, status));
            return NoContent();
        }
    }
}