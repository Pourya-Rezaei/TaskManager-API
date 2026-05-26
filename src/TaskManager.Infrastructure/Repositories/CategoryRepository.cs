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
    /// پیاده‌سازی مخزن دسته‌بندی‌ها برای دسترسی به داده‌های Category در دیتابیس.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TaskManagerDbContext _context;

        /// <summary>
        /// سازنده کلاس CategoryRepository که زمینه دیتابیس را دریافت می‌کند.
        /// </summary>
        /// <param name="context">زمینه دیتابیس TaskManager.</param>
        public CategoryRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// دریافت تمام دسته‌بندی‌ها به همراه لیست کارهای مربوطه.
        /// </summary>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.Tasks)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت یک دسته‌بندی بر اساس شناسه به همراه لیست کارهای مربوطه.
        /// </summary>
        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories
                .Include(c => c.Tasks)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// افزودن یک دسته‌بندی جدید به دیتابیس.
        /// </summary>
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
    }
}