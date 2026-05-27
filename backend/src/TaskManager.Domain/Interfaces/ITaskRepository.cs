using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    /// <summary>
    /// قرارداد عملیات مربوط به مخزن کارها (Task Repository).
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// دریافت لیست تمام کارها به صورت ناهمگام.
        /// </summary>
        /// <returns>لیستی از تمام آیتم‌های کار.</returns>
        Task<IEnumerable<TaskItem>> GetAllAsync();

        /// <summary>
        /// دریافت یک کار خاص بر اساس شناسه به صورت ناهمگام.
        /// </summary>
        /// <param name="id">شناسه یکتای کار.</param>
        /// <returns>آیتم کار در صورت وجود، در غیر این صورت null.</returns>
        Task<TaskItem?> GetByIdAsync(Guid id);

        /// <summary>
        /// افزودن یک کار جدید به مخزن به صورت ناهمگام.
        /// </summary>
        /// <param name="task">کار جدید برای افزودن.</param>
        Task AddAsync(TaskItem task);

        /// <summary>
        /// به‌روزرسانی اطلاعات یک کار موجود به صورت ناهمگام.
        /// </summary>
        /// <param name="task">کار با اطلاعات به‌روزرسانی شده.</param>
        Task UpdateAsync(TaskItem task);

        /// <summary>
        /// حذف یک کار بر اساس شناسه به صورت ناهمگام.
        /// </summary>
        /// <param name="id">شناسه یکتای کار برای حذف.</param>
        Task DeleteAsync(Guid id);
    }
}