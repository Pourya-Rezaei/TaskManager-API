using FluentAssertions;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Application.Validators;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Tests
{
    public class CreateTaskCommandValidatorTests
    {
        [Fact]
        public void Validate_ValidCommand_ShouldPassValidation()
        {
            // Arrange
            var validator = new CreateTaskCommandValidator();
            var command = new CreateTaskCommand(
                Title: "Valid Title",
                Description: null,
                Priority: TaskPriority.Medium,
                DueDate: null,
                CategoryId: null
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validate_EmptyTitle_ShouldFailValidation()
        {
            // Arrange
            var validator = new CreateTaskCommandValidator();
            var command = new CreateTaskCommand(
                Title: "",
                Description: null,
                Priority: TaskPriority.Medium,
                DueDate: null,
                CategoryId: null
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Title");
        }

        [Fact]
        public void Validate_TitleTooLong_ShouldFailValidation()
        {
            // Arrange
            var validator = new CreateTaskCommandValidator();
            var command = new CreateTaskCommand(
                Title: new string('A', 201),
                Description: null,
                Priority: TaskPriority.Medium,
                DueDate: null,
                CategoryId: null
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Title");
        }

        [Fact]
        public void Validate_PastDueDate_ShouldFailValidation()
        {
            // Arrange
            var validator = new CreateTaskCommandValidator();
            var command = new CreateTaskCommand(
                Title: "Valid Title",
                Description: null,
                Priority: TaskPriority.Medium,
                DueDate: DateTime.UtcNow.AddDays(-1),
                CategoryId: null
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "DueDate");
        }
    }
}