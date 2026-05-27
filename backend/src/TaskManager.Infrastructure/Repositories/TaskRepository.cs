using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    /// <summary>
    /// پیاده‌سازی مخزن کارها برای دسترسی به داده‌های TaskItem در دیتابیس.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDbContext _context;

        /// <summary>
        /// سازنده کلاس TaskRepository که زمینه دیتابیس را دریافت می‌کند.
        /// </summary>
        /// <param name="context">زمینه دیتابیس TaskManager.</param>
        public TaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// دریافت تمام کارها به همراه دسته‌بندی مربوطه.
        /// </summary>
        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت یک کار بر اساس شناسه به همراه دسته‌بندی مربوطه.
        /// </summary>
        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// افزودن یک کار جدید به دیتابیس.
        /// </summary>
        public async Task AddAsync(TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// به‌روزرسانی اطلاعات یک کار موجود در دیتابیس.
        /// </summary>
        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// حذف یک کار از دیتابیس بر اساس شناسه.
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is not null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}