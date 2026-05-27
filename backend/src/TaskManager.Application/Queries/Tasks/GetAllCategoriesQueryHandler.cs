using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Queries.Categories
{
    /// <summary>
    /// هندلر کوئری دریافت لیست تمام دسته‌بندی‌ها.
    /// </summary>
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// سازنده کلاس که مخزن دسته‌بندی‌ها را دریافت می‌کند.
        /// </summary>
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// مدیریت درخواست دریافت تمام دسته‌بندی‌ها و تبدیل آن‌ها به DTO.
        /// </summary>
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                TaskCount = c.Tasks.Count
            });
        }
    }
}