using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Queries.Tasks
{
    /// <summary>
    /// هندلر کوئری دریافت کار بر اساس شناسه.
    /// </summary>
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto?>
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// سازنده کلاس که مخزن کارها را دریافت می‌کند.
        /// </summary>
        public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// مدیریت درخواست دریافت کار توسط شناسه و تبدیل آن به DTO.
        /// </summary>
        public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task is null) return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                CategoryId = task.CategoryId,
                CategoryName = task.Category?.Name
            };
        }
    }
}