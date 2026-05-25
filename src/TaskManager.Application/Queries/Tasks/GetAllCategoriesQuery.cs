using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Queries.Categories
{
    /// <summary>
    /// کوئری برای دریافت لیست تمام دسته‌بندی‌ها.
    /// </summary>
    public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;
}