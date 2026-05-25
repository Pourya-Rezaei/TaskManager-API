using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// دستور ایجاد یک کار جدید.
    /// </summary>
    public record CreateTaskCommand(
        string Title,
        string? Description,
        TaskPriority Priority,
        DateTime? DueDate,
        Guid? CategoryId
    ) : IRequest<Guid>;
}