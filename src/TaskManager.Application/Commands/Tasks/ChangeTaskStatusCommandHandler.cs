using MediatR;
using TaskManager.Domain.Interfaces;


namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// پردازشگر دستور تغییر وضعیت کار.
    /// </summary>
    public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand>
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// سازنده کلاس که مخزن کارها را دریافت می‌کند.
        /// </summary>
        public ChangeTaskStatusCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// هندل کردن درخواست تغییر وضعیت کار.
        /// </summary>
        public async Task Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task is null) throw new KeyNotFoundException($"Task with id {request.Id} not found");

            task.Status = request.Status;
            task.UpdatedAt = DateTime.UtcNow;

            await _taskRepository.UpdateAsync(task);
        }
    }
}