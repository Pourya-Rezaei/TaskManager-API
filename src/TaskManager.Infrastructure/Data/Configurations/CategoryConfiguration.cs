using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data.Configurations
{
    /// <summary>
    /// کلاس پیکربندی برای موجودیت Category جهت تعیین دقیق ساختار جدول در دیتابیس.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// متد پیکربندی که قوانین مربوط به جدول Categories را اعمال می‌کند.
        /// </summary>
        /// <param name="builder">سازنده موجودیت برای Category.</param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // تعیین نام جدول در دیتابیس
            builder.ToTable("Categories");

            // تعیین کلید اصلی
            builder.HasKey(c => c.Id);

            // پیکربندی خاصیت Name: اجباری و حداکثر ۱۰۰ کاراکتر
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // پیکربندی خاصیت Description: اختیاری و حداکثر ۵۰۰ کاراکتر
            builder.Property(c => c.Description)
                .HasMaxLength(500);
        }
    }
}