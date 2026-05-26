using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data.Configurations
{
    /// <summary>
    /// کلاس پیکربندی برای موجودیت TaskItem جهت تعیین دقیق ساختار جدول در دیتابیس.
    /// </summary>
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        /// <summary>
        /// متد پیکربندی که قوانین مربوط به جدول Tasks را اعمال می‌کند.
        /// </summary>
        /// <param name="builder">سازنده موجودیت برای TaskItem.</param>
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            // تعیین نام جدول در دیتابیس
            builder.ToTable("Tasks");

            // تعیین کلید اصلی
            builder.HasKey(t => t.Id);

            // پیکربندی خاصیت Title: اجباری و حداکثر ۲۰۰ کاراکتر
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            // پیکربندی خاصیت Description: اختیاری و حداکثر ۲۰۰۰ کاراکتر
            builder.Property(t => t.Description)
                .HasMaxLength(2000);

            // پیکربندی خاصیت Status: اجباری و تبدیل به عدد صحیح در دیتابیس
            builder.Property(t => t.Status)
                .IsRequired()
                .HasConversion<int>();

            // پیکربندی خاصیت Priority: اجباری و تبدیل به عدد صحیح در دیتابیس
            builder.Property(t => t.Priority)
                .IsRequired()
                .HasConversion<int>();

            // پیکربندی خاصیت CreatedAt: اجباری
            builder.Property(t => t.CreatedAt)
                .IsRequired();

            // پیکربندی رابطه یک‌به‌چند با Category
            // اگر Category حذف شد، مقدار CategoryId در Task به NULL تغییر کند
            builder.HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}