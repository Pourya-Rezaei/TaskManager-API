using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Commands.Tasks
{
    /// <summary>
    /// پردازشگر دستور حذف کار.
    /// </summary>
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// سازنده کلاس که مخزن کارها را دریافت می‌کند.
        /// </summary>
        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// هندل کردن درخواست حذف کار.
        /// </summary>
        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.DeleteAsync(request.Id);
        }
    }
}