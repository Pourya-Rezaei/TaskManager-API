using System;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.DTOs
{
    /// <summary>
    /// انتقال دهنده داده‌های مربوط به یک کار (Task) برای نمایش.
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// شناسه یکتای کار.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// عنوان کار.
        /// </summary>
        public string Title { get; init; } = string.Empty;

        /// <summary>
        /// توضیحات کار (اختیاری).
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// وضعیت فعلی کار.
        /// </summary>
        public TaskStatus Status { get; init; }

        /// <summary>
        /// اولویت کار.
        /// </summary>
        public TaskPriority Priority { get; init; }

        /// <summary>
        /// موعد تحویل کار (اختیاری).
        /// </summary>
        public DateTime? DueDate { get; init; }

        /// <summary>
        /// تاریخ و زمان ایجاد کار.
        /// </summary>
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// تاریخ و زمان آخرین به‌روزرسانی کار (اختیاری).
        /// </summary>
        public DateTime? UpdatedAt { get; init; }

        /// <summary>
        /// شناسه دسته‌بندی مرتبط با کار (اختیاری).
        /// </summary>
        public Guid? CategoryId { get; init; }

        /// <summary>
        /// نام دسته‌بندی مرتبط با کار (اختیاری).
        /// </summary>
        public string? CategoryName { get; init; }
    }
}