using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// پردازشگر دستور به‌روزرسانی کار.
    /// </summary>
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// سازنده کلاس که مخزن کارها را دریافت می‌کند.
        /// </summary>
        public UpdateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// هندل کردن درخواست به‌روزرسانی کار.
        /// </summary>
        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task is null) throw new KeyNotFoundException($"Task with id {request.Id} not found");

            task.Title = request.Title;
            task.Description = request.Description;
            task.Priority = request.Priority;
            task.DueDate = request.DueDate;
            task.CategoryId = request.CategoryId;
            task.UpdatedAt = DateTime.UtcNow;

            await _taskRepository.UpdateAsync(task);
        }
    }
}