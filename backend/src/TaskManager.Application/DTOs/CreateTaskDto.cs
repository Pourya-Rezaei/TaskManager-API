using System;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs
{
    /// <summary>
    /// انتقال دهنده داده‌های مورد نیاز برای ایجاد یک کار جدید.
    /// </summary>
    public class CreateTaskDto
    {
        /// <summary>
        /// عنوان کار جدید.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// توضیحات کار جدید (اختیاری).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// اولویت کار جدید.
        /// </summary>
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        /// <summary>
        /// موعد تحویل کار جدید (اختیاری).
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// شناسه دسته‌بندی برای کار جدید (اختیاری).
        /// </summary>
        public Guid? CategoryId { get; set; }
    }
}