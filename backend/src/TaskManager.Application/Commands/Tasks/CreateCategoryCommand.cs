using MediatR;

namespace TaskManager.Application.Commands.Categories
{
    /// <summary>
    /// دستور ایجاد یک دسته‌بندی جدید.
    /// </summary>
    public record CreateCategoryCommand(
        string Name,
        string? Description
    ) : IRequest<Guid>;
}