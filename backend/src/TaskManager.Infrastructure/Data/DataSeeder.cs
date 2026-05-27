using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(TaskManagerDbContext context)
        {
            if (context.Categories.Any()) return;

            var workCategory = new Category
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "کار",
                Description = "وظایف مربوط به کار"
            };

            var personalCategory = new Category
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "شخصی",
                Description = "وظایف شخصی"
            };

            await context.Categories.AddRangeAsync(workCategory, personalCategory);

            var tasks = new[]
            {
                new TaskItem
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Title = "بررسی ایمیل‌های کاری",
                    Description = "پاسخ به ایمیل‌های مهم",
                    Status = TaskStatus.Todo,
                    Priority = TaskPriority.High,
                    CategoryId = workCategory.Id,
                    CreatedAt = DateTime.UtcNow
                },
                new TaskItem
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Title = "جلسه تیمی هفتگی",
                    Description = "آماده‌سازی برای جلسه هفتگی تیم",
                    Status = TaskStatus.InProgress,
                    Priority = TaskPriority.Medium,
                    CategoryId = workCategory.Id,
                    CreatedAt = DateTime.UtcNow
                },
                new TaskItem
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    Title = "خرید مواد غذایی",
                    Description = "خرید هفتگی از سوپرمارکت",
                    Status = TaskStatus.Todo,
                    Priority = TaskPriority.Low,
                    CategoryId = personalCategory.Id,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Tasks.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
        }
    }
}