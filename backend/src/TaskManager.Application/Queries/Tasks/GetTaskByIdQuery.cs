using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Queries.Tasks
{
    /// <summary>
    /// کوئری برای دریافت یک کار بر اساس شناسه.
    /// </summary>
    public record GetTaskByIdQuery(Guid Id) : IRequest<TaskDto?>;
}