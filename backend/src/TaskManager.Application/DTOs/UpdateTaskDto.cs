using System;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs
{
    /// <summary>
    /// انتقال دهنده داده‌های مورد نیاز برای به‌روزرسانی یک کار موجود.
    /// </summary>
    public class UpdateTaskDto
    {
        /// <summary>
        /// عنوان جدید کار.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// توضیحات جدید کار (اختیاری).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// اولویت جدید کار.
        /// </summary>
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        /// <summary>
        /// موعد تحویل جدید کار (اختیاری).
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// شناسه دسته‌بندی جدید برای کار (اختیاری).
        /// </summary>
        public Guid? CategoryId { get; set; }
    }
}