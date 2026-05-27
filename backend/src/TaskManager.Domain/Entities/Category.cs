using System;
using System.Collections.Generic;

namespace TaskManager.Domain.Entities
{
    /// <summary>
    /// موجودیت دسته‌بندی برای گروه‌بندی کارها
    /// </summary>
    public class Category
    {
        /// <summary>
        /// شناسه یکتای دسته‌بندی
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// نام دسته‌بندی
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// توضیحات دسته‌بندی (اختیاری)
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// لیست کارهای مربوط به این دسته‌بندی
        /// </summary>
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}