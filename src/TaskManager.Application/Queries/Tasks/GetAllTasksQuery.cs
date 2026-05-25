using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Queries.Tasks
{
    /// <summary>
    /// کوئری برای دریافت لیست تمام کارها.
    /// </summary>
    public record GetAllTasksQuery() : IRequest<IEnumerable<TaskDto>>;
}