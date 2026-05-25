using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Commands.Categories
{
    /// <summary>
    /// پردازشگر دستور ایجاد دسته‌بندی جدید.
    /// </summary>
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// سازنده کلاس که مخزن دسته‌بندی‌ها را دریافت می‌کند.
        /// </summary>
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// هندل کردن درخواست ایجاد دسته‌بندی.
        /// </summary>
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            await _categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}