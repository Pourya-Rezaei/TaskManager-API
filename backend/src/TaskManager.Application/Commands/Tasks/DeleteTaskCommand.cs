using MediatR;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// دستور حذف یک کار بر اساس شناسه.
    /// </summary>
    public record DeleteTaskCommand(Guid Id) : IRequest;
}