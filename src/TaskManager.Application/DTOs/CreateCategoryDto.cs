using System;

namespace TaskManager.Application.DTOs
{
    /// <summary>
    /// انتقال دهنده داده‌های مورد نیاز برای ایجاد یک دسته‌بندی جدید.
    /// </summary>
    public class CreateCategoryDto
    {
        /// <summary>
        /// نام دسته‌بندی جدید.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// توضیحات دسته‌بندی جدید (اختیاری).
        /// </summary>
        public string? Description { get; set; }
    }
}