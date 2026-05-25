using FluentAssertions;
using NSubstitute;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Tests
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldReturnNewGuid()
        {
            // Arrange
            var repository = Substitute.For<ITaskRepository>();
            var handler = new CreateTaskCommandHandler(repository);
            var command = new CreateTaskCommand(
                Title: "Test Task",
                Description: null,
                Priority: TaskPriority.Medium,
                DueDate: null,
                CategoryId: null
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldCallAddAsync()
        {
            // Arrange
            var repository = Substitute.For<ITaskRepository>();
            var handler = new CreateTaskCommandHandler(repository);
            var command = new CreateTaskCommand(
                Title: "Test Task",
                Description: null,
                Priority: TaskPriority.Medium,
                DueDate: null,
                CategoryId: null
            );

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            await repository.Received(1).AddAsync(Arg.Any<TaskItem>());
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldSetCorrectTitle()
        {
            // Arrange
            var repository = Substitute.For<ITaskRepository>();
            var handler = new CreateTaskCommandHandler(repository);
            var command = new CreateTaskCommand(
                Title: "My Task",
                Description: null,
                Priority: TaskPriority.High,
                DueDate: null,
                CategoryId: null
            );
            TaskItem? capturedTask = null;
            await repository.AddAsync(Arg.Do<TaskItem>(t => capturedTask = t));

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            capturedTask.Should().NotBeNull();
            capturedTask!.Title.Should().Be("My Task");
            capturedTask.Priority.Should().Be(TaskPriority.High);
        }
    }
}