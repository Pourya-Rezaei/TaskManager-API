using Xunit;
using FluentAssertions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Tests
{
    /// <summary>
    /// تست‌های مربوط به کلاس TaskItem برای اطمینان از صحت مقادیر پیش‌فرض و رفتار اولیه.
    /// </summary>
    public class TaskItemTests
    {
        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، مقدار Id یک Guid جدید و غیر خالی باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_ShouldHaveNewGuidId()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.Id.Should().NotBe(Guid.Empty);
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، وضعیت پیش‌فرض برابر با Todo باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_StatusShouldBeTodo()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.Status.Should().Be(TaskStatus.Todo);
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، اولویت پیش‌فرض برابر با Medium باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_PriorityShouldBeMedium()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.Priority.Should().Be(TaskPriority.Medium);
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، مقدار پیش‌فرض Title برابر با رشته خالی باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_TitleShouldBeEmptyString()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.Title.Should().Be(string.Empty);
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، تاریخ ساخت (CreatedAt) مقداردهی شده باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_CreatedAtShouldBeSet()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.CreatedAt.Should().NotBe(default);
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، تاریخ ویرایش (UpdatedAt) برابر با null باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_UpdatedAtShouldBeNull()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.UpdatedAt.Should().BeNull();
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، رابطه Category برابر با null باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_CategoryShouldBeNull()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.Category.Should().BeNull();
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت TaskItem، شناسه دسته‌بندی (CategoryId) برابر با null باشد.
        /// </summary>
        [Fact]
        public void TaskItem_WhenCreated_CategoryIdShouldBeNull()
        {
            // Arrange & Act
            var taskItem = new TaskItem();

            // Assert
            taskItem.CategoryId.Should().BeNull();
        }
    }
}