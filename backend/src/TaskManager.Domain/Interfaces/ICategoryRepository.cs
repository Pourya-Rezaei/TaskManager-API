using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    /// <summary>
    /// قرارداد عملیات مربوط به مخزن دسته‌بندی‌ها (Category Repository).
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// دریافت لیست تمام دسته‌بندی‌ها به صورت ناهمگام.
        /// </summary>
        /// <returns>لیستی از تمام دسته‌بندی‌ها.</returns>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// دریافت یک دسته‌بندی خاص بر اساس شناسه به صورت ناهمگام.
        /// </summary>
        /// <param name="id">شناسه یکتای دسته‌بندی.</param>
        /// <returns>دسته‌بندی در صورت وجود، در غیر این صورت null.</returns>
        Task<Category?> GetByIdAsync(Guid id);

        /// <summary>
        /// افزودن یک دسته‌بندی جدید به مخزن به صورت ناهمگام.
        /// </summary>
        /// <param name="category">دسته‌بندی جدید برای افزودن.</param>
        Task AddAsync(Category category);
    }
}