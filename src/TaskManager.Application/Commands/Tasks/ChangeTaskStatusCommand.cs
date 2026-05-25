using MediatR;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// دستور تغییر وضعیت یک کار.
    /// </summary>
    public record ChangeTaskStatusCommand(
        Guid Id,
        TaskStatus Status
    ) : IRequest;
}