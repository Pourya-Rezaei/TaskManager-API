using Xunit;
using FluentAssertions;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Tests
{
    /// <summary>
    /// تست‌های مربوط به کلاس Category برای اطمینان از صحت مقادیر پیش‌فرض و رفتار اولیه.
    /// </summary>
    public class CategoryTests
    {
        /// <summary>
        /// بررسی می‌کند که هنگام ساخت Category، مقدار Id یک Guid جدید و غیر خالی باشد.
        /// </summary>
        [Fact]
        public void Category_WhenCreated_ShouldHaveNewGuidId()
        {
            // Arrange & Act
            var category = new Category();

            // Assert
            category.Id.Should().NotBe(Guid.Empty);
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت Category، لیست Tasks مقداردهی شده و خالی باشد (نه null).
        /// </summary>
        [Fact]
        public void Category_WhenCreated_ShouldHaveEmptyTasksList()
        {
            // Arrange & Act
            var category = new Category();

            // Assert
            category.Tasks.Should().NotBeNull();
            category.Tasks.Should().BeEmpty();
        }

        /// <summary>
        /// بررسی می‌کند که هنگام ساخت Category، مقدار پیش‌فرض Name برابر با رشته خالی باشد.
        /// </summary>
        [Fact]
        public void Category_WhenCreated_NameShouldBeEmptyString()
        {
            // Arrange & Act
            var category = new Category();

            // Assert
            category.Name.Should().Be(string.Empty);
        }
    }
}