using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Queries.Tasks
{
    /// <summary>
    /// کوئری برای دریافت کارهای متعلق به یک دسته‌بندی خاص.
    /// </summary>
    public record GetTasksByCategoryQuery(Guid CategoryId) : IRequest<IEnumerable<TaskDto>>;
}