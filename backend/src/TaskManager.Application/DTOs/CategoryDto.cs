using System;

namespace TaskManager.Application.DTOs
{
    /// <summary>
    /// انتقال دهنده داده‌های مربوط به یک دسته‌بندی (Category) برای نمایش.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// شناسه یکتای دسته‌بندی.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// نام دسته‌بندی.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// توضیحات دسته‌بندی (اختیاری).
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// تعداد کارهای مرتبط با این دسته‌بندی.
        /// </summary>
        public int TaskCount { get; init; }
    }
}