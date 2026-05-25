using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Queries.Tasks
{
    /// <summary>
    /// هندلر کوئری دریافت کارها بر اساس دسته‌بندی.
    /// </summary>
    public class GetTasksByCategoryQueryHandler : IRequestHandler<GetTasksByCategoryQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// سازنده کلاس که مخزن کارها را دریافت می‌کند.
        /// </summary>
        public GetTasksByCategoryQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// مدیریت درخواست دریافت کارهای یک دسته‌بندی و تبدیل آن‌ها به DTO.
        /// </summary>
        public async Task<IEnumerable<TaskDto>> Handle(GetTasksByCategoryQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks
                .Where(t => t.CategoryId == request.CategoryId)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    CategoryId = t.CategoryId,
                    CategoryName = t.Category?.Name
                });
        }
    }
}