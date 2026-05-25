using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// پردازشگر دستور ایجاد کار جدید.
    /// </summary>
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// سازنده کلاس که مخزن کارها را دریافت می‌کند.
        /// </summary>
        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// هندل کردن درخواست ایجاد کار.
        /// </summary>
        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                DueDate = request.DueDate,
                CategoryId = request.CategoryId
            };

            await _taskRepository.AddAsync(task);
            return task.Id;
        }
    }
}