using System;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities
{
    /// <summary>
    /// موجودیت آیتم کار که وظایف پروژه را نمایندگی می‌کند
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// شناسه یکتای کار
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// عنوان کار
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// توضیحات کار (اختیاری)
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// وضعیت فعلی کار (پیش‌فرض: Todo)
        /// </summary>
        public TaskStatus Status { get; set; } = TaskStatus.Todo;

        /// <summary>
        /// اولویت کار (پیش‌فرض: Medium)
        /// </summary>
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        /// <summary>
        /// موعد تحویل کار (اختیاری)
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// تاریخ و زمان ایجاد کار
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// تاریخ و زمان آخرین به‌روزرسانی (اختیاری)
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// شناسه دسته‌بندی مرتبط (اختیاری)
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// موجودیت دسته‌بندی مرتبط (اختیاری)
        /// </summary>
        public Category? Category { get; set; }
    }
}