using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data
{
    /// <summary>
    /// کلاس اصلی زمینه (Context) برای ارتباط با دیتابیس.
    /// شامل مجموعه‌های داده (DbSet) برای موجودیت‌های TaskItem و Category است.
    /// </summary>
    public class TaskManagerDbContext : DbContext
    {
        /// <summary>
        /// سازنده کلاس که گزینه‌های دیتابیس را دریافت می‌کند.
        /// </summary>
        /// <param name="options">گزینه‌های پیکربندی Entity Framework.</param>
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// مجموعه داده‌ای برای موجودیت‌های کار (TaskItem).
        /// نام جدول در دیتابیس "Tasks" خواهد بود.
        /// </summary>
        public DbSet<TaskItem> Tasks { get; set; }

        /// <summary>
        /// مجموعه داده‌ای برای موجودیت‌های دسته‌بندی (Category).
        /// نام جدول در دیتابیس "Categories" خواهد بود.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// پیکربندی مدل‌ها هنگام ساخت دیتابیس.
        /// تنظیمات را از تمام کلاس‌های پیکربندی در اسمبلی جاری اعمال می‌کند.
        /// </summary>
        /// <param name="modelBuilder">سازنده مدل.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
        }
    }
}