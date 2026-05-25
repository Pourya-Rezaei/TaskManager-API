using MediatR;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// دستور به‌روزرسانی اطلاعات یک کار موجود.
    /// </summary>
    public record UpdateTaskCommand(
        Guid Id,
        string Title,
        string? Description,
        TaskPriority Priority,
        DateTime? DueDate,
        Guid? CategoryId
    ) : IRequest;
}